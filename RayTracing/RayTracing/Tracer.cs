using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracing;

public struct TaskParams
{
    public int startX;
    public int startY;
    public int stopX;
    public int stopY;

    public TaskParams(int startX, int startY, int stopX, int stopY)
    {
        this.startX = startX;
        this.startY = startY;
        this.stopX = stopX;
        this.stopY = stopY;
    }
}

public class Tracer
{
    public int SplittingHeight { get; set; } = 10;
    public int SplittingWidth { get; set; } = 20;
    public Scene Scene { get; set; } = new Scene();
    public ILightModel LightModel { get; set; }
         = new RayTracingStrongShadowsModel();
    public int Depth { get; set; } = 1;

    public int Width { get; set; } = 800;
    public int Height { get; set; } = 400;

    private Task[] _tasks = null!;

    public Tracer()
    {}

    private void RenderPartOfScreen(TaskParams taskParams,
                                    Screen screen,
                                    Image<Rgb24> image,
                                    Vector3[,] points)
    {
        for(int y = taskParams.startY; y < taskParams.stopY; ++y)
        {
            for(int x = taskParams.startX; x < taskParams.stopX; ++x)
            {
                var point = points[y, x];
                Ray ray = Scene.Camera.GetRay(point);     
                Vector3 color = Trace(ray, 0, 1);
                image[x, y] = new Rgb24((byte)Math.Clamp(color.X, 0, 255),
                                        (byte)Math.Clamp(color.Y, 0, 255),
                                        (byte)Math.Clamp(color.Z, 0, 255));
            }
        }
    }

    public Image Render()
    {
        Screen screen = Scene.Camera.GetScreen(Width, Height);
        Image<Rgb24> image = new Image<Rgb24>(Width, Height);
        var points = screen.Points;

        CreateTasks(screen, image, points);
        for(int i = 0; i < _tasks.Length; ++i)
            _tasks[i].Start();
        
        Task.WaitAll(_tasks);
        
        return image;
    }

    private void CreateTasks(Screen screen,
                             Image<Rgb24> image,
                             Vector3[,] points)
    {
        _tasks = new Task[SplittingHeight * SplittingWidth];
        int taskIndex = 0;
        int pixelPerLine = Height / SplittingHeight;
        int pixelPerColumn = Width / SplittingWidth;
        for (int line = 0; line < SplittingHeight; ++line)
        {
            for (int col = 0; col < SplittingWidth; ++col)
            {
                var tp = new TaskParams(col * pixelPerColumn,
                                        line * pixelPerLine,
                                        (col + 1) * pixelPerColumn,
                                        (line + 1) * pixelPerLine);
                _tasks[taskIndex++] = new Task(() => RenderPartOfScreen(tp,
                                                                        screen,
                                                                        image,
                                                                        points));
            }
        }
    }

    private Vector3 Trace(Ray ray, int depth, double refr)
    {
        if(depth == Depth)
            return new Vector3();
        

        var iData = Scene.GetNearestIntersection(ray);
        if(iData.IsMiss)
            return new Vector3();

        double in_ray_den = refr;
        double out_ray_den = 1;
        if(in_ray_den == 1)
            out_ray_den = iData.Model!.Material.Refractivity;

        var lightness = LightModel.CalculateLightness(iData.Point!,
                                                      iData.Normal!,
                                                      iData.Model!.Material,
                                                      Scene);
        var reflColor = new Vector3();
        if(iData.Model.Material.Reflectivity > 0)
            reflColor = Trace(ray.Reflect(iData.Point!, iData.Normal!, out_ray_den, in_ray_den), depth + 1, refr);

        var refrColor = new Vector3();
        if(iData.Model.Material.Transparency > 0) {
            var refractRay = ray.Refract(iData.Point!, iData.Normal!, out_ray_den, in_ray_den);
            if(refractRay is not null)
                refrColor = Trace(refractRay, depth + 1, out_ray_den);
        }

        return lightness * (1 - iData.Model!.Material.Absorption) *
                iData.Model!.Material.GetColor(
                    iData.Triangle!.GetTextureUV(iData.Point!))
                 + reflColor * iData.Model.Material.Reflectivity
                 + iData.Model.Material.Transparency * refrColor;
    }
}
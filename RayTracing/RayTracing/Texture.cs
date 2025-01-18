using SixLabors.ImageSharp;
using RayTracing.Extensions;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracing;

public enum TextureWrapping
{
    Repeat,
    MirroredRepeat,
    ClampToEdge,
    ClampToBorder
}

public class Texture
{
    public TextureWrapping Wrapping { get; set; } = TextureWrapping.Repeat;
    public Vector3 BorderColor { get; set; } = new Vector3(0, 0, 0);
    public Image<Rgb24> Image { get; set; } = null!;    

    public Vector3 GetColor(double u, double v)
    {
        switch (Wrapping)
        {
            case TextureWrapping.Repeat:
                return RepeatColor(u, v);
            case TextureWrapping.MirroredRepeat:
                return MirroredRepeatColor(u, v);
            case TextureWrapping.ClampToEdge:
                return ClampToEdgeColor(u, v);
            case TextureWrapping.ClampToBorder:
                return ClampToBorderColor(u, v);
        }
        return BorderColor;
    }

    private Vector3 RepeatColor(double u, double v)
    {
        double x = u >= 0 ? u % 1 : -u % 1;
        double y = v >= 0 ? v % 1 : -v % 1;
        return Image[(int)(x * Image.Width),
                     (int)(y * Image.Height)].ToVector3();
    }

    private Vector3 MirroredRepeatColor(double u, double v)
    {
        double x = u >= 0 ? u % 1 : -u % 1;
        double y = v >= 0 ? v % 1 : -v % 1;
        if((int)u % 2 != 0)
            x = 1 - x;
        if((int)v % 2 != 0)
            y = 1 - y;
        
        return Image[(int)(x * Image.Width),
                     (int)(y * Image.Height)].ToVector3();
    }

    private Vector3 ClampToEdgeColor(double u, double v)
    {
        double x = Math.Clamp(u, 0, .999999);
        double y = Math.Clamp(v, 0, .999999);
        return Image[(int)(x * Image.Width),
                     (int)(y * Image.Height)].ToVector3();
    }

    private Vector3 ClampToBorderColor(double u, double v)
    {
        if (u < 0 || u > 1 || v < 0 || v > 1)
            return BorderColor;
        return Image[(int)(u * Image.Width),
                     (int)(v * Image.Height)].ToVector3();
    }

    public static Texture FromFile(string path)
    {
        Texture texture = new Texture 
        {
            Image = SixLabors.ImageSharp.Image.Load<Rgb24>(path) 
        };
        return texture;    
    }

    public static Texture FromImage(Image<Rgb24> image)
    {
        Texture texture = new Texture { Image = image };
        return texture;    
    }

    private Texture()
    {}
}
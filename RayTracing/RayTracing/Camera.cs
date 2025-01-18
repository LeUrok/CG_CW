namespace RayTracing;

public class Camera
{
    private static readonly Vector3 DefaultUp = new Vector3(0, 1, 0);
    private static readonly Vector3 DefaultPos = new Vector3(0, 0, -10);
    private static readonly Vector3 DefaultVp = new Vector3(0, 0, 1);
    private static readonly double DefaultFoV = 90;

    public Vector3 Position { get; set; } = DefaultPos;
    public Vector3 ViewPoint { get; set; } = DefaultVp;
    public Vector3 Up { get; set; } = DefaultUp;

    public double FieldOfView { get; set; } = DefaultFoV;
    public double Aspect { get; set; } = 16.0 / 9.0;

    public void Reset()
    {
        Position = DefaultPos;
        ViewPoint = DefaultVp;
        Up = DefaultUp;
        FieldOfView = DefaultFoV;    
    }

    public Screen GetScreen(int width, int height)
    {        
        var direction = (ViewPoint - Position).Normalized;
        var up = Up.Normalized;
        var right = direction.Cross(up);
        var center = Position + direction * ScreenDistance;
        var x = ScreenDistance * Math.Tan(FieldOfView * Math.PI / 360);
        var Rc = center + right * x;
        var Lc = center - right * x;
        var y = x / Aspect;
        var Lu = Lc + up * y;
        var Ld = Lc - up * y;
        var Ru = Rc + up * y;
        
        return new Screen
        {
            Width = width,
            Height = height,
            LeftUp = Lu,
            LeftDown = Ld,
            RightUp = Ru
        };
    }

    public Ray GetRay(Vector3 point)
    {
        return new Ray(Position, point - Position);
    }

    public void MoveUp(double distance)
    {
        Position += Up * distance;
        ViewPoint += Up * distance;
    }
    public void MoveDown(double distance)
    {
        Position -= Up * distance;
        ViewPoint -= Up * distance;
    }
    public void MoveLeft(double distance)
    {
        var right = (ViewPoint - Position).Normalize().Cross(Up);
        Position -= right * distance;
        ViewPoint -= right * distance;
    }
    public void MoveRight(double distance)
    {
        var right = (ViewPoint - Position).Cross(Up).Normalize();
        Position += right * distance;
        ViewPoint += right * distance;
    }
    public void MoveForward(double distance)
    {
        Position += (ViewPoint - Position).Normalize() * distance;
        ViewPoint += (ViewPoint - Position).Normalize() * distance;
    }
    public void MoveBackward(double distance)
    {
        Position -= (ViewPoint - Position).Normalize() * distance;
        ViewPoint -= (ViewPoint - Position).Normalize() * distance;
    }

    public void RotateLeft(double angle)
    {
        var k = Up.Normalized;
        var cos = Math.Cos(angle * DegreesToRadians);
        var sin = Math.Sin(angle * DegreesToRadians);
        var direction = ViewPoint - Position;
        var d_dir = direction * cos + 
                    k.Cross(direction) * sin +
                    k * k.Dot(direction) * (1 - cos);
        ViewPoint = Position + d_dir;
    }
    public void RotateRight(double angle) => RotateLeft(-angle);
    
    public void RotateUp(double angle)
    {
        var direction = ViewPoint - Position;
        var k = direction.Cross(Up).Normalize();

        var cos = Math.Cos(angle * DegreesToRadians);
        var sin = Math.Sin(angle * DegreesToRadians);
        var d_dir = direction * cos + 
                    k.Cross(direction) * sin +
                    k * k.Dot(direction) * (1 - cos);
        var d_up = Up * cos + 
                   k.Cross(Up) * sin +
                   k * k.Dot(Up) * (1 - cos);
        ViewPoint = Position + d_dir;
        Up = d_up.Normalize();
    }
    public void RotateDown(double angle) => RotateUp(-angle);

    public void RotateClockwise(double angle)
    {        
        var k = (ViewPoint - Position).Normalize();

        var cos = Math.Cos(angle * DegreesToRadians);
        var sin = Math.Sin(angle * DegreesToRadians);
        var d_up = Up * cos + 
                   k.Cross(Up) * sin +
                   k * k.Dot(Up) * (1 - cos);
        Up = d_up.Normalize();
    }
    public void RotateCounterClockwise(double angle) => RotateClockwise(-angle);

    public const double ScreenDistance = 1.0;
    public const double DegreesToRadians = Math.PI / 180.0;
}

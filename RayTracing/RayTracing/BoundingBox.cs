namespace RayTracing;

public class BoundingBox
{
    public Vector3 Max => _max;
    public Vector3 Min => _min;

    public BoundingBox()
    {
        Reset();
    }

    public void Update(Vector3 vertex)
    {
        _max.X = Math.Max(Max.X, vertex.X);
        _max.Y = Math.Max(Max.Y, vertex.Y);
        _max.Z = Math.Max(Max.Z, vertex.Z);

        _min.X = Math.Min(Min.X, vertex.X);
        _min.Y = Math.Min(Min.Y, vertex.Y);
        _min.Z = Math.Min(Min.Z, vertex.Z);
    }

    public void Reset()
    {
        _max = new Vector3(double.MinValue, double.MinValue, double.MinValue);
        _min = new Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
    }
    private Vector3 _max = null!;
    private Vector3 _min = null!;
}
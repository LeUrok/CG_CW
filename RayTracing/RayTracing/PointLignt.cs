namespace RayTracing;

public class PointLight : Light
{
    public Vector3 Position { get; set; } = new Vector3(0, 5, 0);
    public PointLight() {}
    public PointLight(Vector3 diffusion,
                      Vector3 specular,
                      Vector3 position)
        : base(diffusion, specular)
    {
        Position = position;
    }

    public override Vector3 GetDirectionFrom(Vector3 point)
    {
        return (Position - point).Normalize();
    }

    public override double GetDistanceFrom(Vector3 point)
    {
        return (Position - point).Length;
    }

    public override void SetPosition(Vector3 pos)
    {
        Position = pos;
    }

    public override void SetDirection(Vector3 dir)
    {}

    public override Vector3 GetPosition()
    {
        return Position;
    }

    public override Vector3 GetDirection()
    {
        return new Vector3();
    }
}
namespace RayTracing;

public class DirectionLight : Light
{
    public Vector3 Direction { get; set; } = new Vector3(2, -1, 2);

    public DirectionLight() { }

    public DirectionLight(Vector3 diffusion,
                          Vector3 specular,
                          Vector3 direction)
        : base(diffusion, specular)
    {
        Direction = direction.Normalized;
    }

    public override Vector3 GetDirectionFrom(Vector3 point)
    {
        return -Direction;
    }

    public override double GetDistanceFrom(Vector3 point)
    {
        return double.PositiveInfinity;
    }

    public override void SetPosition(Vector3 pos)
    {}

    public override void SetDirection(Vector3 dir)
    {
        Direction = dir.Normalize();
    }

    public override Vector3 GetPosition()
    {
        return new Vector3(double.PositiveInfinity,
                           double.PositiveInfinity,
                           double.PositiveInfinity);
    }

    public override Vector3 GetDirection()
    {
        return Direction;
    }
}
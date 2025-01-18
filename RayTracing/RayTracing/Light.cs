namespace RayTracing;

public abstract class Light
{
    public string Name { get; set; } = "";

    public Vector3 Diffuse { get; set; } = new Vector3(.8, .8, .8);
    public Vector3 Specular { get; set; } = new Vector3(.3, .3, .3);

    public Light() { }
    public Light(Vector3 diffuse, Vector3 specular)
    {
        Diffuse = diffuse;
        Specular = specular;
    }

    public abstract Vector3 GetDirectionFrom(Vector3 point);
    public abstract double GetDistanceFrom(Vector3 point);

    public abstract void SetPosition(Vector3 pos);
    public abstract void SetDirection(Vector3 dir);

    public abstract Vector3 GetPosition();
    public abstract Vector3 GetDirection();

    public override string ToString() => Name;
}
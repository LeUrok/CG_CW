namespace RayTracing;

public class IntersectInfo
{
    public Triangle? Triangle { get; set; }
    public Vector3? Point { get; set; }
    public Vector3? Normal { get; set; }
    public TextureUV? TextureUV { get; set; }
    public double Distance { get; set; }
    public Model? Model { get; set; }

    public bool IsHit => Point is not null;
    public bool IsMiss => Point is null;
}
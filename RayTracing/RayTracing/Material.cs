using System.Drawing;
using RayTracing.Exceptions;

namespace RayTracing;

public class Material
{
    public string Name { get; set; } = "";
    public Vector3 Diffuse { get; set; } = new Vector3();
    public Vector3 Specular { get; set; } = new Vector3();
    public double Shininess { get; set; } = 0.0;
    public double Reflectivity { get; set; } = 0.0;
    public double Refractivity { get; set; } = 0.0;
    public double Transparency { get; set; } = 0.0;
    public double Absorption { get; set; } = 0.0;
    public Vector3 Ambient { get; set; } = new Vector3(1, 1, 1);
    public Texture? Texture { get; set; } = null;
    public Vector3? Color { get; set; } = new Vector3(1, 1, 1);

    public Vector3 GetColor(TextureUV uv) => GetColor(uv.U, uv.V);
    public Vector3 GetColor(double u, double v)
    {
        if (Texture is not null)
           return Texture.GetColor(u, v);
        else if (Color is not null)
           return Color;
        throw new MaterialException(
            $"Material {Name} has no texture or color"
        );
    }
}
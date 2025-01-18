using System.Text.Json;

namespace RayTracing;

public class ModelConfig
{
    public string MeshFile { get; set; } = null!;
    public double Reflectivity { get; set; } = 0.0;
    public double Refractivity { get; set; } = 1.0;
    public double Absorption { get; set; } = 0.3;
    public double Transparency { get; set; } = 0.0;
    public double[] Color { get; set; } = new double[3] { 0, 0, 0 };
    public string TextureFile { get; set; } = "";


    public static ModelConfig? FromJson(string path)
    {
        return JsonSerializer.Deserialize<ModelConfig>(
            File.ReadAllText(path)
        );
    }    
}
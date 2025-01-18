namespace RayTracing;

public class Model
{
    public Mesh Mesh { get; set; }
    public Material Material { get; set; }
    public string Name { get; set; } = "";

    public Model(Mesh mesh, Material material)
    {
        Mesh = mesh;
        Material = material;    
    }

    public IntersectInfo Intersect(Ray ray)
    {
        var info = Mesh.Intersect(ray);
        if(info.IsHit)
            info.Model = this;
        return info;
    }

    public static Model Build(ModelConfig config)
    {
        Material? material = null;
        var mesh = MeshLoader.LoadMesh(config.MeshFile, out material);
        // Console.WriteLine($"MeshFile: {config.MeshFile}");
        // Console.WriteLine($"Reflectivity: {config.Reflectivity}");
        // Console.WriteLine($"Refractivity: {config.Refractivity}");
        // Console.WriteLine($"Absorption: {config.Absorption}");
        // Console.WriteLine($"Transparency: {config.Transparency}");
        // Console.WriteLine($"Color: ({config.Color[0]}, {config.Color[1]}, {config.Color[2]})");
        // Console.WriteLine($"TextureFile: {config.TextureFile}");        
        //material!.Color = new Vector3(config.Color[0], config.Color[1], config.Color[2]);
        material!.Color = new Vector3(config.Color[0], config.Color[1], config.Color[2]);
        material.Texture = config.TextureFile == "" ? null : Texture.FromFile(config.TextureFile);
        material.Reflectivity = config.Reflectivity;
        material.Refractivity = config.Refractivity;
        material.Transparency = config.Transparency;
        material.Absorption = config.Absorption;

        return new Model (mesh, material);
    }

    public override string ToString() => Name;
}
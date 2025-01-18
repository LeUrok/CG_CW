namespace RayTracing;

public class MaterialLoader
{
    public static Material LoadMaterial(string path)
    {
        string[] lines = File.ReadAllLines(path);
        Material material = new Material();
        for (int i = 0; i < lines.Length; ++i)
        {
            string[] split = lines[i].Split(' ');
            switch (split[0])
            {
                case "newmtl":
                    material.Name = split[1];
                    break;
                case "Ns":
                    material.Shininess = double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;
                case "Ka":
                    material.Ambient = new Vector3(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                   double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                   double.Parse(split[3], System.Globalization.NumberFormatInfo.InvariantInfo));
                    break;
                case "Kd":
                    material.Diffuse = new Vector3(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                   double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                   double.Parse(split[3], System.Globalization.NumberFormatInfo.InvariantInfo));
                    break;
                case "Ks":
                    material.Specular = new Vector3(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                    double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                    double.Parse(split[3], System.Globalization.NumberFormatInfo.InvariantInfo));
                    break;                
            }
        }
        return material;
    }
}
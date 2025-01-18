namespace RayTracing;

class MeshLoader
{
    public static Mesh LoadMesh(string path, out Material? material)
    {
        Mesh mesh = new Mesh();
        string? materialName = null;
        material = null;
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; ++i)
        {
            string[] split = lines[i].Split(' ');
            switch (split[0])
            {
                case "v":
                    mesh.AddVertex(new Vector3(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                               double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo),
                                               double.Parse(split[3], System.Globalization.NumberFormatInfo.InvariantInfo)));
                break;
                case "f":
                    mesh.AddFace(BuildFace(split)); break;
                case "vn":
                    mesh.AddNormal(new Vector3(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                               double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo),
                                               double.Parse(split[3], System.Globalization.NumberFormatInfo.InvariantInfo)).Normalize());
                break;
                case "vt":
                    mesh.AddTextureUV(new TextureUV(double.Parse(split[1], System.Globalization.NumberFormatInfo.InvariantInfo),
                                                    double.Parse(split[2], System.Globalization.NumberFormatInfo.InvariantInfo)));
                break;
                case "usemtl":
                    material = MaterialLoader.LoadMaterial(materialName!);
                break;
                case "mtllib":
                    materialName = split[1];
                break;
            }
        }
        return mesh;
    }

    private static Face BuildFace(string[] split)
    {
        string[] vtnA = split[1].Split('/');
        string[] vtnB = split[2].Split('/');
        string[] vtnC = split[3].Split('/');
        Face face = new Face {
            Va = int.Parse(vtnA[0]) - 1,
            Vb = int.Parse(vtnB[0]) - 1,
            Vc = int.Parse(vtnC[0]) - 1,
            Ta = vtnA[1] == "" ? null : int.Parse(vtnA[1]) - 1,
            Tb = vtnB[1] == "" ? null : int.Parse(vtnB[1]) - 1,
            Tc = vtnC[1] == "" ? null : int.Parse(vtnC[1]) - 1,
            Na = vtnA[2] == "" ? null : int.Parse(vtnA[2]) - 1,
            Nb = vtnB[2] == "" ? null : int.Parse(vtnB[2]) - 1,
            Nc = vtnC[2] == "" ? null : int.Parse(vtnC[2]) - 1
        };
        return face;
    }
}
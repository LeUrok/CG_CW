namespace RayTracing;


public class Mesh
{
    public BoundingBox BoundingBox { get; private set; }

    public IntersectInfo Intersect(Ray ray)
    {
        if(!ray.Intersect(BoundingBox))
            return new IntersectInfo();
        
        IntersectInfo? result = null;
        for(int i = 0; i < triangles.Count; ++i)
        {
            var intersect = triangles[i].Intersect(ray);
            if(intersect.Point is not null &&
               (result is null || intersect.Distance < result.Distance))
            {
                result = intersect;
            }
        }
        return result ?? new IntersectInfo();
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        BoundingBox.Min.Rotate(axis, angleDegree);
        BoundingBox.Max.Rotate(axis, angleDegree);
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Rotate(axis, angleDegree);
        for(int i = 0; i < normalStorage.Count; ++i)
            normalStorage[i].Rotate(axis, angleDegree);
                    
        RebuildTriangles();
        RebuildNormals();
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        BoundingBox.Min.Scale(axis, scaleFactor);
        BoundingBox.Max.Scale(axis, scaleFactor);
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Scale(axis, scaleFactor);

        RebuildTriangles();
    }

    public void Translate(Vector3 on)
    {
        BoundingBox.Min.Translate(on);
        BoundingBox.Max.Translate(on);
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Translate(on);

        RebuildTriangles();
    }

    public void AddVertex(Vector3 vertex)
    {
        vertexStorage.Add(vertex);
        BoundingBox.Update(vertex);
    }
    public void AddNormal(Vector3 normal)
    {
        normalStorage.Add(normal);
    }
    public void AddTextureUV(TextureUV textureUV)
    {
        texturUvsStorage.Add(textureUV);
    }
    public void AddFace(Face face)
    {
        faces.Add(face);
        Triangle triangle = BuildTriangle(face);
        triangles.Add(triangle);
    }
    public Triangle GetTriangle(int index)
    {
        return triangles[index];
    }

    private Triangle BuildTriangle(Face face)
    {
        var triangle = new Triangle(vertexStorage[face.Va],
                                    vertexStorage[face.Vb],
                                    vertexStorage[face.Vc]);
        if (face.Na is not null)
        {
            triangle.Na = normalStorage[face.Na!.Value];
            triangle.Nb = normalStorage[face.Nb!.Value];
            triangle.Nc = normalStorage[face.Nc!.Value];
        }
        if (face.Ta is not null)
        {
            triangle.Ta = texturUvsStorage[face.Ta!.Value];
            triangle.Tb = texturUvsStorage[face.Tb!.Value];
            triangle.Tc = texturUvsStorage[face.Tc!.Value];
        }

        return triangle;
    }

    private void RebuildTriangles()
    {
        for(int i = 0; i < faces.Count; ++i)
            triangles[i] = BuildTriangle(faces[i]);
    }
    private void RebuildNormals()
    {
        if(!faces[0].Na.HasValue)
            return;
        for(int i = 0; i < faces.Count; ++i)
        {
            triangles[i].Na = normalStorage[faces[i].Na!.Value];
            triangles[i].Nb = normalStorage[faces[i].Nb!.Value];
            triangles[i].Nc = normalStorage[faces[i].Nc!.Value];
        }
    }
    private void RebuildTextureUVs()
    {
        if(!faces[0].Ta.HasValue)
            return;
        for(int i = 0; i < faces.Count; ++i)
        {
            triangles[i].Ta = texturUvsStorage[faces[i].Ta!.Value];
            triangles[i].Tb = texturUvsStorage[faces[i].Tb!.Value];
            triangles[i].Tc = texturUvsStorage[faces[i].Tc!.Value];
        }        
    }

    private List<Vector3> vertexStorage;
    private List<Vector3> normalStorage;
    private List<TextureUV> texturUvsStorage;
    private List<Face> faces;

    private List<Triangle> triangles;

    public Mesh()
    {
        vertexStorage = new List<Vector3>();
        normalStorage = new List<Vector3>();
        texturUvsStorage = new List<TextureUV>();

        faces = new List<Face>();
        triangles = new List<Triangle>();

        BoundingBox = new BoundingBox();
    }
}
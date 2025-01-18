namespace RayTracing;

public class Scene
{
    public IReadOnlyCollection<Model> Models => _models;
    public IReadOnlyCollection<Light> Lights => _lights;

    public Camera Camera { get; set; } = new Camera();
    public Vector3 AmbientLight { get; set; } = new Vector3(0.3, 0.3, 0.3);

    public Scene()
    {
        _models = new List<Model>();
        _lights = new List<Light>();
    }

    public IntersectInfo GetNearestIntersection(Ray ray)
    {
        var intersectInfo = new IntersectInfo();
        foreach (var model in _models)
        {
            var curInfo = model.Intersect(ray);
            if(curInfo.IsHit && (intersectInfo.IsMiss ||
               curInfo.Distance < intersectInfo.Distance))
            {
                intersectInfo = curInfo;
            }
        }
        return intersectInfo;
    }

    public void AddModel(Model model) => _models.Add(model);
    public bool RemoveModel(Model model) => _models.Remove(model);

    public void AddLight(Light light) => _lights.Add(light);
    public bool RemoveLight(Light light) => _lights.Remove(light);

    private List<Model> _models;
    private List<Light> _lights;
}
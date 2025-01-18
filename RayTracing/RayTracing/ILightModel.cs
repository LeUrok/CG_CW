namespace RayTracing;

public interface ILightModel
{
    Vector3 CalculateLightness(Vector3 point,
                               Vector3 normal,
                               Material material,
                               Scene scene);
}
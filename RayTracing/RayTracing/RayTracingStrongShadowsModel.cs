namespace RayTracing;

public class RayTracingStrongShadowsModel : ILightModel
{
    public Vector3 CalculateLightness(
        Vector3 point,
        Vector3 normal,
        Material material,
        Scene scene
    ) {
        point += normal * 0.001f; // для избежания ложных столкновений с самим объектом и возникновения артефактов
        Vector3 lightness = scene.AmbientLight * material.Ambient;
        foreach (var light in scene.Lights)
        {
            if (PointIsIlluminated(point, light, scene))
            {
                var rayToLight = new Ray(point, light.GetDirectionFrom(point));
                var cameraDirection = (scene.Camera.Position - point).Normalize();
                var cosDiff = normal.Dot(rayToLight.Direction);
                if(cosDiff > 0)
                    lightness += material.Diffuse * light.Diffuse *
                                 cosDiff;

                if(material.Shininess >= 0) {
                    var reflDir = -rayToLight.Reflect(point, normal).Direction;
                    var cosSpec = cameraDirection.Dot(reflDir);
                    if(cosSpec > 0)
                        lightness += material.Specular * light.Specular *
                                     Math.Pow(cosSpec, material.Shininess);
                }
            }
        }
        return lightness;
    }

    private bool PointIsIlluminated(Vector3 point, Light light, Scene scene)
    {
        var rayToLight = new Ray(point, light.GetDirectionFrom(point));
        var intersectInfo = scene.GetNearestIntersection(rayToLight);
        return intersectInfo.IsMiss ||
               intersectInfo.Distance > light.GetDistanceFrom(point);
    }
}


		
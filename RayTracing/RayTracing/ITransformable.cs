namespace RayTracing;

public interface ITransformable
{    
    void Translate(Vector3 on);
    void Rotate(Axis axis, double angleDegree);
    void Scale(Axis axis, double scaleFactor);
}
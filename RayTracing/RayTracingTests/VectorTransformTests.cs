namespace RayTracingTests;

public class VectorTransformTests
{
    [TestCase(0, 0, 0, 0, 0, 0, Axis.X, 2)]
    [TestCase(0, 0, 0, 0, 0, 0, Axis.Y, 2)]
    [TestCase(0, 0, 0, 0, 0, 0, Axis.Z, 2)]
    [TestCase(1, 0, 0, 2, 0, 0, Axis.X, 2)]
    [TestCase(0, 1, 0, 0, 2, 0, Axis.Y, 2)]
    [TestCase(0, 0, 1, 0, 0, 2, Axis.Z, 2)]
    [TestCase(1, 1, 0, 2, 1, 0, Axis.X, 2)]
    [TestCase(0, 1, 1, 0, 2, 1, Axis.Y, 2)]
    [TestCase(1, 0, 1, 1, 0, 2, Axis.Z, 2)]
    [TestCase(1, 1, 1, 2, 1, 1, Axis.X, 2)]
    [TestCase(1, 1, 1, 1, 2, 1, Axis.Y, 2)]
    [TestCase(1, 1, 1, 1, 1, 2, Axis.Z, 2)]
    public void Scale_ScaleVector_ResultIsOk(double vx, double vy, double vz,
                                             double ex, double ey, double ez,
                                             Axis axis, double scaleFactor)
    {
        var v = new Vector3(vx, vy, vz);
        v.Scale(axis, scaleFactor);
        Assert.That(v, Is.EqualTo(new Vector3(ex, ey, ez)));
    }

    [TestCase(1, 0, 0, 1, 0, 0,           Axis.X, 30)]
    [TestCase(1, 0, 0, 0.8660254, 0, -.5, Axis.Y, 30)]
    [TestCase(1, 0, 0, 0.8660254, .5, 0,  Axis.Z, 30)]
    [TestCase(1, 0, 0, 1, 0, 0,           Axis.X, -30)]
    [TestCase(1, 0, 0, 0.8660254, 0, .5,  Axis.Y, -30)]
    [TestCase(1, 0, 0, 0.8660254, -.5, 0, Axis.Z, -30)]
    [TestCase(1, 0, 0, 1, 0, 0,           Axis.X, 60)]
    [TestCase(1, 0, 0, .5, 0, -0.8660254, Axis.Y, 60)]
    [TestCase(1, 0, 0, .5, 0.8660254, 0,  Axis.Z, 60)]
    [TestCase(1, 0, 0, 1, 0, 0,           Axis.X, -60)]
    [TestCase(1, 0, 0, .5, 0, 0.8660254,  Axis.Y, -60)]
    [TestCase(1, 0, 0, .5, -0.8660254, 0, Axis.Z, -60)]    
    [TestCase(0, 1, 0, 0, 0.8660254, .5,  Axis.X, 30)]
    [TestCase(0, 1, 0, 0, 1, 0,           Axis.Y, 30)]
    [TestCase(0, 1, 0, -.5, 0.8660254, 0, Axis.Z, 30)]
    [TestCase(0, 1, 0, 0, 0.8660254, -.5, Axis.X, -30)]
    [TestCase(0, 1, 0, 0, 1, 0,           Axis.Y, -30)]
    [TestCase(0, 1, 0, .5, 0.8660254, 0,  Axis.Z, -30)]
    [TestCase(0, 1, 0, 0, 0.5, .8660254,  Axis.X, 60)]
    [TestCase(0, 1, 0, 0, 1, 0,           Axis.Y, 60)]
    [TestCase(0, 1, 0, -.8660254, 0.5, 0, Axis.Z, 60)]
    [TestCase(0, 1, 0, 0, 0.5, -.8660254, Axis.X, -60)]
    [TestCase(0, 1, 0, 0, 1, 0,           Axis.Y, -60)]
    [TestCase(0, 1, 0, .8660254, 0.5, 0,  Axis.Z, -60)]
    [TestCase(0, 0, 1, 0, -0.5, .8660254, Axis.X, 30)]
    [TestCase(0, 0, 1, .5, 0, .8660254,   Axis.Y, 30)]
    [TestCase(0, 0, 1, 0, 0, 1,           Axis.Z, 30)]
    [TestCase(0, 0, 1, 0, .5, .8660254,   Axis.X, -30)]
    [TestCase(0, 0, 1, -.5, 0, .8660254,  Axis.Y, -30)]
    [TestCase(0, 0, 1, 0, 0, 1,           Axis.Z, -30)]
    [TestCase(0, 0, 1, 0, -.8660254, .5,  Axis.X, 60)]
    [TestCase(0, 0, 1, .8660254, 0, .5,   Axis.Y, 60)]
    [TestCase(0, 0, 1, 0, 0, 1,           Axis.Z, 60)]
    [TestCase(0, 0, 1, 0, .8660254, .5,   Axis.X, -60)]
    [TestCase(0, 0, 1, -.8660254, 0, .5,  Axis.Y, -60)]
    [TestCase(0, 0, 1, 0, 0, 1,           Axis.Z, -60)]
    public void Rotate_RotateVector_ResultIsOk(double vx, double vy, double vz,
                                               double ex, double ey, double ez,
                                               Axis axis, double angleDegree)
    {
        var v = new Vector3(vx, vy, vz);
        v.Rotate(axis, angleDegree);
        Assert.That(v, Is.EqualTo(new Vector3(ex, ey, ez)));
    }

    [TestCase(1, 1, 1, 2, 3 ,4)]
    [TestCase(1, 0, 0, 2, 2 ,3)]
    [TestCase(0, 1, 0, 1, 3 ,3)]
    [TestCase(0, 0, 1, 1, 2 ,4)]
    [TestCase(-1, -1, -1, 0, 1 ,2)]
    [TestCase(-1, 0, 0, 0, 2 ,3)]
    [TestCase(0, -1, 0, 1, 1 ,3)]
    [TestCase(0, 0, -1, 1, 2 ,2)]
    public void Translate_MoveOnVector_ResultIsCorrect(double dx, double dy, double dz,
                                                       double ex, double ey, double ez)
    {
        Vector3 v = new Vector3(1, 2, 3);
        v.Translate(new Vector3(dx, dy, dz));
        Assert.That(v, Is.EqualTo(new Vector3(ex, ey, ez)));
    }
}
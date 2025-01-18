namespace RayTracingTests;

class LightTest
{
    [TestCase(0, 0, 0, 1, 2, 3)]
    [TestCase(1, 1, 1, 0, 1, 2)]
    [TestCase(10, 10, 10, -9, -8, -7)]
    [TestCase(5, -2, -10, -4, 4, 13)]
    public void GetDirectionFrom_PointLight_ReturnsCorrectDirection(
        double px, double py, double pz,
        double rx, double ry, double rz
    )
    {
        var pl = new PointLight(new Vector3(),
                                new Vector3(),
                                new Vector3(1, 2, 3));
    
        Assert.That(pl.GetDirectionFrom(new Vector3(px, py, pz)),
                    Is.EqualTo(new Vector3(rx, ry, rz).Normalize()));
    }
    [TestCase(0, 0, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(10, 10, 10)]
    [TestCase(5, -2, -10)]
    public void GetDirectionFrom_DirectionLight_ReturnsCorrectDirection(
        double px, double py, double pz
    )
    {
        var dl = new DirectionLight(new Vector3(),
                                    new Vector3(),
                                    new Vector3(1, 2, 3));
    
        Assert.That(dl.GetDirectionFrom(new Vector3(px, py, pz)),
                    Is.EqualTo(new Vector3(-1, -2, -3).Normalize()));
    }


    [TestCase(0, 2, 3, 1)]
    [TestCase(1, 0, 3, 2)]
    [TestCase(1, 2, 0, 3)]
    [TestCase(1, 2, 3, 0)]
    [TestCase(1, 2, -3, 6)]
    public void GetDistanceFrom_PointLight_ReturnsCorrectDirection(
        double px, double py, double pz, double distance
    )
    {
        var pl = new PointLight(new Vector3(),
                                new Vector3(),
                                new Vector3(1, 2, 3));
    
        Assert.That(pl.GetDistanceFrom(new Vector3(px, py, pz)),
                    Is.EqualTo(distance));
    }

    [TestCase(0, 2, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(1, 2, 0)]
    [TestCase(1, 2, 3)]
    public void GetDistanceFrom_DirectionLight_ReturnsCorrectDirection(
        double px, double py, double pz
    )
    {
        var dl = new DirectionLight(new Vector3(),
                                    new Vector3(),
                                    new Vector3(1, 2, 3));
    
        Assert.True(double.IsPositiveInfinity(dl.GetDistanceFrom(new Vector3(px, py, pz))));
    }
}
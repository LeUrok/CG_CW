namespace RayTracingTests;

public class TriangleTests
{
    [Test]
    public void Intersection_RayDontIntersectTriangle_ReturnsNull()
    {
        var tr = new Triangle(new Vector3(1, 0, 0),
                              new Vector3(-1, 0, 0),
                              new Vector3(0, 1, 0));
        var ray = new Ray(new Vector3(0, 2, -5),
                          new Vector3(0, 0, 1));

        Assert.Null(tr.Intersect(ray).Point);
    }
    [Test]
    public void Intersection_IntersectSphere_ReturnNearestPoint()
    {
        var tr = new Triangle(new Vector3(1, 0, 0),
                              new Vector3(-1, 0, 0),
                              new Vector3(0, 1, 0));
        var ray = new Ray(new Vector3(0, 0.5, -5),
                          new Vector3(0, 0, 1));


        Assert.That(
            tr.Intersect(ray).Point, Is.EqualTo(new Vector3(0, 0.5, 0))
        );
    }

#region interpolate
    [TestCase(1, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 0, 1)]
    [TestCase(.5, 0, .5)]
    [TestCase(.5, .5, 0)]
    [TestCase(0, .5, .5)]
    [TestCase(.2, .3, .5)]
    [TestCase(.5, .2, .3)]
    [TestCase(.2, .5, .3)]
    public void Interpolate_XYZNotNull_ResultIsCorrect(double px, double py, double pz)
    {
        var t = new Triangle(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(px, py, pz)));
    }

    [TestCase(1, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 0, 0)]    
    [TestCase(.5, .5, 0)]
    [TestCase(.2, .3, 0)]
    [TestCase(.3, .2, 0)]
    [TestCase(.1, .1, 0)]
    public void Interpolate_ZIsNull_ResultIsCorrect(double px, double py, double pz)
    {
        var t = new Triangle(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 0)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 0);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(px, py, pz)));
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 0, 1)]    
    [TestCase(0, .5, .5)]
    [TestCase(0, .2, .3)]
    [TestCase(0, .3, .2)]
    [TestCase(0, .1, .1)]
    public void Interpolate_XIsNull_ResultIsCorrect(double px, double py, double pz)
    {
        var t = new Triangle(
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1)
        );

        var na = new Vector3(0, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(px, py, pz)));
    }

    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(0, 0, 1)]    
    [TestCase(.5, 0, .5)]
    [TestCase(.2, 0, .3)]
    [TestCase(.3, 0, .2)]
    [TestCase(.1, 0, .1)]
    public void Interpolate_YIsNull_ResultIsCorrect(double px, double py, double pz)
    {
        var t = new Triangle(
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 0, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(px, py, pz)));
    }

    [TestCase(0, 0, 0, 0, 1, 0)]
    [TestCase(1, 0, 0, 1, 0, 0)]
    [TestCase(0, 0, 1, 0, 0, 1)]    
    [TestCase(.5, 0, .5, .5, 0, .5)]
    [TestCase(.2, 0, .3, .2, .5, .3)]
    [TestCase(.3, 0, .2, .3, .5, .2)]
    [TestCase(.1, 0, .1, .1, .8, .1)]
    public void Interpolate_YIsNull_ResultIsCorrect(double px, double py, double pz,
                                                    double ex, double ey, double ez)
    {
        var t = new Triangle(
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(ex, ey, ez)));
    }

    [TestCase(0, 0, 0, 0, 0, 1)]
    [TestCase(1, 0, 0, 1, 0, 0)]
    [TestCase(0, 0, 1, 0, 0, 1)]    
    [TestCase(.5, .5, 0, .5, .5, 0)]
    [TestCase(.2, .3, 0, .2, .3, .5)]
    [TestCase(.3, .2, 0, .3, .2, .5)]
    [TestCase(.1, .1, 0, .1, .1, .8)]
    public void Interpolate_ZIsNull_ResultIsCorrect(double px, double py, double pz,
                                                    double ex, double ey, double ez)
    {
        var t = new Triangle(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 0)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(ex, ey, ez)));
    }


    [TestCase(0, 0, 0, 1, 0, 0)]
    [TestCase(1, 0, 0, 1, 0, 0)]
    [TestCase(0, 0, 1, 0, 0, 1)]    
    [TestCase(0, .5, .5,  0, .5, .5)]
    [TestCase(0, .2, .3, .5, .2, .3)]
    [TestCase(0, .3, .2, .5, .3, .2)]
    [TestCase(0, .1, .1, .8, .1, .1)]
    public void Interpolate_XIsNull_ResultIsCorrect(double px, double py, double pz,
                                                    double ex, double ey, double ez)
    {
        var t = new Triangle(
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1)
        );

        var na = new Vector3(1, 0, 0);
        var nb = new Vector3(0, 1, 0);
        var nc = new Vector3(0, 0, 1);

        var p = new Vector3(px, py, pz);
        
        Assert.That(t.Interpolate(p, na, nb, nc), Is.EqualTo(new Vector3(ex, ey, ez)));
    }

#endregion
}

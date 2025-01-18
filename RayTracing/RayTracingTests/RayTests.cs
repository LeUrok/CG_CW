namespace RayTracing;

public class RayTests
{
#region Intersect

    [TestCase(-1, -1, -1)]
    [TestCase(-1, 0, -1)]
    [TestCase(-1, 1, -1)]
    [TestCase(-1, 2, -1)]
    [TestCase(-1, 3, -1)]
    [TestCase(0, 3, -1)]
    [TestCase(1, 3, -1)]
    [TestCase(2, 3, -1)]
    [TestCase(3, 3, -1)]
    [TestCase(3, 2, -1)]
    [TestCase(3, 1, -1)]
    [TestCase(3, 0, -1)]
    [TestCase(3, -1, -1)]
    [TestCase(2, -1, -1)]
    [TestCase(1, -1, -1)]
    [TestCase(0, -1, -1)]

    [TestCase(0, 0, -1)]
    [TestCase(0, 1, -1)]
    [TestCase(0, 2, -1)]
    [TestCase(1, 2, -1)]
    [TestCase(1, 1, -1)]
    [TestCase(1, 0, -1)]
    [TestCase(2, 0, -1)]
    [TestCase(2, 1, -1)]
    [TestCase(2, 2, -1)]

    [TestCase(-1, -1, 0)]
    [TestCase(-1, 0,  0)]
    [TestCase(-1, 1,  0)]
    [TestCase(-1, 2,  0)]
    [TestCase(-1, 3,  0)]
    [TestCase(0, 3,   0)]
    [TestCase(1, 3,   0)]
    [TestCase(2, 3,   0)]
    [TestCase(3, 3,   0)]
    [TestCase(3, 2,   0)]
    [TestCase(3, 1,   0)]
    [TestCase(3, 0,   0)]
    [TestCase(3, -1,  0)]
    [TestCase(2, -1,  0)]
    [TestCase(1, -1,  0)]
    [TestCase(0, -1,  0)]
    
    [TestCase(-1, -1, 1)]
    [TestCase(-1, 0,  1)]
    [TestCase(-1, 1,  1)]
    [TestCase(-1, 2,  1)]
    [TestCase(-1, 3,  1)]
    [TestCase(0, 3,   1)]
    [TestCase(1, 3,   1)]
    [TestCase(2, 3,   1)]
    [TestCase(3, 3,   1)]
    [TestCase(3, 2,   1)]
    [TestCase(3, 1,   1)]
    [TestCase(3, 0,   1)]
    [TestCase(3, -1,  1)]
    [TestCase(2, -1,  1)]
    [TestCase(1, -1,  1)]
    [TestCase(0, -1,  1)]

    [TestCase(-1, -1, 2)]
    [TestCase(-1, 0,  2)]
    [TestCase(-1, 1,  2)]
    [TestCase(-1, 2,  2)]
    [TestCase(-1, 3,  2)]
    [TestCase(0, 3,   2)]
    [TestCase(1, 3,   2)]
    [TestCase(2, 3,   2)]
    [TestCase(3, 3,   2)]
    [TestCase(3, 2,   2)]
    [TestCase(3, 1,   2)]
    [TestCase(3, 0,   2)]
    [TestCase(3, -1,  2)]
    [TestCase(2, -1,  2)]
    [TestCase(1, -1,  2)]
    [TestCase(0, -1,  2)]

    [TestCase(-1, -1, 3)]
    [TestCase(-1, 0,  3)]
    [TestCase(-1, 1,  3)]
    [TestCase(-1, 2,  3)]
    [TestCase(-1, 3,  3)]
    [TestCase(0, 3,   3)]
    [TestCase(1, 3,   3)]
    [TestCase(2, 3,   3)]
    [TestCase(3, 3,   3)]
    [TestCase(3, 2,   3)]
    [TestCase(3, 1,   3)]
    [TestCase(3, 0,   3)]
    [TestCase(3, -1,  3)]
    [TestCase(2, -1,  3)]
    [TestCase(1, -1,  3)]
    [TestCase(0, -1,  3)]

    [TestCase(0, 0, 3)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 3)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(2, 0, 3)]
    [TestCase(2, 1, 3)]
    [TestCase(2, 2, 3)]
    public void Intersect_IntersectsBoundingBox_ReturnTrue(
        double rsx, double rsy, double rsz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = new Vector3(1, 1, 1) - pos;

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.True(ray.Intersect(bb));
    }

    [TestCase(-1, -1, -1)]
    [TestCase(-1, 0, -1)]
    [TestCase(-1, 1, -1)]
    [TestCase(-1, 2, -1)]
    [TestCase(-1, 3, -1)]
    [TestCase(0, 3, -1)]
    [TestCase(1, 3, -1)]
    [TestCase(2, 3, -1)]
    [TestCase(3, 3, -1)]
    [TestCase(3, 2, -1)]
    [TestCase(3, 1, -1)]
    [TestCase(3, 0, -1)]
    [TestCase(3, -1, -1)]
    [TestCase(2, -1, -1)]
    [TestCase(1, -1, -1)]
    [TestCase(0, -1, -1)]

    [TestCase(0, 0, -1)]
    [TestCase(0, 1, -1)]
    [TestCase(0, 2, -1)]
    [TestCase(1, 2, -1)]
    [TestCase(1, 1, -1)]
    [TestCase(1, 0, -1)]
    [TestCase(2, 0, -1)]
    [TestCase(2, 1, -1)]
    [TestCase(2, 2, -1)]

    [TestCase(-1, -1, 0)]
    [TestCase(-1, 0,  0)]
    [TestCase(-1, 1,  0)]
    [TestCase(-1, 2,  0)]
    [TestCase(-1, 3,  0)]
    [TestCase(0, 3,   0)]
    [TestCase(1, 3,   0)]
    [TestCase(2, 3,   0)]
    [TestCase(3, 3,   0)]
    [TestCase(3, 2,   0)]
    [TestCase(3, 1,   0)]
    [TestCase(3, 0,   0)]
    [TestCase(3, -1,  0)]
    [TestCase(2, -1,  0)]
    [TestCase(1, -1,  0)]
    [TestCase(0, -1,  0)]
    
    [TestCase(-1, -1, 1)]
    [TestCase(-1, 0,  1)]
    [TestCase(-1, 1,  1)]
    [TestCase(-1, 2,  1)]
    [TestCase(-1, 3,  1)]
    [TestCase(0, 3,   1)]
    [TestCase(1, 3,   1)]
    [TestCase(2, 3,   1)]
    [TestCase(3, 3,   1)]
    [TestCase(3, 2,   1)]
    [TestCase(3, 1,   1)]
    [TestCase(3, 0,   1)]
    [TestCase(3, -1,  1)]
    [TestCase(2, -1,  1)]
    [TestCase(1, -1,  1)]
    [TestCase(0, -1,  1)]

    [TestCase(-1, -1, 2)]
    [TestCase(-1, 0,  2)]
    [TestCase(-1, 1,  2)]
    [TestCase(-1, 2,  2)]
    [TestCase(-1, 3,  2)]
    [TestCase(0, 3,   2)]
    [TestCase(1, 3,   2)]
    [TestCase(2, 3,   2)]
    [TestCase(3, 3,   2)]
    [TestCase(3, 2,   2)]
    [TestCase(3, 1,   2)]
    [TestCase(3, 0,   2)]
    [TestCase(3, -1,  2)]
    [TestCase(2, -1,  2)]
    [TestCase(1, -1,  2)]
    [TestCase(0, -1,  2)]

    [TestCase(-1, -1, 3)]
    [TestCase(-1, 0,  3)]
    [TestCase(-1, 1,  3)]
    [TestCase(-1, 2,  3)]
    [TestCase(-1, 3,  3)]
    [TestCase(0, 3,   3)]
    [TestCase(1, 3,   3)]
    [TestCase(2, 3,   3)]
    [TestCase(3, 3,   3)]
    [TestCase(3, 2,   3)]
    [TestCase(3, 1,   3)]
    [TestCase(3, 0,   3)]
    [TestCase(3, -1,  3)]
    [TestCase(2, -1,  3)]
    [TestCase(1, -1,  3)]
    [TestCase(0, -1,  3)]

    [TestCase(0, 0, 3)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 3)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(2, 0, 3)]
    [TestCase(2, 1, 3)]
    [TestCase(2, 2, 3)]
    public void Intersect_NotIntersectsBoundingBox_ReturnTrue(
        double rsx, double rsy, double rsz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = pos - new Vector3(1, 1, 1);

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.False(ray.Intersect(bb));
    }

    [TestCase(-1, -1, -1, 0, 1, 0)]
    [TestCase(-1, -1, -1, 1, 0, 0)]
    [TestCase(-1, -1, -1, 0, 0, 1)]
    public void Intersect_NotIntersectsParallelBox_ReturnTrue(
        double rsx, double rsy, double rsz,
        double rdx, double rdy, double rdz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = new Vector3(rdx, rdy, rdz);

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.False(ray.Intersect(bb));
    }

#endregion

#region Reflect

    [TestCase(0,  -1,    0,    0,     1,     0)]
    [TestCase(0,   1,    0,    0,     -1,    0)]
    [TestCase(.5,  -.5,  0,    .5,    .5,    0)]
    [TestCase(0,   -.5,  .5,   0,     .5,    .5)]
    [TestCase(.5,  -.5,  .5,   .5,    .5,    .5)]
    [TestCase(.5,  .5,   0,    .5,    -.5,   0)]
    [TestCase(0,   .5,   .5,   0,     -.5,   .5)]
    [TestCase(.5,  .5,   .5,   .5,    -.5,   .5)]
    [TestCase(.5,   0,   0,    .5,      0,   0)]
    [TestCase(0,    0,   .5,   0,       0,   .5)]
    [TestCase(.5,   0,   .5,   .5,      0,   .5)]
    public void Reflect_UpNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                 double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(0, 1, 0));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

    [TestCase(0,  -1,    0,    0,     1,     0)]
    [TestCase(0,   1,    0,    0,     -1,    0)]
    [TestCase(.5,  -.5,  0,    .5,    .5,    0)]
    [TestCase(0,   -.5,  .5,   0,     .5,    .5)]
    [TestCase(.5,  -.5,  .5,   .5,    .5,    .5)]
    [TestCase(.5,  .5,   0,    .5,    -.5,   0)]
    [TestCase(0,   .5,   .5,   0,     -.5,   .5)]
    [TestCase(.5,  .5,   .5,   .5,    -.5,   .5)]
    [TestCase(.5,   0,   0,    .5,      0,   0)]
    [TestCase(0,    0,   .5,   0,       0,   .5)]
    [TestCase(.5,   0,   .5,   .5,      0,   .5)]
    public void Reflect_DownNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                   double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(0, -1, 0));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

    [TestCase(-1,    0,     0,    1,     0,     0)]
    [TestCase(1,     0,     0,    -1,    0,     0)]
    [TestCase(-.5,   .5,    0,    .5,    .5,    0)]
    [TestCase(-.5,   0,     .5,   .5,    0,     .5)]
    [TestCase(-.5,   .5,    .5,   .5,    .5,    .5)]
    [TestCase(.5,    .5,    0,    -.5,   .5,    0)]
    [TestCase(.5,    0,     .5,   -.5,   0,     .5)]
    [TestCase(.5,    .5,    .5,   -.5,   .5,    .5)]
    [TestCase( 0,    .5,    0,      0,   .5,    0)]
    [TestCase( 0,    0,     .5,     0,   0,     .5)]
    [TestCase( 0,    .5,    .5,     0,   .5,    .5)]
    public void Reflect_LeftNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                   double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(1, 0, 0));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

    [TestCase(-1,    0,     0,    1,     0,     0)]
    [TestCase(1,     0,     0,    -1,    0,     0)]
    [TestCase(-.5,   .5,    0,    .5,    .5,    0)]
    [TestCase(-.5,   0,     .5,   .5,    0,     .5)]
    [TestCase(-.5,   .5,    .5,   .5,    .5,    .5)]
    [TestCase(.5,    .5,    0,    -.5,   .5,    0)]
    [TestCase(.5,    0,     .5,   -.5,   0,     .5)]
    [TestCase(.5,    .5,    .5,   -.5,   .5,    .5)]
    [TestCase( 0,    .5,    0,      0,   .5,    0)]
    [TestCase( 0,    0,     .5,     0,   0,     .5)]
    [TestCase( 0,    .5,    .5,     0,   .5,    .5)]
    public void Reflect_RightNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                   double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(-1, 0, 0));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

    [TestCase(0,     0,    -1,    0,     0 ,      1)]
    [TestCase(0,     0,    1,     0,     0 ,     -1)]
    [TestCase(.5,    0,    -.5,   .5,    0 ,     .5)]
    [TestCase(0,     .5,   -.5,   0,     .5,     .5)]
    [TestCase(.5,    .5,   -.5,   .5,    .5,     .5)]
    [TestCase(.5,    0,    .5,    .5,    0 ,    -.5)]
    [TestCase(0,     .5,   .5,    0,     .5,    -.5)]
    [TestCase(.5,    .5,   .5,    .5,    .5,    -.5)]
    [TestCase(.5,    0,     0,    .5,    0 ,      0)]
    [TestCase(0,     .5,    0,    0,     .5,      0)]
    [TestCase(.5,    .5,    0,    .5,    .5,      0)]
    public void Reflect_FrontNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                   double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(0, 0, 1));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

    [TestCase(0,     0,    -1,    0,     0 ,      1)]
    [TestCase(0,     0,    1,     0,     0 ,     -1)]
    [TestCase(.5,    0,    -.5,   .5,    0 ,     .5)]
    [TestCase(0,     .5,   -.5,   0,     .5,     .5)]
    [TestCase(.5,    .5,   -.5,   .5,    .5,     .5)]
    [TestCase(.5,    0,    .5,    .5,    0 ,    -.5)]
    [TestCase(0,     .5,   .5,    0,     .5,    -.5)]
    [TestCase(.5,    .5,   .5,    .5,    .5,    -.5)]
    [TestCase(.5,    0,     0,    .5,    0 ,      0)]
    [TestCase(0,     .5,    0,    0,     .5,      0)]
    [TestCase(.5,    .5,    0,    .5,    .5,      0)]
    public void Reflect_BackNormal_ResultIsCorrect(double rdx, double rdy, double rdz,
                                                   double exx, double exy, double exz)
    {
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var reflection = ray.Reflect(new Vector3(), new Vector3(0, 0, -1));
        Assert.That(reflection.Direction, Is.EqualTo(new Vector3(exx, exy, exz).Normalize()));
    }

#endregion

#region Refract
    [TestCase(0, -1, -1)]
    [TestCase(0, -1, -6)]
    [TestCase(0, -1, -4)]
    [TestCase(0, -1, -2)]
    [TestCase(0, -1, 0)]
    [TestCase(0, -1, 1)]
    [TestCase(0, -1, 2)]
    [TestCase(0, -1, 4)]
    [TestCase(0, -1, 6)]

    [TestCase(-6 , -1, 0)]
    [TestCase(-4 , -1, 0)]
    [TestCase(-2 , -1, 0)]
    [TestCase(-1 , -1, 0)]
    [TestCase(0 , -1, 0)]
    [TestCase(1  , -1, 0)]
    [TestCase(2  , -1, 0)]
    [TestCase(4  , -1, 0)]
    [TestCase(6  , -1, 0)]
    public void Refract_RefractSomeRay1to102_ResultIsCorrect(
        double rdx, double rdy, double rdz
    ) {
        var dens = 1.01;
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var normal = new Vector3(0, 1, 0);
        var refracted = ray.Refract(new Vector3(), normal, dens, 1);
        Assert.That(Math.Abs(refracted!.Direction.Cross(normal).Length * dens - ray.Direction.Cross(normal).Length), Is.LessThan(.000001));
    }

    [TestCase(0, -1, -1)]
    [TestCase(0, -1, -6)]
    [TestCase(0, -1, -4)]
    [TestCase(0, -1, -2)]
    [TestCase(0, -1, 0)]
    [TestCase(0, -1, 1)]
    [TestCase(0, -1, 2)]
    [TestCase(0, -1, 4)]
    [TestCase(0, -1, 6)]

    [TestCase(-6 , -1, 0)]
    [TestCase(-4 , -1, 0)]
    [TestCase(-2 , -1, 0)]
    [TestCase(-1 , -1, 0)]
    [TestCase(0 , -1, 0)]
    [TestCase(1  , -1, 0)]
    [TestCase(2  , -1, 0)]
    [TestCase(4  , -1, 0)]
    [TestCase(6  , -1, 0)]
    public void Refract_RefractSomeRay101to1_ResultIsCorrect(
        double rdx, double rdy, double rdz
    ) {
        var dens = 1.01;
        var ray = new Ray(new Vector3(), new Vector3(rdx, rdy, rdz));
        var normal = new Vector3(0, -1, 0);
        var refracted = ray.Refract(new Vector3(), normal, 1, dens);
        Assert.That(Math.Abs(refracted!.Direction.Cross(normal).Length - ray.Direction.Cross(normal).Length * dens), Is.LessThan(.000001));
    }

#endregion

}
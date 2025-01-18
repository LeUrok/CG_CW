namespace RayTracingTests;


class MeshIntersectionTests
{
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalUp_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.NotNull(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalDown_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.NotNull(id.Point);
    }

    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalUp_PNIsOk(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Normal, Is.EqualTo(new Vector3(0, 1, 0)));
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalDown_PNIsOk(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Normal, Is.EqualTo(new Vector3(0, -1, 0)));
    }
    

    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_RayDirectOutIntersectionNormalUp_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = pos - sur_pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_RayDirectOutIntersectionNormalDown_Intersect (
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = pos - sur_pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckReflectionIntersectionNormalUp_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir).Reflect(sur_pos, normal);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckReflectedIntersectionNormalDown_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir).Reflect(sur_pos, normal);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_TwiTrianglesIntersectionNormalUp_IntersectNearest(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, -.1, 0));
        mesh.AddVertex(new Vector3(0, -.1, 10));
        mesh.AddVertex(new Vector3(-10, -.1, -10));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(0)));
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_TwoTriangles_IntersectNearest(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, .1, 0));
        mesh.AddVertex(new Vector3(0, .1, 10));
        mesh.AddVertex(new Vector3(-10, .1, -10));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(0)));
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_ReflectedIntersectionNormalUp_IntersectDistant(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal, 1.01, 1);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, -.1, 0));
        mesh.AddVertex(new Vector3(0, -.1, 10));
        mesh.AddVertex(new Vector3(-10, -.1, -10));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);

        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(1)));
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_IntersectRefractedNormalDown_IntersectDistant(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal, 1.01, 1);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, .1, 0));
        mesh.AddVertex(new Vector3(0, .1, 10));
        mesh.AddVertex(new Vector3(-10, .1, -10));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);

        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(1)));
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_TwoRefractedReflectIntersectionNormalUp_IntersectNearest(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal1 = new Vector3(0, 1, 0);
        var normal2 = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal1, 1.01, 1);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, -.1, 0));
        mesh.AddVertex(new Vector3(0, -.1, 10));
        mesh.AddVertex(new Vector3(-10, -.1, -10));

        mesh.AddNormal(normal1);
        mesh.AddNormal(normal2);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 1, Nb = 1, Nc = 1});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);
        var refl = ray!.Reflect(id.Point!, normal2, 1, 1.01);
        id = mesh.Intersect(refl);

        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(0)));
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_IntersectRefractedReflectNormalDown_IntersectNearest(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal1 = new Vector3(0, -1, 0);
        var normal2 = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal1, 1.01, 1);        
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, .1, 0));
        mesh.AddVertex(new Vector3(0, .1, 10));
        mesh.AddVertex(new Vector3(-10, .1, -10));

        mesh.AddNormal(normal1);
        mesh.AddNormal(normal2);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 1, Nb = 1, Nc = 1});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);
        var refl = ray!.Reflect(id.Point!, normal2, 1, 1.01);

        id = mesh.Intersect(refl);
        Assert.That(id.Triangle, Is.SameAs(mesh.GetTriangle(0)));
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_TwoRefractionIntersectionNormalUp_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal1 = new Vector3(0, 1, 0);
        var normal2 = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal1, 1.01, 1);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, -.1, 0));
        mesh.AddVertex(new Vector3(0, -.1, 10));
        mesh.AddVertex(new Vector3(-10, -.1, -10));

        mesh.AddNormal(normal1);
        mesh.AddNormal(normal2);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 1, Nb = 1, Nc = 1});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);
        var refr = ray!.Refract(id.Point!, normal2, 1, 1.01);
        id = mesh.Intersect(refr!);

        Assert.IsNull(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_IntersectTwoRefractionNormalDown_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal1 = new Vector3(0, -1, 0);
        var normal2 = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir).Refract(sur_pos, normal1, 1.01, 1);        
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(10, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 10));
        mesh.AddVertex(new Vector3(-10, 0, -10));

        mesh.AddVertex(new Vector3(10, .1, 0));
        mesh.AddVertex(new Vector3(0, .1, 10));
        mesh.AddVertex(new Vector3(-10, .1, -10));

        mesh.AddNormal(normal1);
        mesh.AddNormal(normal2);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});
        mesh.AddFace(new Face { Va = 3, Vb = 4, Vc = 5, Na = 1, Nb = 1, Nc = 1});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray!);
        var refr = ray!.Refract(id.Point!, normal2, 1, 1.01);

        id = mesh.Intersect(refr!);
        Assert.IsNull(id.Point);
    }
}
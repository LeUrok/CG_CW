namespace RayTracingTests;

class CameraTests
{
    [Test]
    public void GetScreen_DefaultCamera_ScreenIsCorrect()
    {
        Camera camera = new Camera();
        Screen screen = camera.GetScreen(600, 400);

        Assert.That(screen.LeftUp, Is.EqualTo(new Vector3(1, 9.0 / 16, 1)));
        Assert.That(screen.LeftDown, Is.EqualTo(new Vector3(1, -9.0 / 16, 1)));
        Assert.That(screen.RightUp, Is.EqualTo(new Vector3(-1, 9.0 / 16, 1)));
    }

    [Test]
    public void GetScreen_TopDownCamera_ScreenIsCorrect()
    {
        Camera camera = new Camera
        {
            ViewPoint = new Vector3(0, -1, 0),
            Up = new Vector3(0, 0, 1),
        };
        Screen screen = camera.GetScreen(600, 400);

        Assert.That(screen.LeftUp, Is.EqualTo(new Vector3(1, -1 ,9.0 / 16)));
        Assert.That(screen.LeftDown, Is.EqualTo(new Vector3(1, -1, -9.0 / 16)));
        Assert.That(screen.RightUp, Is.EqualTo(new Vector3(-1, -1, 9.0 / 16)));
    }

    [Test]
    public void GetScreen_45AngleCamera_ScreenIsCorrect()
    {
        Camera camera = new Camera
        {
            ViewPoint = new Vector3(0, 0, 1),
            Up = new Vector3(0, 1, 1),
            Position = new Vector3(0, 1, 0),
            Aspect = 1
        };
        Screen screen = camera.GetScreen(600, 400);

        Assert.That(screen.LeftUp, Is.EqualTo(new Vector3(1, 1 ,Math.Sqrt(2))));
        Assert.That(screen.LeftDown, Is.EqualTo(new Vector3(1, 1 - Math.Sqrt(2), 0)));
        Assert.That(screen.RightUp, Is.EqualTo(new Vector3(-1, 1 ,Math.Sqrt(2))));
    }
}
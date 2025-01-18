namespace RayTracingTests;

public class ScreenTests
{
    [Test]
    public void Points_CreateSomeScreen_ReturnsCorrectArrayOfPoints()
    {
        Screen screen = new Screen { Height = 3
                                   , Width = 4
                                   , LeftUp = new Vector3()
                                   , LeftDown = new Vector3(0, -6, 0)
                                   , RightUp = new Vector3(4, 0, 0)};
        var points = screen.Points;

        var expected = new Vector3[,] {
            { new Vector3(0.5, -1, 0), new Vector3(1.5, -1, 0), new Vector3(2.5, -1, 0), new Vector3(3.5, -1, 0) },
            { new Vector3(0.5, -3, 0), new Vector3(1.5, -3, 0), new Vector3(2.5, -3, 0), new Vector3(3.5, -3, 0) },
            { new Vector3(0.5, -5, 0), new Vector3(1.5, -5, 0), new Vector3(2.5, -5, 0), new Vector3(3.5, -5, 0) },
        };

        Assert.That(points, Is.EqualTo(expected));
    }
}

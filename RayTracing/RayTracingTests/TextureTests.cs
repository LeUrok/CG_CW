using RayTracing.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracingTests;

class TextureTests
{
    [TestCase(.25, .25,  0)]
    [TestCase(.25, .75,  1)]
    [TestCase(.75, .25, 10)]
    [TestCase(.75, .75, 11)]

    [TestCase(1.25, 1.25,  0)]
    [TestCase(1.25, 1.75,  1)]
    [TestCase(1.75, 1.25, 10)]
    [TestCase(1.75, 1.75, 11)]

    [TestCase(-1.25, 1.25,  0)]
    [TestCase(-1.25, 1.75,  1)]
    [TestCase(-1.75, 1.25, 10)]
    [TestCase(-1.75, 1.75, 11)]

    [TestCase(1.25, -1.25,  0)]
    [TestCase(1.25, -1.75,  1)]
    [TestCase(1.75, -1.25, 10)]
    [TestCase(1.75, -1.75, 11)]

    [TestCase(-1.25, -1.25,  0)]
    [TestCase(-1.25, -1.75,  1)]
    [TestCase(-1.75, -1.25, 10)]
    [TestCase(-1.75, -1.75, 11)]
    public void GetColor_RepeatWrapping_ReturnsCorrectColor(
        double u, double v, byte c
    )
    {
        Image<Rgb24> image = new Image<Rgb24>(2, 2);
        for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                image[x, y] = new Rgb24((byte)(y + x * 10),
                                        (byte)(y + x * 10),
                                        (byte)(y + x * 10));
        var texture = Texture.FromImage(image);
        texture.Wrapping = TextureWrapping.Repeat;

        Assert.That(texture.GetColor(u, v), Is.EqualTo(new Rgb24(c, c, c).ToVector3()));
    }

    [TestCase(.25, .25,  0)]
    [TestCase(.25, .75,  1)]
    [TestCase(.75, .25, 10)]
    [TestCase(.75, .75, 11)]

    [TestCase(1.25, 1.25, 11)]
    [TestCase(1.25, 1.75, 10)]
    [TestCase(1.75, 1.25,  1)]
    [TestCase(1.75, 1.75,  0)]

    [TestCase(-1.25, 1.25, 11)]
    [TestCase(-1.25, 1.75, 10)]
    [TestCase(-1.75, 1.25,  1)]
    [TestCase(-1.75, 1.75,  0)]

    [TestCase(1.25, -1.25, 11)]
    [TestCase(1.25, -1.75, 10)]
    [TestCase(1.75, -1.25,  1)]
    [TestCase(1.75, -1.75,  0)]

    [TestCase(-1.25, -1.25, 11)]
    [TestCase(-1.25, -1.75, 10)]
    [TestCase(-1.75, -1.25,  1)]
    [TestCase(-1.75, -1.75,  0)]

    [TestCase(2.25, 2.25,  0)]
    [TestCase(2.25, 2.75,  1)]
    [TestCase(2.75, 2.25, 10)]
    [TestCase(2.75, 2.75, 11)]

    [TestCase(-2.25, 2.25,  0)]
    [TestCase(-2.25, 2.75,  1)]
    [TestCase(-2.75, 2.25, 10)]
    [TestCase(-2.75, 2.75, 11)]

    [TestCase(2.25, -2.25,  0)]
    [TestCase(2.25, -2.75,  1)]
    [TestCase(2.75, -2.25, 10)]
    [TestCase(2.75, -2.75, 11)]

    [TestCase(-2.25, -2.25,  0)]
    [TestCase(-2.25, -2.75,  1)]
    [TestCase(-2.75, -2.25, 10)]
    [TestCase(-2.75, -2.75, 11)]
    public void GetColor_MirroredRepeatWrapping_ReturnsCorrectColor(
        double u, double v, byte c
    )
    {
        Image<Rgb24> image = new Image<Rgb24>(2, 2);
        for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                image[x, y] = new Rgb24((byte)(y + x * 10),
                                        (byte)(y + x * 10),
                                        (byte)(y + x * 10));
        var texture = Texture.FromImage(image);
        texture.Wrapping = TextureWrapping.MirroredRepeat;

        Assert.That(texture.GetColor(u, v), Is.EqualTo(new Rgb24(c, c, c).ToVector3()));
    }

    [TestCase(.25, .25,  0)]
    [TestCase(.25, .75,  1)]
    [TestCase(.75, .25, 10)]
    [TestCase(.75, .75, 11)]

    [TestCase(1.25, 1.25, 255)]
    [TestCase(1.25, 1.75, 255)]
    [TestCase(1.75, 1.25, 255)]
    [TestCase(1.75, 1.75, 255)]

    [TestCase(-1.25, 1.25, 255)]
    [TestCase(-1.25, 1.75, 255)]
    [TestCase(-1.75, 1.25, 255)]
    [TestCase(-1.75, 1.75, 255)]

    [TestCase(1.25, -1.25, 255)]
    [TestCase(1.25, -1.75, 255)]
    [TestCase(1.75, -1.25, 255)]
    [TestCase(1.75, -1.75, 255)]

    [TestCase(-1.25, -1.25, 255)]
    [TestCase(-1.25, -1.75, 255)]
    [TestCase(-1.75, -1.25, 255)]
    [TestCase(-1.75, -1.75, 255)]
    public void GetColor_ClampToBorderWrapping_ReturnsCorrectColor(
        double u, double v, byte c
    )
    {
        Image<Rgb24> image = new Image<Rgb24>(2, 2);
        for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                image[x, y] = new Rgb24((byte)(y + x * 10),
                                        (byte)(y + x * 10),
                                        (byte)(y + x * 10));
        var texture = Texture.FromImage(image);
        texture.Wrapping = TextureWrapping.ClampToBorder;
        texture.BorderColor = new Vector3(255, 255, 255);

        Assert.That(texture.GetColor(u, v), Is.EqualTo(new Rgb24(c, c, c).ToVector3()));
    }


    [TestCase(.25, .25,  0)]
    [TestCase(.25, .75,  1)]
    [TestCase(.75, .25, 10)]
    [TestCase(.75, .75, 11)]

    [TestCase(1.25, 1.25, 11)]
    [TestCase(1.25, 1.75, 11)]
    [TestCase(1.75, 1.25, 11)]
    [TestCase(1.75, 1.75, 11)]

    [TestCase(-1.25, 1.25, 1)]
    [TestCase(-1.25, 1.75, 1)]
    [TestCase(-1.75, 1.25, 1)]
    [TestCase(-1.75, 1.75, 1)]

    [TestCase(1.25, -1.25, 10)]
    [TestCase(1.25, -1.75, 10)]
    [TestCase(1.75, -1.25, 10)]
    [TestCase(1.75, -1.75, 10)]

    [TestCase(-1.25, -1.25, 0)]
    [TestCase(-1.25, -1.75, 0)]
    [TestCase(-1.75, -1.25, 0)]
    [TestCase(-1.75, -1.75, 0)]

    [TestCase(1.25, .25, 10)]
    [TestCase(1.25, .75, 11)]
    [TestCase(1.75, .25, 10)]
    [TestCase(1.75, .75, 11)]

    [TestCase(-1.25, .25, 0)]
    [TestCase(-1.25, .75, 1)]
    [TestCase(-1.75, .25, 0)]
    [TestCase(-1.75, .75, 1)]

    [TestCase(.25, -1.25,  0)]
    [TestCase(.25, -1.75,  0)]
    [TestCase(.75, -1.25, 10)]
    [TestCase(.75, -1.75, 10)]

    [TestCase(.25, 1.25,  1)]
    [TestCase(.25, 1.75,  1)]
    [TestCase(.75, 1.25, 11)]
    [TestCase(.75, 1.75, 11)]
    public void GetColor_ClampToEdgeWrapping_ReturnsCorrectColor(
        double u, double v, byte c
    )
    {
        Image<Rgb24> image = new Image<Rgb24>(2, 2);
        for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                image[x, y] = new Rgb24((byte)(y + x * 10),
                                        (byte)(y + x * 10),
                                        (byte)(y + x * 10));
        var texture = Texture.FromImage(image);
        texture.Wrapping = TextureWrapping.ClampToEdge;

        Assert.That(texture.GetColor(u, v), Is.EqualTo(new Rgb24(c, c, c).ToVector3()));
    }
}
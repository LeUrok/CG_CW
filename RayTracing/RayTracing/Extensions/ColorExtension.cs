using System.Drawing;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracing.Extensions;

public static class ColorExtensions
{
    public static Vector3 ToVector3(this Rgb24 color)
    {
        return new Vector3(color.R, color.G, color.B);
    }
}
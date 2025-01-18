namespace RayTracing;

public class TextureUV
{
    public double U { get; private set; }
    public double V { get; private set; }

    public TextureUV(double u, double v)
    {
        U = u;
        V = v;
    }

    public static TextureUV operator-(TextureUV lo, TextureUV ro)
    {
        return new TextureUV(lo.U - ro.U, lo.V - ro.V);
    }
    public static TextureUV operator+(TextureUV lo, TextureUV ro)
    {
        return new TextureUV(lo.U + ro.U, lo.V + ro.V);
    }
    public static TextureUV operator*(TextureUV lo, double ro)
    {
        return new TextureUV(lo.U * ro, lo.V * ro);
    }
}

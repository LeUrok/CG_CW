namespace RayTracing;

public class Triangle
{
    private const double Eps = 0.00001;

    public Vector3 A { get; set; }
    public Vector3 B { get; set; }
    public Vector3 C { get; set; }

    public Vector3? Na { get; set; } = null;
    public Vector3? Nb { get; set; } = null;
    public Vector3? Nc { get; set; } = null;

    public TextureUV? Ta { get; set; } = null;
    public TextureUV? Tb { get; set; } = null;
    public TextureUV? Tc { get; set; } = null;

    public Triangle(Vector3 a, Vector3 b, Vector3 c)
    {
        A = a;
        B = b;
        C = c;
    }
    public Triangle(Vector3 a, Vector3 b, Vector3 c,
                    Vector3 na, Vector3 nb, Vector3 nc)
    {
        A = a;
        B = b;
        C = c;

        Na = na;
        Nb = nb;
        Nc = nc;
    }
    public Triangle(Vector3 a, Vector3 b, Vector3 c,
                    TextureUV ta, TextureUV tb, TextureUV tc)
    {
        A = a;
        B = b;
        C = c;

        Ta = ta;
        Tb = tb;
        Tc = tc;
    }
    public Triangle(Vector3 a, Vector3 b, Vector3 c,
                    Vector3 na, Vector3 nb, Vector3 nc,
                    TextureUV ta, TextureUV tb, TextureUV tc)
    {
        A = a;
        B = b;
        C = c;

        Na = na;
        Nb = nb;
        Nc = nc;

        Ta = ta;
        Tb = tb;
        Tc = tc;
    }

    public IntersectInfo Intersect(Ray ray)
    {
        var e1 = B - A;
        var e2 = C - A;

        var pvec = ray.Direction.Cross(e2);
        var det = e1.Dot(pvec);

        if(Math.Abs(det) < Eps)
            return new IntersectInfo();
        
        var inv_det = 1 / det;
        var tvec = ray.Start - A;
        var u = tvec.Dot(pvec) * inv_det;
        if(u < 0 || u > 1)
            return new IntersectInfo();
        
        var qvec = tvec.Cross(e1);
        var v = ray.Direction.Dot(qvec) * inv_det;
        var distance = e2.Dot(qvec) * inv_det;
        if(v < 0 || u + v > 1 || distance < 0)
            return new IntersectInfo();
        
        var point = ray.Start + ray.Direction * distance;

        return new IntersectInfo {
            Point = point,
            Distance = distance,
            Triangle = this,
            Normal = GetNormal(point),
            TextureUV = GetTextureUV(point)
        };
    }

    public void Translate(Vector3 on)
    {
        A += on;
        B += on;
        C += on;
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        var matrix = Transform.GetRotation(axis, angleDegree);
        A *= matrix;
        B *= matrix;
        C *= matrix;
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        A.Scale(axis, scaleFactor);
        B.Scale(axis, scaleFactor);
        C.Scale(axis, scaleFactor);
    }

    public Vector3? GetNormal(Vector3 point)
    {
        if(Na is null || Nb is null || Nc is null)
            return null;
        return Interpolate(point, Na, Nb, Nc);
    }
    public TextureUV GetTextureUV(Vector3 point)
    {
        if(Ta is null || Tb is null || Tc is null)
            return new TextureUV(0, 0);
        return Interpolate(point, Ta, Tb, Tc);
    }

    public Vector3 Interpolate(Vector3 point,
                               Vector3 aVal,
                               Vector3 bVal,
                               Vector3 cVal)
    {
        var uv = GetUV(point, aVal, bVal, cVal);
            
        var ab_d = bVal - aVal;
        var ac_d = cVal - aVal;
                
        aVal += (ab_d * uv.Item1) + (ac_d * uv.Item2);
        return aVal;
    }
    public TextureUV Interpolate(Vector3 point,
                                 TextureUV aVal,
                                 TextureUV bVal,
                                 TextureUV cVal)
    {
        var uv = GetUV(point, aVal, bVal, cVal);
            
        var ab_d = bVal - aVal;
        var ac_d = cVal - aVal;
                
        return aVal += (ab_d * uv.Item1) + (ac_d * uv.Item2);
    }

    private Tuple<double, double> GetUV<T>(
        Vector3 point, T aVal, T bVal, T cVal
    )
    {
        var ab = B - A;
        var ac = C - A;
        var w = point - A;
        
        double u = 0;
        double v = 0;

        var det1 = ab.X * ac.Y - ac.X * ab.Y;
        var det2 = ab.X * ac.Z - ac.X * ab.Z;
        var det3 = ab.Y * ac.Z - ac.Y * ab.Z;
        if (Math.Abs(det1) > Eps)
        {
            u = (w.X * ac.Y - w.Y * ac.X) / det1;
            v = (ab.X * w.Y - ab.Y * w.X) / det1;
        }
        else if (Math.Abs(det2) > Eps)
        {            
            u = (w.X * ac.Z - w.Z * ac.X) / det2;
            v = (ab.X * w.Z - ab.Z * w.X) / det2;
        }
        else
        {
            u = (w.Y * ac.Z - w.Z * ac.Y) / det3;
            v = (ab.Y * w.Z - ab.Z * w.Y) / det3;
        }
        
        return Tuple.Create(u, v);
    }

    public override string ToString()
    {
        return $"[{A}, {B}, {C}]";
    }
}
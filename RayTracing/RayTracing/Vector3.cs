namespace RayTracing;

public class Vector3 : ITransformable
{
    private const double EqualityEpsilon = 1e-6;

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    
    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
    public double LengthSqr => X * X + Y * Y + Z * Z;

    public Vector3(double x = 0, double y = 0, double z = 0)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 operator+(Vector3 lo, Vector3 ro)
    {
        return new Vector3(lo.X + ro.X, lo.Y + ro.Y, lo.Z + ro.Z);
    }
    public static Vector3 operator-(Vector3 lo, Vector3 ro)
    {
        return new Vector3(lo.X - ro.X, lo.Y - ro.Y, lo.Z - ro.Z);
    }
    public static Vector3 operator-(Vector3 ro)
    {
        return new Vector3(-ro.X, -ro.Y, -ro.Z);
    }
    public static Vector3 operator*(Vector3 lo, Vector3 ro)
    {
        return new Vector3(lo.X * ro.X, lo.Y * ro.Y, lo.Z * ro.Z);
    }
    public static Vector3 operator*(Vector3 lo, double scalar)
    {
        return new Vector3(lo.X * scalar, lo.Y * scalar, lo.Z * scalar);
    }
    public static Vector3 operator*(double scalar, Vector3 lo)
    {
        return new Vector3(lo.X * scalar, lo.Y * scalar, lo.Z * scalar);
    }
    public static bool operator==(Vector3 lo, Vector3 ro)
    {
        return Math.Abs(lo.X - ro.X) < EqualityEpsilon &&
               Math.Abs(lo.Y - ro.Y) < EqualityEpsilon &&
               Math.Abs(lo.Z - ro.Z) < EqualityEpsilon;
    }
    public static bool operator!=(Vector3 lo, Vector3 ro)
    {
        return !(lo == ro);
    }
    public double Dot(Vector3 ro)
    {
        return X * ro.X + Y * ro.Y + Z * ro.Z;
    }
    public double Dot(double x, double y, double z)
    {
        return X * x + Y * y + Z * z;
    }
    public Vector3 Cross(Vector3 ro)
    {
        return new Vector3(
            Y * ro.Z - ro.Y * Z,
            Z * ro.X - ro.Z * X,
            X * ro.Y - ro.X * Y
        );
    }
    public Vector3 Normalize()
    {
        var len = Length;
        X /= len;
        Y /= len;
        Z /= len;
        return this;
    }
    public double DistanceTo(Vector3 point)
    {
        return (point - this).Length;
    }
    public double SqrDistanceTo(Vector3 point)
    {
        return (point - this).LengthSqr;
    }
    public Vector3 Normalized => new Vector3(X, Y, Z).Normalize();

    public override bool Equals(object? obj)
    {
        if(obj is null || obj is not Vector3)
            return false;
        return this == (Vector3)obj;
    }

    public override int GetHashCode()
    {
        return System.HashCode.Combine(X, Y, Z);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        switch(axis)
        {
            case Axis.X:
                X *= scaleFactor;
                break;
            case Axis.Y:
                Y *= scaleFactor;
                break;
            case Axis.Z:
                Z *= scaleFactor;
                break;
        }
    }

    public void Translate(Vector3 on)
    {
        var tmp = this + on;
        X = tmp.X;
        Y = tmp.Y;
        Z = tmp.Z;
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        var matrix = Transform.GetRotation(axis, angleDegree);
        var tmp = this * matrix;
        X = tmp.X;
        Y = tmp.Y;
        Z = tmp.Z;
    }
}
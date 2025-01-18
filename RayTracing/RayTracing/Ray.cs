namespace RayTracing;

public class Ray
{
    public const double TransformOffset = .0001;

    public Vector3 Start { get; init; }
    public Vector3 Direction { get; init; }
    public Vector3 InvDirection { get; init; }
    
    public Ray(Vector3 start, Vector3 direction)
    {
        Start = start;
        Direction = direction.Normalized;
        InvDirection = new Vector3 {
            X = direction.X != 0 ? 1 / direction.X :
                                   double.PositiveInfinity,
            Y = direction.Y != 0 ? 1 / direction.Y :
                                   double.PositiveInfinity,
            Z = direction.Z != 0 ? 1 / direction.Z :
                                   double.PositiveInfinity,
        };
    }

    public Ray Reflect(Vector3 point,
                       Vector3 normal,
                       double dencity_out_ray = 1,
                       double dencity_in_ray = 1)
    {
        int sign = dencity_in_ray > dencity_out_ray ? -1 : 1;
        
        return new Ray(
            point + normal * (TransformOffset * sign),
            Direction - normal * 2 * normal.Dot(Direction)
        );
    }
    public Ray? Refract(Vector3 point,
                       Vector3 normal,
                       double dencity_out_ray,
                       double dencity_in_ray)
    {
        double etha = dencity_in_ray / dencity_out_ray;
        double c_i = -Direction.Dot(normal);

        var coeff = 1 + etha * etha * (c_i * c_i - 1);
        if(coeff < 0)
            return null;

        int sign = dencity_in_ray > dencity_out_ray ? -1 : 1;
        return new Ray(point - normal * (TransformOffset * sign),
                       etha * Direction +
                       (etha * c_i * sign - 
                       Math.Sqrt(coeff)) * sign * normal);
    }

    public bool Intersect(BoundingBox boundingBox)
    {
        double lo = InvDirection.X * (boundingBox.Min.X - Start.X);
        double hi = InvDirection.X * (boundingBox.Max.X - Start.X);

        var tmin  = Math.Min(lo, hi);
        var tmax = Math.Max(lo, hi);


        double lo1 = InvDirection.Y*(boundingBox.Min.Y - Start.Y);
        double hi1 = InvDirection.Y*(boundingBox.Max.Y - Start.Y);

        tmin  = Math.Max(tmin, Math.Min(lo1, hi1));
        tmax = Math.Min(tmax, Math.Max(lo1, hi1));

        double lo2 = InvDirection.Z*(boundingBox.Min.Z - Start.Z);
        double hi2 = InvDirection.Z*(boundingBox.Max.Z - Start.Z);

        tmin  = Math.Max(tmin, Math.Min(lo2, hi2));
        tmax = Math.Min(tmax, Math.Max(lo2, hi2));


        return (tmin <= tmax) && (tmax > 0.0);
    }
}
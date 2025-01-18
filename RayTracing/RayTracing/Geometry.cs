namespace RayTracing;

public enum Axis
{
    X,
    Y,
    Z
}

public static class Transform
{
    private const double TO_RAD = Math.PI / 180;

    public static Matrix GetRotation(Axis axis, double angleDegree)
    {
        Matrix rotateMatrix = new Matrix();
        double rad = angleDegree * TO_RAD;
        double cos = Math.Cos(rad);
        double sin = Math.Sin(rad);
        switch(axis)
        {
            case Axis.X:
                rotateMatrix[1, 1] = rotateMatrix[2, 2] = cos;
                rotateMatrix[2, 1] = -sin;
                rotateMatrix[1, 2] = sin;
                break;
            case Axis.Y:
                rotateMatrix[0, 0] = rotateMatrix[2, 2] = cos;
                rotateMatrix[2, 0] = sin;
                rotateMatrix[0, 2] = -sin;
                break;
            case Axis.Z:
                rotateMatrix[0, 0] = rotateMatrix[1, 1] = cos;
                rotateMatrix[1, 0] = -sin;
                rotateMatrix[0, 1] = sin;
                break;
        }
        return rotateMatrix;
    }
}
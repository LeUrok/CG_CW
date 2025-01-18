namespace RayTracing;

public class Matrix
{
    public Matrix()
    {
        data_ = new double[Width * Height];
        data_[0] = data_[4] = data_[8] = 1;
    }

    public double this[int line, int column]
    {
        get { return data_[line * Width + column]; }
        set { data_[line * Width + column] = value; }
    }

    public static Vector3 operator*(Matrix matrix, Vector3 vector)
    {
        return new Vector3(
            vector.Dot(matrix[0, 0], matrix[0, 1], matrix[0, 2]),
            vector.Dot(matrix[1, 0], matrix[1, 1], matrix[1, 2]),
            vector.Dot(matrix[2, 0], matrix[2, 1], matrix[2, 2])            
        );
    }
    public static Vector3 operator*(Vector3 vector, Matrix matrix)
    {
        return new Vector3(
            vector.Dot(matrix[0, 0], matrix[1, 0], matrix[2, 0]),
            vector.Dot(matrix[0, 1], matrix[1, 1], matrix[2, 1]),
            vector.Dot(matrix[0, 2], matrix[1, 2], matrix[2, 2])
        );
    }

    private double[] data_;
    private const int Width = 3;
    private const int Height = 3;
}
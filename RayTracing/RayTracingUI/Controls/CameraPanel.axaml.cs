using Avalonia.Controls;
using Avalonia.Interactivity;
using RayTracing;

namespace RayTracingUI;

public partial class CameraPanel : UserControl
{
    public MainWindow MainWindow { get; set; } = null!;

    public const double DefaultMoveDelta = 0.2;
    public const double DefaultRotateDelta = 10;
    public const double DefaultFov = 90;
    public Camera Camera { get; set; } = new Camera();

    public CameraPanel()
    {
        InitializeComponent();
        FillData();
    }

    private double GetMoveDelta()
    {
        double delta = 0;
        if (double.TryParse(moveDelta.Text,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                            out delta))
            return delta;
        else
            moveDelta.Text = DefaultMoveDelta.ToString();
        return DefaultMoveDelta;
    }

    private double GetRotateDelta()
    {
        double delta = 0;
        if (double.TryParse(rotateDelta.Text,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                            out delta))
            return delta;
        else
            rotateDelta.Text = DefaultRotateDelta.ToString();
        return DefaultRotateDelta;
    }

    private double GetFov()
    {
        double fov = 0;
        if (double.TryParse(rotateDelta.Text,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                            out fov) && fov > 0 && fov < 180)
            return fov;
        else
            rotateDelta.Text = DefaultFov.ToString();
        return DefaultFov;
    }

    private void ResetClick(object sender, RoutedEventArgs e)
    {
        Camera.Reset();
        FillData();
        MainWindow.Redraw();
    }

    private void UpClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveUp(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void DownClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveDown(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void LeftClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveLeft(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RightClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveRight(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void ForwardClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveForward(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void BackClick(object sender, RoutedEventArgs e)
    {
        Camera.MoveBackward(GetMoveDelta());
        FillData();
        MainWindow.Redraw();
    }


    private void RotClockwiseClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateClockwise(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RotCounterClockwiseClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateCounterClockwise(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RotLeftClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateLeft(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RotRightClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateRight(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RotForwardClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateUp(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }
    private void RotBackClick(object sender, RoutedEventArgs e)
    {
        Camera.RotateDown(GetRotateDelta());
        FillData();
        MainWindow.Redraw();
    }

    private void FovSetClick(object sender, RoutedEventArgs e)
    {
        Camera.FieldOfView = GetFov();
        MainWindow.Redraw();
    }

    private void FillData()
    {
        var direction = (Camera.ViewPoint - Camera.Position).Normalize();
        xPos.Text = Camera.Position.X.ToString();
        yPos.Text = Camera.Position.Y.ToString();
        zPos.Text = Camera.Position.Z.ToString();

        xDir.Text = direction.X.ToString();
        yDir.Text = direction.Y.ToString();
        zDir.Text = direction.Z.ToString();

        xUp.Text = Camera.Up.X.ToString();
        yUp.Text = Camera.Up.Y.ToString();
        zUp.Text = Camera.Up.Z.ToString();
    }
}
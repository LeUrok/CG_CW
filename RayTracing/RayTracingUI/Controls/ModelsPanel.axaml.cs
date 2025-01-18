using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RayTracing;

namespace RayTracingUI;

public partial class ModelsPanel : UserControl
{
    public MainWindow MainWindow { get; set; } = null!;
    private List<Model> _models;

    public ModelsPanel()
    {
        InitializeComponent();
        _models = new List<Model>();

        FillModels();
    }

    private void FillModels()
    {
        modelSelector.Items = 
            Directory.GetFiles("data", "*.json")
                     .Select(x => Path.GetFileNameWithoutExtension(x));
    }

    public const double DefaultX = 1;
    public const double DefaultY = 1;
    public const double DefaultZ = 1;
    public const double DefaultGrad = 10;
    private double GetX()
    {
        return GetValue(DefaultX, xTb);
    }
    private double GetY()
    {
        return GetValue(DefaultX, yTb);
    }
    private double GetZ()
    {
        return GetValue(DefaultX, zTb);
    }
    private double GetGrad()
    {
        return GetValue(DefaultX, rotTb);
    }

    private double GetValue(double defaultValue, TextBox textBox)
    {
        double val = 0;
        if (double.TryParse(textBox.Text,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                            out val))
            return val;
        else
            textBox.Text = defaultValue.ToString();
        return defaultValue;
    }

    private IEnumerable<Model> GetModels()
    {
        var selected = new List<Model>();
        foreach (var model in models.SelectedItems)
            selected.Add((model as Model)!);
        return selected;
    }


    private void AddModelClick(object sender, RoutedEventArgs e)
    {
        if(modelSelector.SelectedItem == null) return;

        var filename = modelSelector.SelectedItem as string;
        var model = Model.Build(ModelConfig.FromJson(
            Path.Combine("data", filename! + ".json"))!
        );
        model.Name = filename! + "_" + _models.Count;
        
        _models.Add(model);
        models.Items = null;
        models.Items = _models;
        MainWindow.Scene.AddModel(model);
        
        MainWindow.Redraw();
    }
    private void RemoveModelClick(object sender, RoutedEventArgs e)
    {
        foreach (var model in models.SelectedItems)
        {
            _models.Remove((model as Model)!);
            MainWindow.Scene.RemoveModel((model as Model)!);
        }
        models.Items = null;
        models.Items = _models;

        MainWindow.Redraw();
    }

    private void MoveModelClick(object sender, RoutedEventArgs e)
    {
        foreach (var model in GetModels())
            model.Mesh.Translate(new Vector3(GetX(), GetY(), GetZ()));

        MainWindow.Redraw();
    }
    private void ScaleModelClick(object sender, RoutedEventArgs e)
    {
        var x = GetX();
        var y = GetY();
        var z = GetZ();
        if(x <= 0) x = DefaultX;
        if(y <= 0) y = DefaultY;
        if(z <= 0) z = DefaultZ;
        foreach (var model in GetModels())
        {
            model.Mesh.Scale(Axis.X, x);
            model.Mesh.Scale(Axis.Y, y);
            model.Mesh.Scale(Axis.Z, z);
        }

        MainWindow.Redraw();
    }
    private void RotXClick(object sender, RoutedEventArgs e)
    {
        foreach (var model in GetModels())
            model.Mesh.Rotate(Axis.X, GetGrad());

        MainWindow.Redraw();
    }
    private void RotYClick(object sender, RoutedEventArgs e)
    {
        foreach (var model in GetModels())
            model.Mesh.Rotate(Axis.Y, GetGrad());

        MainWindow.Redraw();
    }
    private void RotZClick(object sender, RoutedEventArgs e)
    {
        foreach (var model in GetModels())
            model.Mesh.Rotate(Axis.Z, GetGrad());

        MainWindow.Redraw();
    }
}
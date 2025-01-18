using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RayTracing;

namespace RayTracingUI;

public partial class LightsPanel : UserControl
{
    public MainWindow MainWindow { get; set; } = null!;
    private List<Light> _lights = new List<Light>();
    public LightsPanel()
    {
        InitializeComponent();
    
        FillLightTypes();
    }


    public const double DefaultCoord = 1;
    public const double DefaultColor = 1;

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

    private void FillLightTypes()
    {
        lightSelector.Items = new string[] { "Точечный", "Направленный" };
    }

    private void AddLightClick(object sender, RoutedEventArgs e)
    {
        if(lightSelector.SelectedItem == null)
            return;

        var lightType = lightSelector.SelectedItem as string;        
        var light = CreateLight(lightType!);
        
        _lights.Add(light!);
        lights.Items = null;
        lights.Items = _lights;
        MainWindow.Scene.AddLight(light!);
        
        MainWindow.Redraw();
    }

    private void RemoveLightClick(object sender, RoutedEventArgs e)
    {
        foreach (var light in lights.SelectedItems)
        {
            _lights.Remove((light as Light)!);
            MainWindow.Scene.RemoveLight((light as Light)!);
        }
        lights.Items = null;
        lights.Items = _lights;

        FillData();
        MainWindow.Redraw();
    }
    private IEnumerable<Light> GetLights()
    {
        var selected = new List<Light>();
        foreach (var light in lights.SelectedItems)
            selected.Add((light as Light)!);
        return selected;
    }
    private void SetLightClick(object sender, RoutedEventArgs e)
    {
        foreach (var light in GetLights())
        {
            light.SetPosition(new Vector3(GetValue(DefaultCoord, xPos),
                                          GetValue(DefaultCoord, yPos),
                                          GetValue(DefaultCoord, zPos)));
            light.SetDirection(new Vector3(GetValue(DefaultCoord, xDir),
                                           GetValue(DefaultCoord, yDir),
                                           GetValue(DefaultCoord, zDir)));
            light.Diffuse = new Vector3(GetValue(DefaultColor, xDiff),
                                        GetValue(DefaultColor, yDiff),
                                        GetValue(DefaultColor, zDiff));
            light.Specular = new Vector3(GetValue(DefaultColor, xSpec),
                                         GetValue(DefaultColor, ySpec),
                                         GetValue(DefaultColor, zSpec));
        }
        MainWindow.Scene.AmbientLight = new Vector3(GetValue(DefaultColor, xAmb),
                                                    GetValue(DefaultColor, yAmb),
                                                    GetValue(DefaultColor, zAmb));
        MainWindow.Redraw();
    }

    private Light? CreateLight(string lightType)
    {
        switch (lightType)
        {
            case "Точечный":
                return new PointLight { Name = "Точечный_" + _lights.Count };
            case "Направленный":
                return new DirectionLight { Name = "Направленный_" + _lights.Count };
        }
        return null;
    }

    private void LightSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FillData();
    }

    private void FillData()
    {
        if (lights.SelectedItems.Count != 1)
        {
            xPos.Text = string.Empty; yPos.Text = string.Empty; zPos.Text = string.Empty;
            xDir.Text = string.Empty; yDir.Text = string.Empty; zDir.Text = string.Empty;
            xDiff.Text = string.Empty; yDiff.Text = string.Empty; zDiff.Text = string.Empty;
            xSpec.Text = string.Empty; ySpec.Text = string.Empty; zSpec.Text = string.Empty;
        }
        else
        {
            Light light = (lights.SelectedItems[0] as Light)!;
            xPos.Text = light.GetPosition().X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            yPos.Text = light.GetPosition().Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            zPos.Text = light.GetPosition().Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

            xDir.Text = light.GetDirection().X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            yDir.Text = light.GetDirection().Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            zDir.Text = light.GetDirection().Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

            xDiff.Text = light.Diffuse.X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            yDiff.Text = light.Diffuse.Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            zDiff.Text = light.Diffuse.Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

            xSpec.Text = light.Specular.X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            ySpec.Text = light.Specular.Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
            zSpec.Text = light.Specular.Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
        }
        FillAmbient();
    }

    public void FillAmbient()
    {
        xAmb.Text = MainWindow.Scene.AmbientLight.X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
        yAmb.Text = MainWindow.Scene.AmbientLight.Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
        zAmb.Text = MainWindow.Scene.AmbientLight.Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
    }
}
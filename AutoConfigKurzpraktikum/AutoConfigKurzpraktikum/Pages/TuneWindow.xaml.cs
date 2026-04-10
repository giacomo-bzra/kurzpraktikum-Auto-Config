using System.Windows;
using AutoConfigKurzpraktikum.Pages;

namespace AutoConfigKurzpraktikum;

public partial class TuneWindow : Window
{
    public TuneWindow()
    {
        InitializeComponent();
        Brake.SelectedIndex = 1;
        Engine.SelectedIndex = 1;
        Frontspoiler.SelectedIndex = 1;
        Heckspoiler.SelectedIndex = 1;
        Rimm.SelectedIndex = 1;
        Tire.SelectedIndex = 1;
    }

    public void Button_select(object sender, RoutedEventArgs e)
    {
        StatsWindow statsWindow = new StatsWindow();
        statsWindow.Show();
        this.Close();
    }
    

}
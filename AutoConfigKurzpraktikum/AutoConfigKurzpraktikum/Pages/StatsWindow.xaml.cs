using System.Windows;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{
    public StatsWindow()
    {
        InitializeComponent();
    }

    public void Button_Done(object sender, RoutedEventArgs e) {
        this.Close();
    }
}
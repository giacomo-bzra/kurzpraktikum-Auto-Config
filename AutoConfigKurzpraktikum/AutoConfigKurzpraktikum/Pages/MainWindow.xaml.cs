using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoConfigKurzpraktikum.Models;
using AutoConfigKurzpraktikum.Pages;
using AutoConfigKurzpraktikum.Service;

namespace AutoConfigKurzpraktikum;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();

    }

    public void Button_CreateNew(object sender, RoutedEventArgs e)
    {
        CarConfigur carConfigur = new CarConfigur();
        carConfigur.Show();
        this.Close();
    }
    
    public void Button_Edit(object sender, RoutedEventArgs e)
    {
        CarConfigur carConfigur = new CarConfigur();
        carConfigur.Show();
        this.Close();
    }
    
    public void Button_Delete(object sender, RoutedEventArgs e)
    {
        
    }
}
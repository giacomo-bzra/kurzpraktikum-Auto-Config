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

namespace AutoConfigKurzpraktikum;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }
    
    public void Button_select(object sender, RoutedEventArgs e)
    {
            TuneWindow tuneWindow = new TuneWindow();
            tuneWindow.Show();
            this.Close();
    }
}
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;

namespace AutoConfigKurzpraktikum.Pages;

public partial class StatsWindow : Window
{
    public StatsWindow()
    {
        InitializeComponent();
        SpeedStat(stuffe);
        BrakeStat(stuffe);
        GripStat(stuffe);
        WeightStat(stuffe);
    }



    public void Button_Done(object sender, RoutedEventArgs e) {
        this.Close();
    }


    private int stuffe = 1;
    private void SpeedStat(int stuffe)
    {
        Speed1.Fill = Brushes.Transparent;
        Speed2.Fill = Brushes.Transparent;
        Speed3.Fill = Brushes.Transparent;
        Speed4.Fill = Brushes.Transparent;
        Speed5.Fill = Brushes.Transparent;

        if (stuffe >= 1) Speed1.Fill = Brushes.Green;
        if (stuffe >= 2) Speed2.Fill = Brushes.Green;
        if (stuffe >= 3) Speed3.Fill = Brushes.Green;
        if (stuffe >= 4) Speed4.Fill = Brushes.Green;
        if (stuffe >= 5) Speed5.Fill = Brushes.Green;
        }
    
    private void BrakeStat(int stuffe)
    {
        Brake1.Fill = Brushes.Transparent;
        Brake2.Fill = Brushes.Transparent;
        Brake3.Fill = Brushes.Transparent;
        Brake3.Fill = Brushes.Transparent;
        Brake5.Fill = Brushes.Transparent;

        if (stuffe >= 1) Brake1.Fill = Brushes.Green;
        if (stuffe >= 2) Brake2.Fill = Brushes.Green;
        if (stuffe >= 3) Brake3.Fill = Brushes.Green;
        if (stuffe >= 4) Brake4.Fill = Brushes.Green;
        if (stuffe >= 5) Brake5.Fill = Brushes.Green;
    }
    
    private void GripStat(int stuffe)
    {
        Grip1.Fill = Brushes.Transparent;
        Grip2.Fill = Brushes.Transparent;
        Grip3.Fill = Brushes.Transparent;
        Grip4.Fill = Brushes.Transparent;
        Grip5.Fill = Brushes.Transparent;

        if (stuffe >= 1) Grip1.Fill = Brushes.Green;
        if (stuffe >= 2) Grip2.Fill = Brushes.Green;
        if (stuffe >= 3) Grip3.Fill = Brushes.Green;
        if (stuffe >= 4) Grip4.Fill = Brushes.Green;
        if (stuffe >= 5) Grip5.Fill = Brushes.Green;
    }
    
    private void WeightStat(int stuffe)
    {
        Weight1.Fill = Brushes.Transparent;
        Weight2.Fill = Brushes.Transparent;
        Weight3.Fill = Brushes.Transparent;
        Weight4.Fill = Brushes.Transparent;
        Weight5.Fill = Brushes.Transparent;

        if (stuffe >= 1) Weight1.Fill = Brushes.Green;
        if (stuffe >= 2) Weight2.Fill = Brushes.Green;
        if (stuffe >= 3) Weight3.Fill = Brushes.Green;
        if (stuffe >= 4) Weight4.Fill = Brushes.Green;
        if (stuffe >= 5) Weight5.Fill = Brushes.Green;
    }
    }
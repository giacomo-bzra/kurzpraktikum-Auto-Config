using System.Windows;

namespace AutoConfigKurzpraktikum.Models.Parts;

public class Tire : TuningPart
{
    public Type TireType  { get; set; }
    public double Thickness { get; set; }
}
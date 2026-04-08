using System.Windows;

namespace AutoConfigKurzpraktikum.Models.Parts;

public class Tire : TuningPart
{
    public Type TireType  { get; set; }
   public double Thickness { get; set; }

   public Tire(string name, double price, double weight, bool isInstalled, string color, Type tireType,
       double thickness) :
       base(name, price, weight, isInstalled, color)
   {
       this.TireType = tireType;
       this.Thickness = thickness;
   }
}
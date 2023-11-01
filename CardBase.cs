using Godot;
using System;

public partial class CardBase : Node
{

    public int FireCost {get; set;}
    public int WaterCost{get; set;}
    public int EarthCost{get; set;}

    public string Name {get; set;}

    public string Description{get; set;}

    public CardBase(int fireCost, int waterCost, int earthCost, string name, string description)
    {
        FireCost = fireCost;
        WaterCost = waterCost;
        EarthCost = earthCost;
        Name = name;
        Description = description; 
    }

   /* public void Effect()
    {
        GD.Print("Card Effect");
    }*/

   


}

using Godot;
using System;

public partial class CardBase : Control
{
    private Label cardName;
    private Label labelFireCost;
    private Label labelWaterCost;
    private Label labelEarthCost;

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

    public override void _Ready()
    {
        cardName = GetNode<Label>("Name");
        labelFireCost = GetNode<Label>("FireCost");
        labelWaterCost = GetNode<Label>("WaterCost");
        labelEarthCost = GetNode<Label>("EarthCost");

         if (cardName != null)
            cardName.Text = $"Name: {Name}";

        if (labelFireCost != null)
            labelFireCost.Text = $"Fire Cost: {FireCost}";

        if (labelWaterCost != null)
            labelWaterCost.Text = $"Water Cost: {WaterCost}";

        if (labelEarthCost != null)
            labelEarthCost.Text = $"Earth Cost: {EarthCost}";

 
    }

    public void Effect()
    {
        GD.Print("Card Effect");
    }

   


}

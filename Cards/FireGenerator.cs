using Godot;
using System;

public partial class FireGenerator : CardBase
{
    
    public int FireGeneration {get; set;}
    public FireGenerator(string name, string description, int fireGeneration) : base(name, description)
    {
        FireGeneration = fireGeneration;
        

    }

    public override void Effect()
    {
        GD.Print("Fire Amount Increased by: " + FireGeneration);
        //player.fireAmount += FireGeneration; 

    }
}

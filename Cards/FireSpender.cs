using Godot;
using System;
using System.Runtime;

public partial class FireSpender : CardBase
{

   // Enemy enemy; 
    [Export]
    public int FireCost = 0;
    [Export]
    public int FireDamage = 1;

    /*public FireSpender(int fireCost, int fireDamage, string cardName, string description) : base(cardName, description)
    {
       FireCost = fireCost;
       FireDamage = fireDamage; 
       //this.enemy = enemy;
    }*/
    public override void _Ready()
    {
        CardName = "testSpender";
        Description = "testDesc";
    }

    public override void Effect(Actor target)
    {
        
        GD.Print("Firespender used and dealt: " + FireDamage);
        
        target.hp = target.hp - FireDamage;

    }

   

}

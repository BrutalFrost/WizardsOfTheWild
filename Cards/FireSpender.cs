using Godot;
using System;

public partial class FireSpender : CardBase
{

   // Enemy enemy; 



    public int FireCost{get; set;}
    public int FireDamage {get; set;} 

    public FireSpender(int fireCost, int fireDamage, string cardName, string description) : base(cardName, description)
    {
       FireCost = fireCost;
       FireDamage = fireDamage; 
       //this.enemy = enemy;
    }

    public override void Effect()
    {
        
        GD.Print("Firespender used and dealt: " + FireDamage);
        //enemy.hp -= FireDamage;

    }

   

}

using Godot;
using System;

public partial class FireSpender : CardBase
{

    

    public int FireCost{get; set;}
    public int FireDamage {get; set;} 

    public FireSpender(int fireCost, int fireDamage, string cardName, string description) : base(cardName, description)
    {
       FireCost = fireCost;
       FireDamage = fireDamage; 
    }

   

}

using Godot;
using System;
using System.Collections.Generic;

public abstract partial class CardBase : Node2D
{

    [Export]
    public virtual string CardName {get; set;}
    [Export]
    public virtual string Description {get; set;}

    public override void _Ready() {

    }
    /*public CardBase (string cardName, string description)
    {
        CardName = cardName;
        Description = description;
    }*/

    public virtual void Effect(Actor target)
    {
    
    }

   


}

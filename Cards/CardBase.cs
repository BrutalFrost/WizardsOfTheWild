using Godot;
using System;

public partial class CardBase : Control
{

    public string CardName {get; set;}
    public string Description {get; set;}

    public CardBase (string cardName, string description)
    {
        CardName = cardName;
        Description = description;
    }

   


	

    public virtual void Effect()
    {
    
    }

   


}

using Godot;
using System;
using System.Collections.Generic;

public partial class CardDisplay : Node
{
     public override void _Ready()
    {
        

        Label cardName = GetNode<Label>("Name");
        Label cardDescription = GetNode<Label>("Description");

        

        /*cardName.Text = cards[0].CardName;     
        cardDescription.Text = cards[0].Description;*/
        
    }

}

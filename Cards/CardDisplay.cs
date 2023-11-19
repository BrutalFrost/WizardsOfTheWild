using Godot;
using System;
using System.Collections.Generic;

public partial class CardDisplay : Node
{


     public override void _Ready()
    {
        List<CardBase> cards = new List<CardBase>();

        cards.Add(new FireSpender(20,2,"firestorm", "this does something"));

        Label cardName = GetNode<Label>("Name");
        Label cardDescription = GetNode<Label>("Description"); 

        cardName.Text = cards[0].CardName;     
        cardDescription.Text = cards[0].Description;
        
    }

}

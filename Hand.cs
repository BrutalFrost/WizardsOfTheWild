using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Node2D
{
	[Export]
	int startingHandSize = 5;
	public List<CardBase> hand = new List<CardBase>(); 
	List<CardBase> localDeck = new List<CardBase>(); 
	



	private List <Node2D> handSlots;
	// Called when the node enters the scene tree for the first time.


	public override void _Ready()
	{
		PackedScene testCardScene = (PackedScene)ResourceLoader.Load("res://Cards/fire_spender.tscn");
		Node cardS = testCardScene.Instantiate(); 
		AddChild(cardS);


	}
	public void setDeck(List<CardBase> deck) {
		localDeck = deck;
	}
	public void CardDraw()
	{
		Random random = new Random();
		GD.Print("Im DRAWING");
		for (int i = 0; i < 2; i++)
		{
			if (localDeck.Count > 0)
			{
				int randomIndex = random.Next(0, localDeck.Count);

				CardBase drawnCard = localDeck[randomIndex];
				hand.Add(drawnCard);

				GD.Print(drawnCard.CardName);
			}
		}
		GD.Print("hand 1" + hand[0].CardName);

	}
}

using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : MarginContainer
{

	PackedScene cardBaseScene = (PackedScene)ResourceLoader.Load("res://Card.tscn");

	List<CardBase> deck = new List<CardBase>();
	List<CardBase> cardsInHand = new List<CardBase>();

	/*CardBase fireball = new CardBase(1, 0, 0, "Fireball", "Deal 5 damage");
	CardBase waterball = new CardBase(0, 1, 0, "Waterball", "Deal 5 damage");
	CardBase earthball = new CardBase(0, 0, 1, "Earthball", "Deal 5 damage");
	CardBase fireblast = new CardBase(2, 0, 0, "Fireblast", "Deal 10 damage");
	CardBase waterblast = new CardBase(0, 2, 0, "Waterblast", "Deal 10 damage");	
	CardBase earthblast = new CardBase(0, 0, 2, "Earthblast", "Deal 10 damage");
	CardBase firestorm = new CardBase(3, 0, 0, "Firestorm", "Deal 15 damage");*/



	[Export]
	int maxHandSize = 5;


	public override void _Ready()
	{
		CardBase cardBase = GetNode<CardBase>("CardBase");
		deck.Add(new CardBase(1, 0, 0, "Fireball", "Deal 5 damage"));
		deck.Add(new CardBase(0, 1, 0, "Waterball", "Deal 5 damage"));
		deck.Add(new CardBase(0, 0, 1, "Earthball", "Deal 5 damage"));
		deck.Add(new CardBase(2, 0, 0, "Fireblast", "Deal 10 damage"));
		deck.Add(new CardBase(0, 2, 0, "Waterblast", "Deal 10 damage"));
		deck.Add(new CardBase(0, 0, 2, "Earthblast", "Deal 10 damage"));
		deck.Add(new CardBase(3, 0, 0, "Firestorm", "Deal 15 damage"));

		/*for(int i = 0; i < maxHandSize; i++)
		{
			Draw();
		}*/

	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("draw_card") && cardsInHand.Count < maxHandSize && deck.Count > 0)
		{
			Draw();
			GD.Print(cardsInHand.Count);
		}
	}

	
	public void Draw()
	{
		Node cardBase = cardBaseScene.Instantiate();
		AddChild(cardBase);

		int randomIndex = new Random().Next(deck.Count);
		CardBase drawnCard = deck[randomIndex];
		cardsInHand.Add(drawnCard);
		deck.RemoveAt(randomIndex);
		
		
	}


	
		
	


}
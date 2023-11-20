using Godot;
using System;
using System.Collections.Generic;

public partial class Hand : Node2D
{
	[Export]
	int startingHandSize = 5;
	Player player; 
	Enemy enemy;
	List<CardBase> deck = new List<CardBase>();
	List<CardBase> hand = new List<CardBase>();  
	



	private List <Node2D> handSlots;
	// Called when the node enters the scene tree for the first time.


	public override void _Ready()
	{
		PackedScene cardScene = (PackedScene)ResourceLoader.Load("res://card.tscn");
		player = GetNode<Player>("res://player.tscn");
		enemy = GetNode<Enemy>("res://enemy.tscn");
		Node cardS = cardScene.Instantiate(); 
		AddChild(cardS);
		deck.Add(new FireSpender(2,20,"Fire Ball", "Deals 20 fire damge"));
		deck.Add(new FireSpender(2,20,"Fire Ball", "Deals 20 fire damge"));
		deck.Add(new FireGenerator("Fire gem", "Grants 2 fire energy", 2));
		deck.Add(new FireGenerator("Fire gem", "Grants 2 fire energy", 2));
		CardDraw();

	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("1"))
		{

			hand[0].Effect();

		}
		if (Input.IsActionJustPressed("2"))
		{

			hand[1].Effect();

		}
		if (Input.IsActionJustPressed("3"))
		{

			hand[2].Effect();

		}
		if (Input.IsActionJustPressed("4"))
		{

			hand[3].Effect();

		}
		if (Input.IsActionJustPressed("5"))
		{

			hand[4].Effect();

		}
	}




	public void CardDraw()
	{
		Random random = new Random();

		for (int i = 0; i < startingHandSize; i++)
		{
			if (deck.Count > 0)
			{
				int randomIndex = random.Next(0, deck.Count);

				CardBase drawnCard = deck[randomIndex];
				hand.Add(drawnCard);

				GD.Print(drawnCard.CardName);
			}
		}

	}
}

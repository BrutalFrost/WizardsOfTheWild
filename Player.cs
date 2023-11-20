using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public partial class Player : Actor
{
	public int fireAmount = 0; 
	Hand playerHand;
	List<CardBase> deck = new List<CardBase>();
	PackedScene handScene = (PackedScene)ResourceLoader.Load("res://hand.tscn");
	Actor enemy;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node handS = handScene.Instantiate();
		AddChild(handS);
		playerHand = (Hand)handS;
		
		calculateAV();
		PopulateDeckTest();
		playerHand.setDeck(deck);
		playerHand.CardDraw();
		
		
	}
	public void PopulateDeckTest() {
		PackedScene fireSpenderScene = (PackedScene)ResourceLoader.Load("res://Cards/fire_spender.tscn");
		Node fireSpenderS = fireSpenderScene.Instantiate();
		AddChild(fireSpenderS);
		deck.Add((CardBase)fireSpenderS);
		deck.Add((CardBase)fireSpenderS);


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	// To be renamed, take damage method
	public override void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Monster has attacked");
		GD.Print("Current player hp: "+hp);
	}
	// Gets repeatedly called during a players turn
	public override void TakeTurn (Actor target) {
		enemy = target;
		if(Input.IsActionJustPressed("1"))
		{

			playerHand.hand[0].Effect(enemy);

		}
		if (Input.IsActionJustPressed("2"))
		{

			playerHand.hand[1].Effect(target);

		}
		if (Input.IsActionJustPressed("3"))
		{

			playerHand.hand[2].Effect(target);

		}
		if (Input.IsActionJustPressed("4"))
		{

			playerHand.hand[3].Effect(target);

		}
		if (Input.IsActionJustPressed("5"))
		{

			playerHand.hand[4].Effect(target);

		}
		if (Input.IsActionJustPressed("enemy_attack")){
				endTurn();
		}
	}

	// Executes everything that happens at the end of a players turn then ends that turn
	public override void endTurn () {
		playerHand.CardDraw();
		enemy._Attack(attack);
		actionGauge = 10000;
	}
}

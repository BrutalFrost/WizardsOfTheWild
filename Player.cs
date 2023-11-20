using Godot;
using System;

public partial class Player : Actor
{
	public int fireAmount = 0; 
	Hand hand;
	PackedScene handScene = (PackedScene)ResourceLoader.Load("res://hand.tscn");
	Actor enemy;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node handS = handScene.Instantiate();
		hand = (Hand)handS;
		calculateAV();
		
		
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
		if (Input.IsActionJustPressed("enemy_attack")){
				endTurn();
		}
	}

	// Executes everything that happens at the end of a players turn then ends that turn
	public override void endTurn () {
		
		enemy._Attack(attack);
		actionGauge = 10000;
	}
}

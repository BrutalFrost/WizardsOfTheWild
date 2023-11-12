using Godot;
using System;

public partial class Player : Actor
{
	
	
	Enemy enemy;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		enemy = GetNode<Enemy>("Enemy");
		calculateAV();
		labelHP = GetNode<Label>("PlayerHp");
		displayHP();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	

	public override void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Monster has attacked");
		GD.Print("Current player hp: "+hp);
		displayHP();
	}
	public override void takeTurn (Actor target) {
		if (Input.IsActionJustPressed("enemy_attack")){
				target._Attack(attack);
				actionGauge = 10000;
		}
	}
	// Check if actor is alive, to be moved to Actor.cs
	public bool IsAlive(){
		if(hp > 0){
			return true;
		} else {
			return false;
		}
	}
}

using Godot;
using System;
using System.Diagnostics.Contracts;

public partial class Enemy : Actor
{
	// Called when the node enters the scene tree for the first time.
	Player player;
	public override void _Ready()
	{
		 player = GetNode<Player>("Player");
		 queueOrder = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	public override void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Player has attacked");
		GD.Print("Current monster hp: "+hp);
	}
	public override void takeTurn (Actor target) {
		target._Attack(attack);
		queueOrder -= 200;
	}

	public bool IsAlive(){
		if(hp > 0){
			return true;
		} else {
			return false;
		}
	}
}

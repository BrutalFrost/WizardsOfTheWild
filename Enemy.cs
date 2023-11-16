using Godot;
using System;
using System.Diagnostics.Contracts;
using System.Threading;

public partial class Enemy : Actor
{
	// Called when the node enters the scene tree for the first time.
	Player player;
	
    public override void _Ready()
	{
		 calculateAV();
		 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// To be renamed, take damage method
	public override void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Player has attacked");
		GD.Print("Current monster hp: "+hp);
	}
	public override void TakeTurn (Actor target) {
		Thread.Sleep(500);
		target._Attack(attack);
		actionGauge = 10000;
	}
}

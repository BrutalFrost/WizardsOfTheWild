using Godot;
using System;

public partial class Enemy : Node2D
{
	[Export]
	public int hp = 50;
	[Export]
	public int attack = 10;
	// Called when the node enters the scene tree for the first time.
	Player player;
	public override void _Ready()
	{
		 player = GetNode<Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	public void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Player has attacked");
		GD.Print("Current monster hp: "+hp);
	}

	public bool IsAlive(){
		if(hp > 0){
			return true;
		} else {
			return false;
		}
	}
}

using Godot;
using System;

public partial class Player : Node2D
{
	[Export]
	public int hp = 50;
	[Export]
	public int attack = 10;
	Enemy enemy;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		enemy = GetNode<Enemy>("Enemy");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	

	public void _Attack(int dmg) {
		hp -= dmg;
		GD.Print("Monster has attacked");
		GD.Print("Current player hp: "+hp);
	}

	public bool IsAlive(){
		if(hp > 0){
			return true;
		} else {
			return false;
		}
	}
}

using Godot;
using System;

public partial class Combat : Node2D
{
	// Called when the node enters the scene tree for the first time.

	Enemy enemy;
	Player player;
	public override void _Ready()
	{
		enemy = GetNode<Enemy>("Enemy");
		player = GetNode<Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(player.IsAlive() && enemy.IsAlive()){
			if (Input.IsActionJustPressed("player_attack")){
				player._Attack(enemy.attack);
			}
			if (Input.IsActionJustPressed("enemy_attack")){
				enemy._Attack(player.attack);
			}
		}else if(!player.IsAlive()){
			player.QueueFree();
		}else if(!enemy.IsAlive()){
			enemy.QueueFree();
		}else{
			GD.Print("How are you here?");
		}
	}
}

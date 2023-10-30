using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public partial class Combat : Node2D
{
	// Called when the node enters the scene tree for the first time.

	Enemy enemy;
	Player player;
	List<Actor> turnQueue = new List<Actor>();
	Actor currentCharacter;

	public override void _Ready()
	{
		enemy = GetNode<Enemy>("Enemy");
		player = GetNode<Player>("Player");
		turnQueue.Add(enemy);
		turnQueue.Add(player);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		currentCharacter = getNextCharacter();
		if(currentCharacter is Player) {
			currentCharacter.takeTurn(enemy);
		} else if (currentCharacter is Enemy) {
			currentCharacter.takeTurn(player);
		}

		
		
		
		/*if(player.IsAlive() && enemy.IsAlive()){
			if (Input.IsActionJustPressed("player_attack")){
				player._Attack(enemy.attack);
			}
		}else if(!player.IsAlive()){
			player.QueueFree();
		}else if(!enemy.IsAlive()){
			enemy.QueueFree();
		}else{
			GD.Print("How are you here?");
		}*/
	}

	public Actor getNextCharacter () {

		while(true){
			foreach(Actor actor in turnQueue) {
				if(actor.queueOrder >= 200) {
					return actor;
				}
			}
			
			foreach(Actor actor in turnQueue) {
				actor.queueOrder += actor.speed;
			}
			turnQueue = turnQueue.OrderBy(o=>o.queueOrder).ToList();
			
			
		}
		

	}


	/*public void progressTurn() {
		foreach (Actor character in turnQueue) {
			if (character.queueOrder >= 200) {
				character.queueOrder -= 200;
				GD.Print("Debug queueOrder:"+ character.queueOrder);
				if(character is Player) {
					character.takeTurn(enemy);
				} else if (character is Enemy){
					character.takeTurn(player);
				}
				
			}
			Thread.Sleep(100);
		}
		foreach(Actor character in turnQueue) {
			character.queueOrder += character.speed;
		}
		turnQueue = turnQueue.OrderBy(o=>o.queueOrder).ToList();
	}*/
}

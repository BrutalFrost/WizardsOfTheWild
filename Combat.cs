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
	Label pTurnOrderLabel;
	Label eTurnOrderLabel;

	public override void _Ready()
	{
		enemy = GetNode<Enemy>("Enemy");
		player = GetNode<Player>("Player");
		turnQueue.Add(enemy);
		turnQueue.Add(player);
		pTurnOrderLabel = GetNode<Label>("pTurnOrderLabel");
		eTurnOrderLabel = GetNode<Label>("eTurnOrderLabel");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//---------Placeholder combat----------
		currentCharacter = getNextCharacter();
		if(currentCharacter is Player) {
			currentCharacter.takeTurn(enemy);
			
			
		} else if (currentCharacter is Enemy) {
			currentCharacter.takeTurn(player);
			
		}
		//-------------------------------------

		// Debugging print
		GD.Print("Enemy action gauge: "+ enemy.actionGauge); 
		GD.Print("Player action gauge: "+ player.actionGauge); 
		// Updating the label for Action Value
		pTurnOrderLabel.Text = player.actionValue.ToString();
		eTurnOrderLabel.Text = enemy.actionValue.ToString();

		
		
		// Check if player or enemy has died
		// Needs rewrite 
		if(player.IsAlive() && enemy.IsAlive()){
			
		}else if(!player.IsAlive()){
			player.QueueFree();
		}else if(!enemy.IsAlive()){
			enemy.QueueFree();
		}else{
			GD.Print("How are you here?");
		}
	}

	public Actor getNextCharacter () {

		while(true){
			// Checks if an Actor can take action
			foreach(Actor actor in turnQueue) {
				if(actor.actionGauge <= 0) {
					return actor;
				}
			}
			// Advance all Actors
			foreach(Actor actor in turnQueue) {
				GD.Print(actor.actionGauge);
				actor.actionGauge -= actor.speed;
				actor.calculateAV();
			}
			turnQueue = turnQueue.OrderBy(o=>o.actionValue).ToList();
			
			
		}
		

	}
	private void _on_end_turn_button_pressed () {
		currentCharacter.endTurn();
	}

}

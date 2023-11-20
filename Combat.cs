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
	// Labels in the ui
	Label pTurnOrderLabel;
	Label eTurnOrderLabel;
	Label playerHpLabel;
	Label enemyHpLabel;
	Label fireAmountLabel;
	//------------------------------

	// Loading scenes to use as actors, to be reworked
	PackedScene enemyScene = (PackedScene)ResourceLoader.Load("res://gremlin_dwarf.tscn");
	PackedScene playerScene = (PackedScene)ResourceLoader.Load("res://player.tscn");

	// Launches when scene is called
	public override void _Ready()
	{
		
		// Placeholder spawning of enemies and the player
		Node enemyS = enemyScene.Instantiate();
		AddChild(enemyS);
		Node playerS = playerScene.Instantiate();
		AddChild(playerS);
		enemy = (Enemy)enemyS;
		player = (Player)playerS;	
		//-----------------------------------------------

		//enemy = GetNode<Enemy>("Enemy");
		//player = new enemyS();
		turnQueue.Add(enemy);
		turnQueue.Add(player);
		pTurnOrderLabel = GetNode<Label>("pTurnOrderLabel");
		eTurnOrderLabel = GetNode<Label>("eTurnOrderLabel");
		
		
		playerHpLabel = GetNode<Label>("PlayerHp");
		fireAmountLabel = GetNode<Label>("FireAmount");
	
		enemyHpLabel = GetNode<Label>("EnemyHp");
		DisplayResource();
		DisplayHP();
		

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//---------Placeholder combat----------
		currentCharacter = GetNextCharacter();
		if(currentCharacter is Player) {
			currentCharacter.TakeTurn(enemy);
			
			
		} else if (currentCharacter is Enemy) {
			currentCharacter.TakeTurn(player);
			
		}
		//-------------------------------------
		DisplayHP(); // Updates health labels in ui
		// Debugging print
		/*GD.Print("Enemy action gauge: "+ enemy.actionGauge); 
		GD.Print("Player action gauge: "+ player.actionGauge); 
		GD.Print("Test AV: " + player.actionValue);*/
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

	public Actor GetNextCharacter () {

		while(true){
			// Checks if an Actor can take action
			foreach(Actor actor in turnQueue) {
				if(actor.actionGauge <= 0) {
					return actor;
				}
			}
			// Advance all Actors
			foreach(Actor actor in turnQueue) {
				actor.actionGauge -= actor.speed;
				actor.calculateAV();
			}
			turnQueue = turnQueue.OrderBy(o=>o.actionValue).ToList();
			
			
		}
		

	}

	// Method to update text labels for hp
	public void DisplayHP() {
		playerHpLabel.Text = "HP: " + player.hp.ToString();
		enemyHpLabel.Text = "HP: " + enemy.hp.ToString();
	}
	// Event listener to check if end turn button is pressed
	private void OnEndTurnButtonPressed () {
		currentCharacter.endTurn();
	}

	public void DisplayResource()
	{
		fireAmountLabel.Text = player.fireAmount.ToString();
	}

}

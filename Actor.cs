using Godot;

public abstract partial class Actor : Node2D {
    [Export]
	public int hp = 50;
	[Export]
	public int attack = 10;
	[Export]
	public int speed = 180; // How fast actionGauge lowers
	public int actionGauge = 10000; // When actionGauge reaches 0 its that characters turn
	public int actionValue; // Just a vaue to show to the player
    public int queueOrder = 0; // Deprecated?

	// Placeholder method to take in a target actor and do their turn
    public virtual void TakeTurn (Actor target) {
		
	}

	// Missnamed get damaged method
	public virtual void _Attack (int dmg) {
	}
	public void calculateAV () {
		actionValue = actionGauge/speed;
	}
	// Simple check if actor is alive
	public bool IsAlive(){
		if(hp > 0){
			return true;
		} else {
			return false;
		}
	}
	public virtual void endTurn(){

	}
}
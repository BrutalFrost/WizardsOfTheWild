using Godot;

public partial class Actor : Node2D {
    [Export]
	public int hp = 50;
	[Export]
	public int attack = 10;
	[Export]
	public int speed = 180;
	public int actionGauge = 10000;
	public int actionValue;
    public int queueOrder = 0;
	public Label labelHP;

    public virtual void takeTurn (Actor target) {
		
	}
	public virtual void _Attack (int dmg) {
	}
	public void calculateAV () {
		actionValue = actionGauge/speed;
	}
	public void displayHP() {
		labelHP.Text = "HP: " + hp.ToString();
	}
}
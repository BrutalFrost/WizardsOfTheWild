using Godot;

public partial class Actor : Node2D {
    [Export]
	public int hp = 50;
	[Export]
	public int attack = 10;
	public int speed = 180;
    public int queueOrder = 0;

    public virtual void takeTurn (Actor target) {
		
	}
	public virtual void _Attack (int dmg) {
	}
}
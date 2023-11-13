using Godot;
using System;

public partial class endTurnButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
		button.Pressed += ButtonPressed;
		AddChild(button);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void ButtonPressed()
	{
		GD.Print("Hello world!");
	}

}

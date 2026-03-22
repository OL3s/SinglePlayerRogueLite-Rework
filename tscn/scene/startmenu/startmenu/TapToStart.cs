using Godot;
using System;

public partial class TapToStart : Control
{
	[Export] PackedScene TargetScene { get; set; }


	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touchEvent && touchEvent.Pressed)
		{
			OnStartButtonPressed();
		}
	}

	private void OnStartButtonPressed()
	{
		if (TargetScene != null)
		{
			GetTree().ChangeSceneToPacked(TargetScene);
			return;
		} 

		throw new InvalidOperationException("TargetScene is not assigned in the inspector.");

	}
}

using Godot;
using System;

public partial class TapToStart : Control
{
	[Export] PackedScene TargetScene { get; set; }
	private bool pathCharacterSelect => GetTree().Root.GetNode<SaveNode>("SaveNode").RunData.IsCharacterSelection;
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touchEvent && touchEvent.Pressed)
		{
			OnStartButtonPressed();
		}
	}

	private void OnStartButtonPressed()
	{
		// Exception on missing export value.
		if (TargetScene == null) {
			throw new InvalidOperationException("TargetScene is not assigned in the inspector.");
		}

		// Goto scene from loadfile if character select
		var saveNode = GetTree().Root.GetNode<SaveNode>("SaveNode");
		if (!pathCharacterSelect)
		{

			GetTree().ChangeSceneToPacked(saveNode.LoadPackedSceneFromLocation());
			return;
		}

		// Otherwise, go to character select
		GetTree().ChangeSceneToPacked(TargetScene);

	}
}

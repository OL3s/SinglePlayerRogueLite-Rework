using Godot;
using System;
using Animation;

public partial class TapToStart : Control
{
	[ExportGroup("ScenePaths")]
	[Export] PackedScene CharacterSelectScene { get; set; }
	[Export] PackedScene OutpostScene { get; set; }
	[ExportGroup("Label Properties")]
	[Export] Label LabelTapToStart { get; set; }
	[Export] public float SetFadeInStartTime { get; set; } = 4f;
	[Export] public float SetFadeSpeed { get; set; } = 0.4f;
	[Export] public string TextNewGame { get; set; } = "Tap to start your adventure";
	[Export] public string TextContinue { get; set; } = "Tap to continue the adventure";
	private double _timer = 0f;
	private PackedScene TargetScene => pathCharacterSelect ? CharacterSelectScene : OutpostScene;
	private bool pathCharacterSelect 
		=> GetTree().Root.GetNode<SaveNode>("SaveNode").RunData.PlayerData == null;
	
	public override void _Ready()
	{
		base._Ready();
		if (LabelTapToStart == null)
		{
			GD.PrintErr("LabelTapToStart must be assigned in the editor.");
			return;
		}
		LabelTapToStart.Text = pathCharacterSelect ? TextNewGame : TextContinue;
	}
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touchEvent && touchEvent.Pressed)
		{
			OnStartButtonPressed();
		}
	}

	public override void _Process(double delta)
	{
		// Fade in the "Tap to Start" text after a delay
		if (LabelTapToStart == null) return;
		
		if (_timer > SetFadeInStartTime)
		{
			float alpha = PositionModifiers.Floating((float)(_timer - SetFadeInStartTime), SetFadeSpeed, 1);
			LabelTapToStart.Modulate = new Color(1, 1, 1, alpha);
		}
		else
		{
			LabelTapToStart.Modulate = new Color(1, 1, 1, 0);
		}
		
		_timer += delta;
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

			GetTree().ChangeSceneToPacked(TargetScene);
			return;
		}

		// Otherwise, go to character select
		GetTree().ChangeSceneToPacked(TargetScene);

	}
}

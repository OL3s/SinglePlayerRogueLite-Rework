using Godot;
using System;

public partial class CharacterSelectComponent : Control
{
	[Export] public PlayerData StartingGear { get; set; }
	[Export] public PackedScene OutpostScene { get; set; }
	[Export] public Button ButtonSelect { get; set; }
	[Export] public double TimerOffset { get; set; } = 0f;
	[Export] public float AnimationSpeed { get; set; } = 3f;
	private Vector2 _startPos;

	public override void _Ready()
	{
		base._Ready();
		_startPos = ButtonSelect.Position;
		if (ButtonSelect == null)
		{
			GD.PrintErr("ButtonSelect must be assigned in the editor.");
			return;
		}

		if (OutpostScene == null)
		{
			GD.PrintErr("OutpostScene must be assigned in the editor.");
			return;
		}
		ButtonSelect.Pressed += OnButtonPressed;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		if (ButtonSelect == null)
			return;
		var offset = Animation.PositionModifiers.Floating(TimerOffset, AnimationSpeed, 4f);
		TimerOffset += delta;
		ButtonSelect.Position = new Vector2(_startPos.X, _startPos.Y + offset);
	}

	private void OnButtonPressed()
	{
		GD.Print("CharacterSelectComponent clicked. Starting new game with StartingGear: " + StartingGear);
		var saveNode = GetNode<SaveNode>("/root/SaveNode");
		saveNode.RunData.PlayerData = StartingGear;
		saveNode.SaveRunData();
		GetTree().ChangeSceneToPacked(OutpostScene);
	}
}

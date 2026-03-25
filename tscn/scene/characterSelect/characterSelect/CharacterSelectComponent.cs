using Godot;
using System;

public partial class CharacterSelectComponent : Control
{
	[Export] public PlayerData StartingGear { get; set; }
	[Export] public PackedScene OutpostScene { get; set; }
	[Export] public Button ButtonSelect { get; set; }

	public override void _Ready()
	{
		base._Ready();
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

	private void OnButtonPressed()
	{
		GD.Print("CharacterSelectComponent clicked. Starting new game with StartingGear: " + StartingGear);
		var saveNode = GetNode<SaveNode>("/root/SaveNode");
		saveNode.RunData.PlayerData = StartingGear;
		saveNode.SaveRunData();
		GetTree().ChangeSceneToPacked(OutpostScene);
	}
}

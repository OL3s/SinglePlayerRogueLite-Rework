using Godot;
using MyTypes;

public partial class ContractSelectComponent : Control
{
	[Export] public Contract SetPath { get; set; }
	[Export] public Button ButtonSelect { get; set; }

	public override void _Ready()
	{
		if (ButtonSelect == null)
		{
			GD.PrintErr("ButtonSelect must be assigned in the editor.");
			return;
		}


		ButtonSelect.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GD.Print("TODO: ContractSelectComponent clicked. Starting new game with Contract: " + SetPath);
	}
}

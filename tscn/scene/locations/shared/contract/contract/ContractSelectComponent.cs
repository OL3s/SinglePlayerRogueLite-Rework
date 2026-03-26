using System.Collections;
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
		if (SetPath == null)
		{
			GD.PrintErr("SetPath must be assigned in the editor.");
			return;
		}
		SaveNode.Get().RunData.CurrentContract = SetPath;
		SignalHandler.Get()?.EmitSignal(SignalTypes.Signals.ContractSelected);
		GlobalOverlay.CloseOverlayStatic();
	}
}

using System.Collections;
using Godot;
using MyTypes;

public partial class ContractSelectComponent : Control
{
	[Export] public Contract SetContract { get; set; }
	[Export] public ContractIconsDict IconDict { get; set; }
	[Export] public TextureRect IconLocation { get; set; }
	[Export] public TextureRect IconBiome { get; set; }
	[Signal] public delegate void ContractUpdatedEventHandler();

	public override void _Ready()
	{
		UpdateContract(SetContract ?? new Contract());
	}

	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			OnButtonPressed();
		}
	}

	private void OnButtonPressed()
	{
		if (SetContract == null)
		{
			GD.PrintErr("SetContract must be assigned in the editor.");
			return;
		}
		SaveNode.Get().RunData.CurrentContract = SetContract;
		SignalHandler.Get()?.EmitSignal(SignalTypes.Signals.ContractSelected);
		GlobalOverlay.CloseOverlayStatic();
	}

	public void UpdateContract(Contract contract)
	{
		SetContract = contract;
		if (SetContract == null)
		{
			GD.PrintErr("SetContract must be assigned in the editor.");
			return;
		}

		IconLocation.Texture = IconDict.GetLocationText2D(SetContract.EndLocation);
		IconBiome.Texture = IconDict.GetBiomeText2D(SetContract.Biome);
	}
}

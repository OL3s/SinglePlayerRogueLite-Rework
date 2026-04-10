using System.Collections;
using Godot;
using MyTypes;

public partial class ContractSelectComponent : Control
{
	[ExportGroup("Contract Data")]
	[Export] public Contract SetContract { get; set; }
	[Export] public ContractIconsDict IconDict { get; set; }
	[ExportGroup("UI Elements")]
	[Export] public TextureRect IconLocation { get; set; }
	[Export] public TextureRect IconBiome { get; set; }
	[Export] public Control ShaderBackground { get; set; }
	[Export] public Label LabelLocation { get; set; }
	[Export] public Label LabelBiome { get; set; }
	[ExportGroup("Animation")]
	[Export] public double TimerOffset { get; set; } = 0;
	[Export] public Panel PanelFloat { get; set; }
	private Vector2 _startPos;

	public override void _Ready()
	{		
		base._Ready();
		// check ui elements
		if (IconLocation == null || IconBiome == null || ShaderBackground == null || LabelLocation == null || LabelBiome == null || PanelFloat == null)
		{
			GD.PrintErr("All UI elements must be assigned in the editor.");
			return;
		}

		_startPos = Position;
		if (SetContract != null)
		{
			UpdateContract(SetContract);
			return;
		}

	}

	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			OnButtonPressed();
		}
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		var offset = Animation.PositionModifiers.Floating(TimerOffset, 3f, 4f);
		TimerOffset += delta;
		PanelFloat.Position = new Vector2(_startPos.X, _startPos.Y + offset);
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
		Material mat = IconDict.GetBiomeShader(SetContract.Biome);
		ShaderBackground.Material = mat;
		LabelLocation.Text = SetContract.EndLocation.ToString();
		LabelBiome.Text = SetContract.Biome.ToString()[..^1];
	}
}

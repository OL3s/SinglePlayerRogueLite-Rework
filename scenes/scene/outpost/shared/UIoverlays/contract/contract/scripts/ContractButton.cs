using Godot;

public partial class ContractButton : Button
{
	[ExportGroup("ScenePaths")]
	[Export] public PackedScene UiScene;
	[Export] public PackedScene ExecuteScene;
	[ExportGroup("TexturePaths")]
	[Export] public Texture2D NoContractTexture;
	[Export] public Texture2D HasContractTexture;
	[ExportGroup("LabelProperties")]
	[Export] public string MsgSelect = "Contract";
	[Export] public string MsgStart = "GO!";
	private double _timer;
	private bool _hasContract => SaveNode.Get().RunData.CurrentContract != null;
	public override void _Ready()
	{
		UpdateTexture();
		SignalHandler.Subscribe(SignalTypes.Signals.ContractSelected, UpdateTexture);
	}

	public override void _ExitTree()
	{
		SignalHandler.Unsubscribe(SignalTypes.Signals.ContractSelected, UpdateTexture);
	}

	public override void _Pressed()
	{
		if (!_hasContract)
		{
			if (UiScene == null)
			{
				GD.PushError("PackedScene is null, no scene to open");
				return;
			}
			GetTree().Root.GetNode<GlobalOverlay>("GlobalOverlay").AddOverlay(UiScene.Instantiate<Control>());
			return;
		}

		if (_hasContract)
		{
			if (ExecuteScene == null)
			{
				GD.PushError("PackedScene is null, no scene to open");
				return;
			}
			GlobalOverlay.ChangeScenePackedStatic(ExecuteScene);
				return;
		}
	}

	public override void _Process(double delta)
	{
		Rotation = (_hasContract)
			? Animation.PositionModifiers.Sway(_timer, 4f, Mathf.Pi / 32f)
			: 0f;
		_timer += delta;
	}

	private void UpdateTexture(SignalTypes.Signals signalType)
	{
		Icon = _hasContract ? HasContractTexture : NoContractTexture;
		Text = _hasContract ? MsgStart : MsgSelect;
	}

	private void UpdateTexture()
	{
		Icon = _hasContract ? HasContractTexture : NoContractTexture;
		Text = _hasContract ? MsgStart : MsgSelect;
	}
}

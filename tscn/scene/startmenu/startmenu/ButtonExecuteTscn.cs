using Godot;

public partial class ButtonExecuteTscn  : Button
{
	[Export] public PackedScene UiScene;

	private Node _uiInstance;

	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("[ButtonOpenUI] UiScene is null");
			return;
		}

		// Toggle
		if (_uiInstance != null && IsInstanceValid(_uiInstance))
		{
			_uiInstance.QueueFree();
			_uiInstance = null;
			GD.Print("[ButtonOpenUI] UI closed");
			return;
		}

		_uiInstance = UiScene.Instantiate();

		if (_uiInstance == null)
		{
			GD.PushError("[ButtonOpenUI] Failed to instantiate UiScene");
			return;
		}

		GetTree().Root.AddChild(_uiInstance);
		GD.Print("[ButtonOpenUI] UI opened");
	}
}

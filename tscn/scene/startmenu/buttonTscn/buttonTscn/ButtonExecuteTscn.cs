using Godot;

public partial class ButtonExecuteTscn : Button
{
	[Signal]
	public delegate void UiButtonPressedEventHandler(ButtonExecuteTscn button, string scenePath);
	private static ButtonExecuteTscn _openButton;
	[Export] public PackedScene UiScene;
	[Export] bool ChangeToScene;
	private Node _uiInstance;

	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("[ButtonOpenUI] UiScene is null, no scene to open");
			return;
		}

		EmitSignal(SignalName.UiButtonPressed, this, UiScene.ResourcePath);

		if (_openButton == this && _uiInstance != null && IsInstanceValid(_uiInstance))
		{
			CloseUi();
			GD.Print("[ButtonOpenUI] UI closed");
			return;
		}

		CloseOpenUi();

		if (ChangeToScene)
		{
			GetTree().ChangeSceneToPacked(UiScene);
			return;
		}

		_uiInstance = UiScene.Instantiate();

		if (_uiInstance == null)
		{
			GD.PushError("[ButtonOpenUI] Failed to instantiate UiScene");
			return;
		}

		_uiInstance.Connect(Node.SignalName.TreeExiting, Callable.From(OnUiTreeExiting));
		GetTree().Root.AddChild(_uiInstance);
		_openButton = this;
		GD.Print("[ButtonOpenUI] UI opened");
	}

	public override void _ExitTree()
	{
		if (_openButton == this)
		{
			CloseUi();
		}
	}

	private static void CloseOpenUi()
	{
		if (_openButton == null)
		{
			return;
		}

		_openButton.CloseUi();
	}

	private void CloseUi()
	{
		if (_uiInstance != null && IsInstanceValid(_uiInstance))
		{
			_uiInstance.QueueFree();
		}

		_uiInstance = null;

		if (_openButton == this)
		{
			_openButton = null;
		}
	}

	private void OnUiTreeExiting()
	{
		_uiInstance = null;

		if (_openButton == this)
		{
			_openButton = null;
		}
	}
}

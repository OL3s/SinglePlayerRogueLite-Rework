using Godot;

public partial class ButtonExecuteOverlay : BaseButton
{
	[Export] public PackedScene UiScene;
	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("PackedScene is null, no scene to open");
			return;
		}

		GlobalOverlay.AddOverlayStatic(UiScene.Instantiate<Control>());
	}
}

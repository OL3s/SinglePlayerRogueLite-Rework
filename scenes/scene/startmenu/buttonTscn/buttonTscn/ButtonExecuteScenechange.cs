using Godot;

public partial class ButtonExecuteScenechange : BaseButton
{
	[Export] public PackedScene UiScene;
	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("PackedScene is null, no scene to open");
			return;
		}

		GlobalOverlay.ChangeScenePackedStatic(UiScene);
	}
}

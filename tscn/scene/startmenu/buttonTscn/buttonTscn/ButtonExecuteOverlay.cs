using Godot;

public partial class ButtonExecuteOverlay : Button
{
	[Export] public PackedScene UiScene;
	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("PackedScene is null, no scene to open");
			return;
		}

		GetTree().Root.GetNode<GlobalOverlay>("GlobalOverlay").AddOverlay(UiScene.Instantiate<Control>());
	}
}

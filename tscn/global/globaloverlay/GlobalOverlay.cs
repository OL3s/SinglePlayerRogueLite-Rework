using Godot;
using System;
using Animation;

public partial class GlobalOverlay : CanvasLayer
{
	private const int OverlayLayer = 100;
	private float OverlayScale = 1f;
	private string currentChildName => GetChildCount() > 0 ? GetChild(0).Name : null;

	// Static method to access the GlobalOverlay instance from anywhere in the code.
	public static GlobalOverlay Get()
	{
		var sceneTree = Engine.GetMainLoop() as SceneTree;
		return sceneTree?.Root?.GetNodeOrNull<GlobalOverlay>("/root/GlobalOverlay");
	}
	public static void AddOverlayStatic(Control overlay) => Get().AddOverlay(overlay);
	public static void CloseOverlayStatic() => Get().CloseOverlay();
	public static void ChangeScenePackedStatic(PackedScene newScene) => Get().ChangeScenePacked(newScene);
	public static bool IsOverlayActive() => Get().GetChildCount() > 0;
	public override void _Ready()
	{
		base._Ready();
		GD.Print("GlobalOverlay is ready and can now manage overlays.");
		Layer = OverlayLayer;
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
		if (OverlayScale < 1) OverlayScale = PositionModifiers.Lerp(OverlayScale, 1, .3f);
		if (IsOverlayActive())
		{
			var child = GetChildOrNull<Control>(0);
			if (child != null) child.Scale = new Vector2(OverlayScale, OverlayScale);
		}

	}
	public void AddOverlay(Control overlay)
	{
		// Failcheck to ensure we don't add a null overlay
		if (overlay == null)
		{
			GD.PushError("Overlay is null, cannot show.");
			return;
		}

		// Remove if requested overlay is already present.
		if (currentChildName == overlay.Name)
		{
			GD.Print($"Overlay '{overlay.Name}' is already displayed, removing it.");
			GetChild(0).QueueFree();
			return;
		}

		// Clear existing overlay if it's different from the new one.
		if (GetChildCount() > 0)
		{
			GD.Print($"Removing existing overlay: {currentChildName}");
			GetChild(0).QueueFree();
		}

		// Add the new overlay.
		this.AddChild(overlay);
		OverlayScale = .75f;
		GD.Print($"Added overlay: {overlay.Name}");
	}

	public void CloseOverlay()
	{
		if (GetChildCount() > 0)
		{
			GD.Print($"Closing overlay: {currentChildName}");
			GetChild(0).QueueFree();
		}
		else
		{
			GD.Print("No overlay to close.");
		}
	}

	public void ChangeScenePacked(PackedScene newScene)
	{
		if (newScene == null)
		{
			GD.PushError("New scene is null, cannot change.");
			return;
		}

		// Clear existing overlay if present.
		if (GetChildCount() > 0)
		{
			GD.Print($"Removing existing overlay: {currentChildName}");
			GetChild(0).QueueFree();
		}

		// Add the new scene as an overlay.
		GetTree().ChangeSceneToPacked(newScene);
		GD.Print($"Changed to new scene overlay: {newScene.ResourcePath}");
	}
}

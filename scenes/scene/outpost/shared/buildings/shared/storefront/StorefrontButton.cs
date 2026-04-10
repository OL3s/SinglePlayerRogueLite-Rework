using Godot;
using System;
using MyTypes;

public partial class StorefrontButton : ButtonExecuteOverlay
{
	[Export] BuildingTypes StoreType { get; set; }
	public override void _Pressed()
	{
		if (UiScene == null)
		{
			GD.PushError("PackedScene is null, no scene to open");
			return;
		}

		var storefrontScene = UiScene.Instantiate<Control>() as Storefront;
		if (storefrontScene == null)
		{
			GD.PushError("Failed to instantiate Storefront scene. Ensure the PackedScene is of type Control and has a Storefront script attached.");
			return;
		}
		storefrontScene.StoreType = StoreType; // Set the store type before adding to overlay
		storefrontScene.UpdateStorefront(); // Update the storefront to reflect the new store type
		GlobalOverlay.AddOverlayStatic(storefrontScene);
	}

}

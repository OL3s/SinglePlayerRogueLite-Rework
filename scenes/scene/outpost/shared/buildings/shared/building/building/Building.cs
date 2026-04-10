using Godot;
using System;
using MyTypes;

public partial class Building : Control
{    
	[Export] public BuildingTypes BuildingType { get; set; }
	[Export] public TextureRect BuildingTexture { get; set; }
	public Biomes Biome => SaveNode.Get().RunData.CurrentBiome;
	public string DisplayName => BuildingExtensions.GetDisplayName(BuildingType);
	public string OwnerName => BuildingExtensions.GetOwnerName(BuildingType, Biome);

	public override void _Ready()
	{
		base._Ready();
		if (BuildingTexture == null)
			throw new InvalidOperationException("BuildingTexture is not assigned in the editor. Please assign a TextureRect to display the building's image.");
		UpdateBuilding(BuildingType);
	}

	public void UpdateBuilding(BuildingTypes buildingType)
	{
		BuildingType = buildingType;
		BuildingTexture.Texture = BuildingExtensions.GetBuildingTexture(BuildingType, Biome);
	}

	public override void _GuiInput(InputEvent @event)
	{
		base._GuiInput(@event);
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			var loadScene = BuildingExtensions.GetScene(BuildingType).Instantiate<Control>();
			if (loadScene == null)
				throw new InvalidOperationException($"Failed to instantiate scene for building type {BuildingType}. Ensure the PackedScene is of type Control and has the correct script attached.");
		
			if (loadScene is Storefront storefrontScene)
			{
				storefrontScene.UpdateStorefront(BuildingType); // Set the store type before adding to overlay
			}

			GlobalOverlay.AddOverlayStatic(loadScene);
			@event.Dispose(); // Mark the event as handled to prevent further processing
		}
	}

}

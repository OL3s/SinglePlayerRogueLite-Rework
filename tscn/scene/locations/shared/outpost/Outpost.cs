using Godot;
using System;
using MyTypes;

public partial class Outpost : Control
{
	[Export] Locations Location = Locations.Village;
	[Export] bool EnableLocationOverlay = true;
	[Export] PackedScene AssetVillage;
	[Export] PackedScene AssetSanctuary;
	[Export] PackedScene AssetCampsite;
	public override void _Ready()
	{
		// Ignore if disabled overlay
		if (!EnableLocationOverlay) 
			return;

		// Exceptions
		if (AssetVillage == null || AssetSanctuary == null || AssetCampsite == null)
			GD.PrintErr("Asset for one or more locations are missing");

		// Fetch Asset
		var _currentOverlay = GetPackedScene(Location).InstantiateOrNull<Control>();
		if (_currentOverlay == null)
			throw new Exception("GetPackedScene null return");
		AddChild(_currentOverlay);
	}

	private PackedScene GetPackedScene(Locations location) => location switch
	{
		Locations.Village => AssetVillage,
		Locations.Campsite => AssetCampsite,
		Locations.Sanctuary => AssetSanctuary,
		_ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
	};

}

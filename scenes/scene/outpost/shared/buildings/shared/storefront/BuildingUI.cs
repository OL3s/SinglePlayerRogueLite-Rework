using Godot;
using MyTypes;
using System;

public partial class BuildingUI : Control
{
	[Export] public BuildingTypes BuildingType { get; set; }
	[Export] public Storefront Storefront { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (Storefront == null)
		{
			GD.PrintErr("BuildingUI: Storefront is not assigned in the editor.");
			return;
		}
		Storefront.UpdateStorefront(BuildingType);
	}
}

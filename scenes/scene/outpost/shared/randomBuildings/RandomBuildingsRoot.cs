using Godot;
using Godot.Collections;
using System;
using MyTypes;

public partial class RandomBuildingsRoot : Node
{
	[Export] public Array<Control> NodesToRandomize;
	[Export] public Array<BuildingTypes> BuildingTypesToUse;
	[ExportGroup("PackedScenes for Each Building Type")]
	[Export] public PackedScene TavernScene;
	[Export] public PackedScene MerchantScene;
	[Export] public PackedScene BlacksmithScene;
	[Export] public PackedScene GoldsmithScene;
	[Export] public PackedScene AlchemistScene;
	[Export] public PackedScene FletcherScene;
	[Export] public PackedScene ArcanistScene;
	[Export] public PackedScene EnchanterScene;
	
	
	public override void _Ready()
	{
		// Exception handling
		if (NodesToRandomize == null || NodesToRandomize.Count == 0)
			throw new InvalidOperationException("RandomBuildingsRoot: No nodes assigned to randomize.");
		if (BuildingTypesToUse == null || BuildingTypesToUse.Count == 0)        
			throw new InvalidOperationException("RandomBuildingsRoot: No building types assigned to use.");
		if (NodesToRandomize.Count > BuildingTypesToUse.Count)
			throw new InvalidOperationException("RandomBuildingsRoot: More nodes to randomize than building types available. Ensure there are enough building types for the number of nodes.");
	} 

	
}

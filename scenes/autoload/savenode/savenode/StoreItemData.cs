using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class StoreItemData : Resource
{
	[Export] public Array<ItemBase> TavernItems { get; set; }
	[Export] public Array<ItemBase> MerchantItems { get; set; }
	[Export] public Array<ItemBase> BlacksmithItems { get; set; }
	[Export] public Array<ItemBase> GoldsmithItems { get; set; }
	[Export] public Array<ItemBase> AlchemistItems { get; set; }
	[Export] public Array<ItemBase> FletcherItems { get; set; }
	[Export] public Array<ItemBase> ArcanistItems { get; set; }
	[Export] public Array<ItemBase> EnchanterItems { get; set; }

	public StoreItemData()
	{
	}

	public void GenerateMissingItems(MyTypes.Biomes biome)
	{
		TavernItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Tavern, biome);
		MerchantItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Merchant, biome);
		BlacksmithItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Blacksmith, biome);
		GoldsmithItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Goldsmith, biome);
		AlchemistItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Alchemist, biome);
		FletcherItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Fletcher, biome);
		ArcanistItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Arcanist, biome);
		EnchanterItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Enchanter, biome);
	}

	public Array<ItemBase> GetItemsForBuildingType(MyTypes.BuildingTypes buildingType)
	{
		
		return buildingType switch
		{
			MyTypes.BuildingTypes.Tavern => TavernItems,
			MyTypes.BuildingTypes.Merchant => MerchantItems,
			MyTypes.BuildingTypes.Blacksmith => BlacksmithItems,
			MyTypes.BuildingTypes.Goldsmith => GoldsmithItems,
			MyTypes.BuildingTypes.Alchemist => AlchemistItems,
			MyTypes.BuildingTypes.Fletcher => FletcherItems,
			MyTypes.BuildingTypes.Arcanist => ArcanistItems,
			MyTypes.BuildingTypes.Enchanter => EnchanterItems,
			_ => null
		};
	}

	public static Array<ItemBase> GetItemsForBuildingTypeStatic(MyTypes.BuildingTypes buildingType)
	{
		var storeData = SaveNode.Get().StoreData;
		return storeData.GetItemsForBuildingType(buildingType);
	}

	private Array<ItemBase> GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes buildingType, MyTypes.Biomes biome)
	{
		var placeholderimage = new PlaceholderTexture2D();
		placeholderimage.Size = new Vector2(64, 64);
		return new Array<ItemBase>() { 
			new ItemBase(
				$"{buildingType} Item 1 (Biome: {biome})", 
				placeholderimage, 
				1
			),
			new ItemBase(
				$"{buildingType} Item 2 (Biome: {biome})", 
				placeholderimage, 
				1
			)
		};

	}

	public void ClearAllItems()
	{
		TavernItems = new Array<ItemBase>();
		MerchantItems = new Array<ItemBase>();
		BlacksmithItems = new Array<ItemBase>();
		GoldsmithItems = new Array<ItemBase>();
		AlchemistItems = new Array<ItemBase>();
		FletcherItems = new Array<ItemBase>();
		ArcanistItems = new Array<ItemBase>();
		EnchanterItems = new Array<ItemBase>();
	}

	public override string ToString()
	{
		return $"StoreItemData: TavernItems={TavernItems}, MerchantItems={MerchantItems}, BlacksmithItems={BlacksmithItems}, GoldsmithItems={GoldsmithItems}, AlchemistItems={AlchemistItems}, FletcherItems={FletcherItems}, ArcanistItems={ArcanistItems}, EnchanterItems={EnchanterItems}";
	}
}

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
		GenerateMissingItems();
	}

	public void GenerateMissingItems()
	{
		TavernItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Tavern);
		MerchantItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Merchant);
		BlacksmithItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Blacksmith);
		GoldsmithItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Goldsmith);
		AlchemistItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Alchemist);
		FletcherItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Fletcher);
		ArcanistItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Arcanist);
		EnchanterItems ??= GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes.Enchanter);
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

	private Array<ItemBase> GenerateRandomStoreItemsForBuilding(MyTypes.BuildingTypes buildingType)
	{
		var biome = SaveNode.Get().RunData.CurrentBiome;
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

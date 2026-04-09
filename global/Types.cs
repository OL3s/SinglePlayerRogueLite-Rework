using Godot;
using System;

namespace MyTypes {

	public enum Biomes
	{
		Undefined = 0,
		GrasslandsA = 1,
		TundraB = 2,
		DesertB = 3,
		IcyC = 4,
		JungleC = 5,
		LavaC = 6,
		IceBossD = 7,
		JungleBossD = 8,
		LavaBossD = 9,
	}

	public enum Locations 
	{
		Undefined = 0,
		Village = 1,
		Sanctuary = 2,
		Campsite = 3
	}
}

namespace SaveData
{
	public enum FileType
	{
		Meta,
		Run,
		Settings
	}
}

namespace SignalTypes
{
	public enum Signals
	{
		ContractSelected,
		ItemBought
	}
}

namespace BuildingTypes
{
	public enum StorefrontTypes
	{
		General,
		Merchant,
		Blacksmith,
		Alchemist,
		Fletcher,
		Letherworker,
		Mage,
		Florist,
		Innkeeper
	}

	public enum UpgradeTypes
	{
		Smithy,
		Enchanter,
		Florist,
		Bakery
	}

	public enum BuildingTypes
	{
		Storefront,
		Tavern,
		Upgrade
	}
}
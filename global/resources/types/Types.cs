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

	public enum BuildingTypes
	{
		Tavern,
		Merchant,
		Blacksmith,
		Goldsmith,
		Alchemist,
		Fletcher,
		Arcanist,
		Enchanter,
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
		PurchaseItem,
	}
}

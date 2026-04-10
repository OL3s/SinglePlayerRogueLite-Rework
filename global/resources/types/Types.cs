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

	public static class BuildingExtensions {
		public static string GetDisplayName(BuildingTypes buildingType)
		{
			return buildingType switch
			{
				BuildingTypes.Tavern => "Tavern",
				BuildingTypes.Merchant => "Merchant",
				BuildingTypes.Blacksmith => "Blacksmith",
				BuildingTypes.Goldsmith => "Goldsmith",
				BuildingTypes.Alchemist => "Alchemist",
				BuildingTypes.Fletcher => "Fletcher",
				BuildingTypes.Arcanist => "Arcanist",
				BuildingTypes.Enchanter => "Enchanter",
				_ => "Unknown"
			};
		}
	
		public static string GetOwnerName(BuildingTypes buildingType, Biomes biome)
		{
			return buildingType switch
			{
				BuildingTypes.Tavern => biome switch
				{
					Biomes.GrasslandsA => "Borin",
					Biomes.TundraB => "Sigrid",
					Biomes.DesertB => "Khalid",
					Biomes.IcyC => "Freya",
					Biomes.JungleC => "Ravi",
					Biomes.LavaC => "Gorath",
					Biomes.IceBossD => "Thrym",
					Biomes.JungleBossD => "Xal'Zar",
					Biomes.LavaBossD => "Zarok",
					_ => "Unknown"
				},
				BuildingTypes.Merchant => biome switch
				{
					Biomes.GrasslandsA => "Lydia",
					Biomes.TundraB => "Erik",
					Biomes.DesertB => "Amara",
					Biomes.IcyC => "Sven",
					Biomes.JungleC => "Maya",
					Biomes.LavaC => "Drax",
					Biomes.IceBossD => "Bjorn",
					Biomes.JungleBossD => "Zara",
					Biomes.LavaBossD => "Kargath",
					_ => "Unknown"
				},
				_ => "Unknown"
			};
		}
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

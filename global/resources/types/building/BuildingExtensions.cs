using Godot;
using MyTypes;
using System;

[GlobalClass]
public partial class BuildingExtensions : Resource {
	
	[ExportGroup("Building Scene Paths")]
	[Export] public PackedScene TavernScene;
	[Export] public PackedScene MerchantScene;
	[Export] public PackedScene BlacksmithScene;
	[Export] public PackedScene GoldsmithScene;
	[Export] public PackedScene AlchemistScene;
	[Export] public PackedScene FletcherScene;
	[Export] public PackedScene ArcanistScene;
	[Export] public PackedScene EnchanterScene;
	[ExportGroup("Building Textures")]
	[ExportSubgroup("Tavern")]
	[Export] public Texture2D TavernTextureGrasslands;
	[Export] public Texture2D TavernTextureTundra;
	[Export] public Texture2D TavernTextureDesert;
	[Export] public Texture2D TavernTextureIcy;
	[Export] public Texture2D TavernTextureJungle;
	[Export] public Texture2D TavernTextureLava;
	[ExportSubgroup("Merchant")]
	[Export] public Texture2D MerchantTextureGrasslands;
	[Export] public Texture2D MerchantTextureTundra;
	[Export] public Texture2D MerchantTextureDesert;
	[Export] public Texture2D MerchantTextureIcy;
	[Export] public Texture2D MerchantTextureJungle;
	[Export] public Texture2D MerchantTextureLava;
	[ExportSubgroup("Blacksmith")]
	[Export] public Texture2D BlacksmithTextureGrasslands;
	[Export] public Texture2D BlacksmithTextureTundra;
	[Export] public Texture2D BlacksmithTextureDesert;
	[Export] public Texture2D BlacksmithTextureIcy;
	[Export] public Texture2D BlacksmithTextureJungle;
	[Export] public Texture2D BlacksmithTextureLava;
	[ExportSubgroup("Goldsmith")]
	[Export] public Texture2D GoldsmithTextureGrasslands;
	[Export] public Texture2D GoldsmithTextureTundra;
	[Export] public Texture2D GoldsmithTextureDesert;
	[Export] public Texture2D GoldsmithTextureIcy;
	[Export] public Texture2D GoldsmithTextureJungle;
	[Export] public Texture2D GoldsmithTextureLava;
	[ExportSubgroup("Alchemist")]
	[Export] public Texture2D AlchemistTextureGrasslands;
	[Export] public Texture2D AlchemistTextureTundra;
	[Export] public Texture2D AlchemistTextureDesert;
	[Export] public Texture2D AlchemistTextureIcy;
	[Export] public Texture2D AlchemistTextureJungle;
	[Export] public Texture2D AlchemistTextureLava;
	[ExportSubgroup("Fletcher")]
	[Export] public Texture2D FletcherTextureGrasslands;
	[Export] public Texture2D FletcherTextureTundra;
	[Export] public Texture2D FletcherTextureDesert;
	[Export] public Texture2D FletcherTextureIcy;
	[Export] public Texture2D FletcherTextureJungle;
	[Export] public Texture2D FletcherTextureLava;
	[ExportSubgroup("Arcanist")]
	[Export] public Texture2D ArcanistTextureGrasslands;
	[Export] public Texture2D ArcanistTextureTundra;
	[Export] public Texture2D ArcanistTextureDesert;
	[Export] public Texture2D ArcanistTextureIcy;
	[Export] public Texture2D ArcanistTextureJungle;
	[Export] public Texture2D ArcanistTextureLava;
	[ExportSubgroup("Enchanter")]
	[Export] public Texture2D EnchanterTextureGrasslands;
	[Export] public Texture2D EnchanterTextureTundra;
	[Export] public Texture2D EnchanterTextureDesert;
	[Export] public Texture2D EnchanterTextureIcy;
	[Export] public Texture2D EnchanterTextureJungle;
	[Export] public Texture2D EnchanterTextureLava;
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
			BuildingTypes.Blacksmith => biome switch
			{
				Biomes.GrasslandsA => "Thorin",
				Biomes.TundraB => "Gunnar",
				Biomes.DesertB => "Rashid",
				Biomes.IcyC => "Hilda",
				Biomes.JungleC => "Kato",
				Biomes.LavaC => "Brak",
				Biomes.IceBossD => "Skadi",
				Biomes.JungleBossD => "Zul'jin",
				Biomes.LavaBossD => "Grimfang",
				_ => "Unknown"
			},
			BuildingTypes.Goldsmith => biome switch
			{
				Biomes.GrasslandsA => "Aurel",
				Biomes.TundraB => "Sofia",
				Biomes.DesertB => "Jamil",
				Biomes.IcyC => "Ingrid",
				Biomes.JungleC => "Lian",
				Biomes.LavaC => "Vex",
				Biomes.IceBossD => "Freyja",
				Biomes.JungleBossD => "Zara",
				Biomes.LavaBossD => "Kargath",
				_ => "Unknown"
			},
			BuildingTypes.Alchemist => biome switch
			{
				Biomes.GrasslandsA => "Elara",
				Biomes.TundraB => "Soren",
				Biomes.DesertB => "Nadia",
				Biomes.IcyC => "Bjorn",
				Biomes.JungleC => "Maya",
				Biomes.LavaC => "Drax",
				Biomes.IceBossD => "Bjorn",
				Biomes.JungleBossD => "Zara",
				Biomes.LavaBossD => "Kargath",
				_ => "Unknown"
			},
			BuildingTypes.Fletcher => biome switch
			{
				Biomes.GrasslandsA => "Rowan",
				Biomes.TundraB => "Eira",
				Biomes.DesertB => "Kade",
				Biomes.IcyC => "Sven",
				Biomes.JungleC => "Maya",
				Biomes.LavaC => "Drax",
				Biomes.IceBossD => "Bjorn",
				Biomes.JungleBossD => "Zara",
				Biomes.LavaBossD => "Kargath",
				_ => "Unknown"
			},
			BuildingTypes.Arcanist => biome switch
			{
				Biomes.GrasslandsA => "Selene",
				Biomes.TundraB => "Alaric",
				Biomes.DesertB => "Zara",
				Biomes.IcyC => "Sven",
				Biomes.JungleC => "Maya",
				Biomes.LavaC => "Drax",
				Biomes.IceBossD => "Bjorn",
				Biomes.JungleBossD => "Zara",
				Biomes.LavaBossD => "Kargath",
				_ => "Unknown"
			},
			BuildingTypes.Enchanter => biome switch
			{
				Biomes.GrasslandsA => "Ilyas",
				Biomes.TundraB => "Freya",
				Biomes.DesertB => "Khalid",
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
	public static PackedScene GetScene(BuildingTypes buildingType)
	{
		var extensions = Get();
		return buildingType switch
		{
			BuildingTypes.Tavern => extensions.TavernScene ?? throw new InvalidOperationException("BuildingExtensions: TavernScene is not assigned in BuildingExtensions.tres. Ensure that TavernScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Merchant => extensions.MerchantScene ?? throw new InvalidOperationException("BuildingExtensions: MerchantScene is not assigned in BuildingExtensions.tres. Ensure that MerchantScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Blacksmith => extensions.BlacksmithScene ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithScene is not assigned in BuildingExtensions.tres. Ensure that BlacksmithScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Goldsmith => extensions.GoldsmithScene ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithScene is not assigned in BuildingExtensions.tres. Ensure that GoldsmithScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Alchemist => extensions.AlchemistScene ?? throw new InvalidOperationException("BuildingExtensions: AlchemistScene is not assigned in BuildingExtensions.tres. Ensure that AlchemistScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Fletcher => extensions.FletcherScene ?? throw new InvalidOperationException("BuildingExtensions: FletcherScene is not assigned in BuildingExtensions.tres. Ensure that FletcherScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Arcanist => extensions.ArcanistScene ?? throw new InvalidOperationException("BuildingExtensions: ArcanistScene is not assigned in BuildingExtensions.tres. Ensure that ArcanistScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			BuildingTypes.Enchanter => extensions.EnchanterScene ?? throw new InvalidOperationException("BuildingExtensions: EnchanterScene is not assigned in BuildingExtensions.tres. Ensure that EnchanterScene is assigned to a valid PackedScene in the BuildingExtensions resource."),
			_ => null
		 };
	}

	public static Texture2D GetBuildingTexture(BuildingTypes buildingType, Biomes biome)
	{
		var extensions = Get();
		return buildingType switch
		{
			BuildingTypes.Tavern => biome switch
			{
				Biomes.GrasslandsA => extensions.TavernTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that TavernTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.TavernTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureTundra is not assigned in BuildingExtensions.tres. Ensure that TavernTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.TavernTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureDesert is not assigned in BuildingExtensions.tres. Ensure that TavernTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.TavernTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureIcy is not assigned in BuildingExtensions.tres. Ensure that TavernTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.TavernTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureJungle is not assigned in BuildingExtensions.tres. Ensure that TavernTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.TavernTextureLava ?? throw new InvalidOperationException("BuildingExtensions: TavernTextureLava is not assigned in BuildingExtensions.tres. Ensure that TavernTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Merchant => biome switch
			{
				Biomes.GrasslandsA => extensions.MerchantTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.MerchantTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureTundra is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.MerchantTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureDesert is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.MerchantTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureIcy is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.MerchantTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureJungle is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.MerchantTextureLava ?? throw new InvalidOperationException("BuildingExtensions: MerchantTextureLava is not assigned in BuildingExtensions.tres. Ensure that MerchantTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Blacksmith => biome switch
			{
				Biomes.GrasslandsA => extensions.BlacksmithTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.BlacksmithTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureTundra is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.BlacksmithTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureDesert is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.BlacksmithTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureIcy is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.BlacksmithTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureJungle is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.BlacksmithTextureLava ?? throw new InvalidOperationException("BuildingExtensions: BlacksmithTextureLava is not assigned in BuildingExtensions.tres. Ensure that BlacksmithTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Goldsmith => biome switch
			{
				Biomes.GrasslandsA => extensions.GoldsmithTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.GoldsmithTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureTundra is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.GoldsmithTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureDesert is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.GoldsmithTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureIcy is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.GoldsmithTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureJungle is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.GoldsmithTextureLava ?? throw new InvalidOperationException("BuildingExtensions: GoldsmithTextureLava is not assigned in BuildingExtensions.tres. Ensure that GoldsmithTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Alchemist => biome switch
			{
				Biomes.GrasslandsA => extensions.AlchemistTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.AlchemistTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureTundra is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.AlchemistTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureDesert is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.AlchemistTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureIcy is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.AlchemistTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureJungle is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.AlchemistTextureLava ?? throw new InvalidOperationException("BuildingExtensions: AlchemistTextureLava is not assigned in BuildingExtensions.tres. Ensure that AlchemistTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Fletcher => biome switch
			{
				Biomes.GrasslandsA => extensions.FletcherTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.FletcherTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureTundra is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.FletcherTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureDesert is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.FletcherTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureIcy is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.FletcherTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureJungle is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.FletcherTextureLava ?? throw new InvalidOperationException("BuildingExtensions: FletcherTextureLava is not assigned in BuildingExtensions.tres. Ensure that FletcherTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Arcanist => biome switch
			{
				Biomes.GrasslandsA => extensions.ArcanistTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.ArcanistTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureTundra is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.ArcanistTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureDesert is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.ArcanistTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureIcy is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.ArcanistTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureJungle is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.ArcanistTextureLava ?? throw new InvalidOperationException("BuildingExtensions: ArcanistTextureLava is not assigned in BuildingExtensions.tres. Ensure that ArcanistTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			BuildingTypes.Enchanter => biome switch
			{
				Biomes.GrasslandsA => extensions.EnchanterTextureGrasslands ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureGrasslands is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureGrasslands is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.TundraB => extensions.EnchanterTextureTundra ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureTundra is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureTundra is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.DesertB => extensions.EnchanterTextureDesert ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureDesert is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureDesert is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.IcyC => extensions.EnchanterTextureIcy ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureIcy is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureIcy is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.JungleC => extensions.EnchanterTextureJungle ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureJungle is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureJungle is assigned to a valid Texture2D in the BuildingExtensions resource."),
				Biomes.LavaC => extensions.EnchanterTextureLava ?? throw new InvalidOperationException("BuildingExtensions: EnchanterTextureLava is not assigned in BuildingExtensions.tres. Ensure that EnchanterTextureLava is assigned to a valid Texture2D in the BuildingExtensions resource."),
				_ => null
			},
			_ => null
		 };
	}
	public static BuildingExtensions Get() => GD.Load<BuildingExtensions>("res://global/resources/types/building/BuildingExtensions.tres") ?? throw new InvalidOperationException("BuildingExtensions: Unable to load BuildingExtensions resource. Ensure that BuildingExtensions.tres exists at the specified path and is properly configured.");
}

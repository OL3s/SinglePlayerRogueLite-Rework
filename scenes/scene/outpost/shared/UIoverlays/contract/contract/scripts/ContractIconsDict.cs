using Godot;
using MyTypes;

[GlobalClass]
public partial class ContractIconsDict : Resource
{
	[Export] public Texture2D IconFallback { get; set; }
	[ExportGroup("Location Icons")]
	[Export] public Texture2D IconLocationCampfire { get; set; }
	[Export] public Texture2D IconLocationSanctuary { get; set; }
	[Export] public Texture2D IconLocationVillage { get; set; }
	[ExportGroup("Biome Icons")]
	[Export] public Texture2D IconBiomeGrasslands { get; set; }
	[Export] public Texture2D IconBiomeTundra { get; set; }
	[Export] public Texture2D IconBiomeDesert { get; set; }
	[Export] public Texture2D IconBiomeIcy { get; set; }
	[Export] public Texture2D IconBiomeJungle { get; set; }
	[Export] public Texture2D IconBiomeLava { get; set; }
	[Export] public Texture2D IconBiomeIceBoss { get; set; }
	[Export] public Texture2D IconBiomeJungleBoss { get; set; }
	[Export] public Texture2D IconBiomeLavaBoss { get; set; }
	[ExportGroup("Shader Biome Materials")]
	[Export] public Material ShaderBiomeGrasslands { get; set; }
	[Export] public Material ShaderBiomeTundra { get; set; }
	[Export] public Material ShaderBiomeDesert { get; set; }
	[Export] public Material ShaderBiomeIcy { get; set; }
	[Export] public Material ShaderBiomeJungle { get; set; }
	[Export] public Material ShaderBiomeLava { get; set; }
	[Export] public Material ShaderBiomeIceBoss { get; set; }
	[Export] public Material ShaderBiomeJungleBoss { get; set; }
	[Export] public Material ShaderBiomeLavaBoss { get; set; }
	[Export] public Material ShaderBiomeFallback { get; set; }

	public Texture2D GetLocationText2D(Locations location)
	{
		return location switch
		{
			Locations.Campsite => IconLocationCampfire,
			Locations.Sanctuary => IconLocationSanctuary,
			Locations.Village => IconLocationVillage,
			_ => IconFallback
		};
	}

	public Texture2D GetBiomeText2D(Biomes biome)
	{
		return biome switch
		{
			Biomes.GrasslandsA => IconBiomeGrasslands,
			Biomes.TundraB => IconBiomeTundra,
			Biomes.DesertB => IconBiomeDesert,
			Biomes.IcyC => IconBiomeIcy,
			Biomes.JungleC => IconBiomeJungle,
			Biomes.LavaC => IconBiomeLava,
			Biomes.IceBossD => IconBiomeIceBoss,
			Biomes.JungleBossD => IconBiomeJungleBoss,
			Biomes.LavaBossD => IconBiomeLavaBoss,
			_ => IconFallback
		};
	}

	public Material GetBiomeShader(Biomes biome)
	{
		return biome switch
		{
			Biomes.GrasslandsA => ShaderBiomeGrasslands,
			Biomes.TundraB => ShaderBiomeTundra,
			Biomes.DesertB => ShaderBiomeDesert,
			Biomes.IcyC => ShaderBiomeIcy,
			Biomes.JungleC => ShaderBiomeJungle,
			Biomes.LavaC => ShaderBiomeLava,
			Biomes.IceBossD => ShaderBiomeIceBoss,
			Biomes.JungleBossD => ShaderBiomeJungleBoss,
			Biomes.LavaBossD => ShaderBiomeLavaBoss,
			_ => ShaderBiomeFallback
		};
	}
}

using Godot;
using System;
using MyTypes;

public partial class BiomePanel : PanelContainer
{
	[Export] public Label BiomeNameLabel { get; set; }
	[Export] public TextureRect BiomeIcon { get; set; }
	[Export] public ContractIconsDict IconDict { get; set; }

	public override void _Ready()
	{
		if (BiomeNameLabel == null || BiomeIcon == null || IconDict == null)
		{
			GD.PrintErr("BiomeNameLabel, BiomeIcon, and IconDict must be assigned in the editor.");
			return;
		}
		// Optionally initialize with a default biome
		UpdateBiome(SaveNode.Get().RunData.CurrentBiome);
	}
	public void UpdateBiome(Biomes biome)
	{
		var name = biome.ToString().Remove(biome.ToString().Length - 1);
		BiomeNameLabel.Text = name;
		BiomeIcon.Texture = IconDict.GetBiomeText2D(biome);
	}

	
}

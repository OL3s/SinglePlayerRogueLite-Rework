using Godot;
using SaveData;
using System;
using MyTypes;

public partial class LocationBackground : TextureRect
{
	[ExportGroup("Properties")]
	[Export] public bool IgnoreUpdateTexture;
	[ExportGroup("Background Textures")]
	[Export] public Texture2D FallBack;
	[Export] public Texture2D GrasslandsA;
	[Export] public Texture2D TundraB;
	[Export] public Texture2D DesertB;
	[Export] public Texture2D IcyC;
	[Export] public Texture2D JungleC;
	[Export] public Texture2D LavaC;
	private RunData rundata => GetTree().Root.GetNode<SaveNode>("SaveNode").RunData;

	public override void _Ready()
	{

		// Exception handling for null RunData or unassigned textures
		if (rundata == null)
		{
			GD.PrintErr("RunData is null. Cannot set background texture.");
			Texture = FallBack;
			return;
		}

		if (FallBack == null || GrasslandsA == null || TundraB == null || DesertB == null || IcyC == null || JungleC == null || LavaC == null)
		{
			GD.PrintErr("One or more background textures are not assigned. Cannot set background texture.");
			Texture = FallBack;
			return;
		}
		
		if (!IgnoreUpdateTexture)
			LoadBackgroundTexture();
	}

	private void LoadBackgroundTexture()
	{
		// Set the texture based on the current location
		SetBackground(rundata.CurrentBiome);
	}

	// Method to set the background texture based on the biome for future use.
	public void SetBackground(Biomes biome)
	{
		Texture = biome switch
		{
			Biomes.GrasslandsA => GrasslandsA,
			Biomes.TundraB => TundraB,
			Biomes.DesertB => DesertB,
			Biomes.IcyC => IcyC,
			Biomes.JungleC => JungleC,
			Biomes.LavaC => LavaC,
			_ => FallBack
		};
	}

	// Overload to set background directly with a texture, with null check.
	public void SetBackground(Texture2D texture)
	{
		Texture = texture ?? FallBack;
	}

}

using Godot;
using System;
using MapGeneration;

[GlobalClass]
public partial class MapGenerator : Resource
{
	[Export] public int Seed = 12345;
	[Export] public bool UseRandomSeed = true;
	[Export] public int Length = 50;
	[Export] public int Padding = 1;
	[Export] public bool SmoothCorners = true;
	[Export] public int DeepThreshold = 8;
	[Export] public int DeepRadius = 1;

	public int ResolveSeed() => UseRandomSeed ? Random.Shared.Next() : Seed;

	public MapGeneratorData GenerateMap() =>
		MapGeneratorData.GenerateMap(ResolveSeed(), Length, Padding, SmoothCorners);
}

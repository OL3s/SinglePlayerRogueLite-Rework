using Godot;
using MyTypes;

public partial class Contract : Resource
{
	[Export] Biomes Biome { get; set; }
	[Export] Locations EndLocation { get; set; }
}

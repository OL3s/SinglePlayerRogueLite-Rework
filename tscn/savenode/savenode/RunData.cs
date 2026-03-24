using Godot;
using MyTypes;

namespace SaveData
{
	[GlobalClass]
	public partial class RunData : SaveResource
	{
		[Export] public Biomes CurrentBiome { get; set; } = Biomes.GrasslandsA;
		[Export] public Locations CurrentLocation { get; set; } = Locations.Village;
		[Export] public bool IsTutorialGameplay { get; set; } = false;
		[Export] public PlayerData PlayerData { get; set; } = new PlayerData();
		[Export] public int Gold { get; set; } = 0;
		public override string ToString()
		{
			return $"RunData: CurrentBiome={CurrentBiome}, IsTutorialGameplay={IsTutorialGameplay}, PlayerData={PlayerData}, Gold={Gold}";
		}
	}

}

using Godot;
using MyTypes;

namespace SaveData
{
	[GlobalClass]
	public partial class RunData : SaveResource
	{
		[Export] public int CurrentLocation { get; set; } = (int)Biomes.GrasslandsA;
		[Export] public bool IsTutorialGameplay { get; set; } = false;
		public override string ToString()
		{
			return $"RunData: CurrentLocation={((Biomes)CurrentLocation).ToString()}, IsTutorialGameplay={IsTutorialGameplay}";
		}
	}

}

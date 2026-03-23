using Godot;

namespace SaveData
{
	[GlobalClass]
	public partial class RunData : SaveResource
	{
		[Export] public int CurrentLocation { get; set; } = (int)Location.GrasslandsA;
		[Export] public bool IsTutorialGameplay { get; set; } = false;
		public override string ToString()
		{
			return $"RunData: CurrentLocation={((Location)CurrentLocation).ToString()}, IsTutorialGameplay={IsTutorialGameplay}";
		}
	}

	public enum Location
	{
		GrasslandsA = 0,
		TundraB = 1,
		DesertB = 2,
		IcyC = 3,
		JungleC = 4,
		LavaC = 5,
		IceBossD = 6,
		JungleBossD = 7,
		LavaBossD = 8,
	}

}

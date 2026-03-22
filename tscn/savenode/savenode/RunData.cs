using Godot;

namespace SaveData
{
	[GlobalClass]
	public partial class RunData : SaveResource
	{
		[Export] public int CurrentLocation { get; set; }
		public override void ResetToDefaults()
		{
			CurrentLocation = (int)Location.GrasslandsA;
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

using Godot;
using Godot.Collections;

namespace SaveData
{
	[GlobalClass]
	public partial class MetaData : SaveResource
	{
		[Export] public Array<bool> CollectedGems { get; set; }
		[Export] public int RunCount { get; set; }

		public override void ResetToDefaults()
		{
			CollectedGems = [false, false, false];
			RunCount = 0;
		}
	}

	public enum Gem
	{
		Red = 0,
		Green = 1,
		Blue = 2,
	}
}

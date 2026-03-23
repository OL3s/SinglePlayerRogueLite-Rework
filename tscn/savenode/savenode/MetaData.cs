using Godot;
using Godot.Collections;

namespace SaveData
{
	[GlobalClass]
	public partial class MetaData : SaveResource
	{
		public bool[] CollectedGems { get; set; } = [false, false, false];
		[Export] public int RunCount { get; set; } = 0;
		[Export] public bool IsFirstTimePlayer { get; set; } = true;
		public override string ToString()
		{
			return $"MetaData: RunCount={RunCount}, IsFirstTimePlayer={IsFirstTimePlayer}, CollectedGems=[{string.Join(", ", CollectedGems)}]";
		}
	}

	public enum Gem
	{
		Red = 0,
		Green = 1,
		Blue = 2,
	}
}

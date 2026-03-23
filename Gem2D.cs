using Godot;

public partial class Gem2D : Sprite2D
{
	[Export] public GemType Type { get; set; } = GemType.Red;
	[Export] public Sprite2D GemSprite { get; set; }
	[Export] public Texture2D GemTextureRed { get; set; }
	[Export] public Texture2D GemTextureGreen { get; set; }
	[Export] public Texture2D GemTextureBlue { get; set; }
	[Export] public Texture2D GemTextureRedBackground { get; set; }
	[Export] public Texture2D GemTextureGreenBackground { get; set; }
	[Export] public Texture2D GemTextureBlueBackground { get; set; }

	public enum GemType
	{
		Red,
		Green,
		Blue
	}

	public override void _Ready()
	{
		base._Ready();
		UpdateGemAppearance();
		CheckForCollection();
	}

	private void UpdateGemAppearance()
	{
		switch (Type)
		{
			case GemType.Red:
				GemSprite.Texture = GemTextureRed;
				Texture = GemTextureRedBackground;
				break;
			case GemType.Green:
				GemSprite.Texture = GemTextureGreen;
				Texture = GemTextureGreenBackground;
				break;
			case GemType.Blue:
				GemSprite.Texture = GemTextureBlue;
				Texture = GemTextureBlueBackground;
				break;
		}
	}

	private void CheckForCollection()
	{
		var saveNode = GetNode<SaveNode>("/root/SaveNode");
		var metaData = saveNode.MetaData;
		GemSprite.Visible = metaData.CollectedGems[(int)Type];
	}


}

using Godot;
using Animation;

public partial class Gem2D : Sprite2D
{
	[Export] public GemType Type { get; set; } = GemType.Red;
	[Export] public Sprite2D GemSprite { get; set; }
	[Export] public bool ForceShowGem { get; set; } = false;
	[ExportGroup("Gem Textures")]
	[Export] public Texture2D GemTextureRed { get; set; }
	[Export] public Texture2D GemTextureGreen { get; set; }
	[Export] public Texture2D GemTextureBlue { get; set; }
	[Export] public Texture2D GemTextureRedBackground { get; set; }
	[Export] public Texture2D GemTextureGreenBackground { get; set; }
	[Export] public Texture2D GemTextureBlueBackground { get; set; }
	private double _timer = 0f;

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

	public override void _Process(double delta)
	{
		// animate the gem
		float setHeight = 4f;
		GemSprite.Position = new Vector2(0, -setHeight + PositionModifiers.InvertedFloating(_timer, 4f, setHeight * GemSprite.Scale.Y));
		_timer += delta;
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
		GemSprite.Visible = ForceShowGem || (Type switch
		{
			GemType.Red => metaData.GemRedCollected,
			GemType.Green => metaData.GemGreenCollected,
			GemType.Blue => metaData.GemBlueCollected,
			_ => true
		});
	}


}

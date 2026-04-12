using Godot;
using System;

public partial class InventoryItem : Control
{
	[Export] public Label LabelName;
	[Export] public TextureRect TextureIcon;
	[Export] public PackedScene InventoryItemShowcaseScene;
	[Export] public ItemBase ItemData;
	public override void _Ready()
	{
		base._Ready();
		if (LabelName == null || TextureIcon == null || InventoryItemShowcaseScene == null)
			throw new InvalidOperationException("All UI elements must be assigned in the inspector.");
	}
	public override void _GuiInput(InputEvent @event)
	{
		base._GuiInput(@event);
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				var showcaseInstance = InventoryItemShowcaseScene.Instantiate<InventoryItemShowcase>();
				showcaseInstance.UpdateShowcase(ItemData);
				GlobalOverlay.Get().AddChild(showcaseInstance);
			}
		}
	}

	public void UpdateItem(ItemBase item)
	{
		if (item == null)
			throw new ArgumentNullException(nameof(item), "Item cannot be null when updating inventory item.");
		ItemData = item;
		LabelName.Text = item.ItemName;
		TextureIcon.Texture = item.Icon;
	}
	
}

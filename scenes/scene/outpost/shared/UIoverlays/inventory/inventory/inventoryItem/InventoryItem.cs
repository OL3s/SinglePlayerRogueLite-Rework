using Godot;
using System;

public partial class InventoryItem : Control
{
	[Export] public Label LabelName;
	[Export] public TextureRect TextureIcon;

	public override void _GuiInput(InputEvent @event)
	{
		base._GuiInput(@event);
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				throw new NotImplementedException("TODO: Implement inventory popup when clicking on an inventory item");
			}
		}
	}

	public void UpdateItem(ItemBase item)
	{
		if (item == null)
			throw new ArgumentNullException(nameof(item), "Item cannot be null when updating inventory item.");
		LabelName.Text = item.ItemName;
		TextureIcon.Texture = item.Icon;
	}
}

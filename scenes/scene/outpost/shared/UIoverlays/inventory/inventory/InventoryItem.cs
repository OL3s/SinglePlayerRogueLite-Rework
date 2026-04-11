using Godot;
using System;

public partial class InventoryItem : Control
{
	[Export] public TextureRect ItemIcon { get; set; }
	[Export] public Label ItemLabel { get; set; }
	public override void _Ready()
	{
		base._Ready();
		if (ItemIcon == null || ItemLabel == null)
		{
			throw new InvalidOperationException("InventoryItem: One or more UI elements are not assigned in the editor.");
		}
	}

	public void UpdateItemDisplay(ItemBase item)
	{
		if (ItemIcon != null)
			ItemIcon.Texture = item.Icon;
		if (ItemLabel != null)
			ItemLabel.Text = item.ItemName;
	}
}

using Godot;
using System;
using MyTypes;

[GlobalClass]
public partial class InventoryLoadoutButton : Button
{
	[Export] public ItemBase Item { get; set; }

	public override void _Ready()
	{
		base._Ready();
		IconAlignment = HorizontalAlignment.Center;
		VerticalIconAlignment = VerticalAlignment.Top;
		Alignment = HorizontalAlignment.Center;
	}

	public void UpdateItem(ItemBase newItem)
	{
		Item = newItem;
		Icon = Item.Icon;
	}
}

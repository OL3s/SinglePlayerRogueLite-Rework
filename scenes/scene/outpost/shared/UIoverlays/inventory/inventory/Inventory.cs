using Godot;
using Godot.Collections;
using System;

public partial class Inventory : Control
{
	[Export] public Container ContainerItems;
	[Export] public PackedScene InventoryItemScene;
	public override void _Ready()
	{
		if (ContainerItems == null || InventoryItemScene == null)
			throw new InvalidOperationException("ContainerItems and InventoryItemScene must be assigned in the inspector.");
		
		UpdateInventory();
	}
	public void UpdateInventory()
	{
		ClearInventory();
		var inventory = SaveNode.Get().InventoryData.Items;
		foreach (var item in inventory)
		{
			var itemInstance = InventoryItemScene.Instantiate<InventoryItem>();
			itemInstance.UpdateItem(item);
			ContainerItems.AddChild(itemInstance);
		}
	}
	private void ClearInventory()
	{
		foreach (var item in ContainerItems.GetChildren())
		{
			item.QueueFree();
		}
	}
}

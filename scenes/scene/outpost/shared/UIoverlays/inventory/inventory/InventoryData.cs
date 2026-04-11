using Godot;
using Godot.Collections;
using System;
using MyTypes;

[GlobalClass]
public partial class InventoryData : Resource
{
	[Export] public Array<ItemBase> Items { get; set; } = new Array<ItemBase>();
	
	public InventoryData()
	{
	}

	public void AddItem(ItemBase item)
	{
		Items.Add(item);
	}

	public ItemBase GetItemByID(string itemID)
	{
		foreach (var item in Items)
		{
			if (item.ItemID == itemID)
				return item;
		}
		throw new InvalidOperationException($"InventoryData: Item with ID '{itemID}' not found in inventory.");
	}

	public Array<ItemBase> GetAllItemsOfType(Type itemType)
	{
		var matchingItems = new Array<ItemBase>();
		foreach (var item in Items)
		{
			if (item.GetType() == itemType)
				matchingItems.Add(item);
		}
		return matchingItems;
	}

	public void RemoveItemByID(string itemID)
	{

		// Find the index of the item with the specified ID
		int index = -1;
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i].ItemID == itemID)
			{
				index = i;
				break;
			}
		}

		// If the item was found, remove it and emit signal
		if (index >= 0)
		{
			Items.RemoveAt(index);
			SignalHandler.EmitSignalStatic(Signals.PlayerInventoryChanged);
		}

		// If the item was not found, throw an exception
		else throw new InvalidOperationException($"InventoryData: Failed to remove item with ID '{itemID}' - not found in inventory.");
	}
}

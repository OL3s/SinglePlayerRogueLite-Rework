using Godot;
using MyTypes;
using System;

public partial class Inventory : Control
{
	[Export] GridContainer ItemGrid { get; set; }
	[Export] PackedScene InventoryItemScene { get; set; }
	[Export] Label NoItemsLabel { get; set; }
	public override void _Ready()
	{
		base._Ready();

		if (ItemGrid == null || InventoryItemScene == null || NoItemsLabel == null)
		{
			throw new InvalidOperationException("Inventory: One or more UI elements or PackedScene are not assigned in the editor.");
		}

		SignalHandler.Subscribe(Signals.PlayerInventoryChanged, OnPlayerInventoryChanged);
		RefreshInventory();
	}

	private void OnPlayerInventoryChanged(Signals signals)
	{
		if (signals != Signals.PlayerInventoryChanged)
			return;

		RefreshInventory();
	}

	public void RefreshInventory()
	{
		var inventory = SaveNode.Get().RunData.InventoryData;
		if (inventory == null)
		{
			GD.PrintErr("Inventory: RunData.Inventory is null, cannot update inventory UI.");
			return;
		}

		// Clear existing inventory items from the UI
		foreach (var child in ItemGrid.GetChildren())
			if (child is InventoryItem inventoryItem)
				inventoryItem.QueueFree();

		// Add current inventory items to the UI
		foreach (var item in inventory.Items)
		{
			var inventoryItemInstance = InventoryItemScene.Instantiate<InventoryItem>();
			if (inventoryItemInstance == null)
			{
				GD.PrintErr("Inventory: Failed to instantiate InventoryItemScene. Ensure the PackedScene is of type InventoryItem and has the correct script attached.");
				continue;
			}
			inventoryItemInstance.UpdateItemDisplay(item);
			ItemGrid.AddChild(inventoryItemInstance);
		}

		// Show or hide the "No Items" label based on inventory content
		NoItemsLabel.Visible = inventory.Items.Count == 0;
	}
}

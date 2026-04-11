using Godot;
using Godot.Collections;
using System;
using MyTypes;

public partial class Storefront : Control
{
	[Export] public Label StoreNameLabel { get; set; }
	[Export] public Label StoreSellerName { get; set; }
	[Export] public BuildingTypes StoreType { get; set; }
	[Export] public PackedScene StoreItemScene { get; set; }
	[Export] public BoxContainer StoreItemsContainer { get; set; }
	[Export] public Array<ItemBase> StoreItems { get; set; } = new Array<ItemBase>();

	public override void _Ready()
	{
		base._Ready();
		if (StoreNameLabel == null || StoreSellerName == null || StoreItemsContainer == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}

		UpdateStorefront(StoreType);
		SignalHandler.Subscribe(SignalHandler.Signals.PurchaseItem, OnPurchaseItem);
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		SignalHandler.Unsubscribe(SignalHandler.Signals.PurchaseItem, OnPurchaseItem);
	}

	private void OnPurchaseItem(SignalHandler.Signals signalType)
	{
		if (signalType != SignalHandler.Signals.PurchaseItem)
			return;
		
		
	}

	public void UpdateStorefront(BuildingTypes storeType)
	{
		StoreType = storeType;
		if (StoreNameLabel == null || StoreSellerName == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}
		// Set store name and seller name based on StoreType
		var name = BuildingExtensions.GetDisplayName(StoreType);
		var owner = BuildingExtensions.GetOwnerName(StoreType, SaveNode.Get().RunData.CurrentBiome);
		StoreNameLabel.Text = name;
		StoreSellerName.Text = owner;

		// clear existing items
		foreach (var child in StoreItemsContainer.GetChildren())		
			if (child is StoreItem storeItem)	
				storeItem.QueueFree();

		// Get store items for the current building type
		StoreItems = StoreItemData.GetItemsForBuildingTypeStatic(StoreType);
		foreach (var itemData in StoreItems)
		{
			var storeItemInstance = StoreItemScene.Instantiate<StoreItem>();
			if (storeItemInstance == null)
			{
				GD.PrintErr("Storefront: Failed to instantiate StoreItemScene. Ensure the PackedScene is of type StoreItem and has the correct script attached.");
				continue;
			}
			storeItemInstance.ParentStorefront = this; // Set reference to parent storefront for purchase callbacks
			storeItemInstance.UpdateItemDisplay(itemData);
			StoreItemsContainer.AddChild(storeItemInstance);
		}
	}

	public void RemoveItemFromStore(ItemBase item)
	{
		if (item == null)
			throw new ArgumentNullException(nameof(item), "Storefront: Cannot remove a null item from the store.");
		

		if (!StoreItems.Contains(item))
			throw new InvalidOperationException($"Storefront: Attempted to remove item '{item.ItemName}' that does not exist in the store.");

		StoreItems.Remove(item);
		foreach (var child in StoreItemsContainer.GetChildren())
		{
			if (child is StoreItem storeItem && storeItem.ItemData == item)
			{
				storeItem.QueueFree();
				break;
			}
		}

		UpdateStorefront(StoreType); // Refresh the storefront display after removing the item
	}

	public bool PurchaseItem(ItemBase item)
	{
		if (item == null)
			throw new ArgumentNullException(nameof(item), "Storefront: Cannot purchase a null item.");

		var runData = SaveNode.Get().RunData;
		var playerData = runData.PlayerData;
		if (playerData == null)
			throw new InvalidOperationException("Storefront: PlayerData is null. Cannot process purchase.");

		if (runData.Gold < item.Cost)
		{
			GD.Print("Storefront: Not enough gold to purchase this item.");
			return false;
		}

		runData.Gold -= item.Cost;
		runData.InventoryData.AddItem(item);
		RemoveItemFromStore(item);
		GD.Print($"Storefront: Purchased {item.ItemName} for {item.Cost} gold. Remaining gold: {runData.Gold}");
		return true;
	}

}

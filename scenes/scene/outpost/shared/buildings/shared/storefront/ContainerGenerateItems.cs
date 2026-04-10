using Godot;
using System;

public partial class ContainerGenerateItems : HBoxContainer
{
	// work with new item generation each time for now, save system and load later TODO!!
	[Export] public PackedScene StoreItemTscn { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (StoreItemTscn == null)
		{
			GD.PrintErr("ContainerGenerateItems: StoreItemTscn is not assigned in the editor.");
			return;
		}

		// Example of generating items for testing
		var placeholderTexture = new PlaceholderTexture2D() { Size = new Vector2(64, 32) };
		ItemBase[] testItems = {
			new ItemEquipable { ItemName = "Sword of Testing", Cost = 100, Icon = placeholderTexture },
			new ItemConsumable { ItemName = "Health Potion", Cost = 25, Icon = placeholderTexture },
			new ItemBase { ItemName = "Generic Item", Cost = 10, Icon = placeholderTexture }
		};

		foreach (var item in testItems)
		{
			CreateStoreItem(item);
		}
	}

	public StoreItem CreateStoreItem(ItemBase itemData)
	{
		if (StoreItemTscn == null)
		{
			GD.PrintErr("ContainerGenerateItems: StoreItemTscn is not assigned in the editor.");
			return null;
		}

		var storeItemInstance = StoreItemTscn.Instantiate<StoreItem>();
		if (storeItemInstance == null)
		{
			GD.PrintErr("ContainerGenerateItems: Failed to instantiate StoreItem from PackedScene.");
			return null;
		}

		storeItemInstance.ItemData = itemData;
		storeItemInstance.UpdateItemDisplay();
		AddChild(storeItemInstance);
		return storeItemInstance;
	}
}

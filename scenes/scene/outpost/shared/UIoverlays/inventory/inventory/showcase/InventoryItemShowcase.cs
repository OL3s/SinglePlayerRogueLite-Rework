using Godot;
using System;

public partial class InventoryItemShowcase : ColorRect
{
	[Export] public Label LabelName;
	[Export] public TextureRect TextureIcon;
	[Export] public BaseButton ButtonEquipMain;
	[Export] public BaseButton ButtonEquipOff;
	[Export] public BaseButton ButtonCancel;
	[Export] public ItemBase ItemData;

	public override void _Ready()
	{
		base._Ready();
		if (LabelName == null || TextureIcon == null || ButtonEquipMain == null || ButtonEquipOff == null || ButtonCancel == null)
			throw new InvalidOperationException("All UI elements must be assigned in the inspector.");
		if (ItemData != null)
			UpdateShowcase(ItemData);
		
		ButtonCancel.Pressed += ButtonClosePressed;
		ButtonEquipMain.Pressed += ButtonEquipMainPressed;
		ButtonEquipOff.Pressed += ButtonEquipOffPressed;
	}

	private void DecideButtonVisibility()
	{
		switch (ItemData)
		{
			case ItemEquipable:
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = true;
				break;
			case ItemConsumable:
			case ItemArmor:
			case ItemAmulet:
			case ItemAmmo:
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = false;
				break;
			default:
				ButtonEquipMain.Visible = false;
				ButtonEquipOff.Visible = false;
				break;
		}
	}

	private void ButtonClosePressed()
	{
		QueueFree();
	}

	private void ButtonEquipMainPressed()
	{
		var equipedItems = SaveNode.Get().PlayerData.EquipedItems;
		switch (ItemData)
		{
			case ItemEquipable equipableItem: equipedItems.MainHandItem = equipableItem; break;
			case ItemConsumable consumableItem: equipedItems.ConsumableItem = consumableItem; break;
			case ItemArmor armorItem: equipedItems.ArmorItem = armorItem; break;
			case ItemAmulet amuletItem: equipedItems.AmuletItem = amuletItem; break;
			case ItemAmmo ammoItem: equipedItems.AmmoItem = ammoItem; break;
			default: throw new InvalidOperationException("Attempted to equip an item that is not equipable.");
		}

		SignalHandler.EmitSignalStatic(SignalHandler.Signals.ItemEquipped);
		GD.Print($"Equipped {ItemData.ItemName} to main hand/consumable/armor/amulet/ammo slot.");
		QueueFree();
	}

	private void ButtonEquipOffPressed()
	{
		if (ItemData is ItemEquipable equipableItem)
		{
			var equipedItems = SaveNode.Get().PlayerData.EquipedItems;
			equipedItems.OffHandItem = equipableItem;
			SignalHandler.EmitSignalStatic(SignalHandler.Signals.ItemEquipped);
			GD.Print($"Equipped {ItemData.ItemName} to off hand slot.");
			QueueFree();
			return;

		}
		throw new InvalidOperationException("Attempted to equip an item that is not equipable.");
	}

	public void UpdateShowcase(ItemBase item)
	{
		if (item == null)
			throw new ArgumentNullException(nameof(item), "Item cannot be null when updating inventory item showcase.");

		ItemData = item;
		LabelName.Text = item.ItemName;
		TextureIcon.Texture = item.Icon;
		DecideButtonVisibility();
	}
}

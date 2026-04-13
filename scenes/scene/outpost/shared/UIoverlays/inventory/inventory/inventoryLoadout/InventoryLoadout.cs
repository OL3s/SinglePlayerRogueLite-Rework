using Godot;
using System;

public partial class InventoryLoadout : Control
{
	[Export] public InventoryLoadoutButton MainHandSlot;
	[Export] public InventoryLoadoutButton OffHandSlot;
	[Export] public InventoryLoadoutButton ArmorSlot;
	[Export] public InventoryLoadoutButton AmuletSlot;
	[Export] public InventoryLoadoutButton AmmoSlot;
	[Export] public InventoryLoadoutButton ConsumableSlot;

	public override void _Ready()
	{
		base._Ready();
		if (MainHandSlot == null || OffHandSlot == null || ArmorSlot == null || AmuletSlot == null || AmmoSlot == null || ConsumableSlot == null)
			throw new InvalidOperationException("All inventory slots must be assigned in the inspector.");

		MainHandSlot.Pressed += ButtonEquipMainPressed;
		OffHandSlot.Pressed += ButtonEquipOffPressed;
		ArmorSlot.Pressed += ButtonEquipArmorPressed;
		AmuletSlot.Pressed += ButtonEquipAmuletPressed;
		AmmoSlot.Pressed += ButtonEquipAmmoPressed;
		ConsumableSlot.Pressed += ButtonEquipConsumablePressed;

		UpdateLoadout(SaveNode.Get().EquipedItemsData ?? throw new InvalidOperationException("EquipedItemsData is not available.")); // Initialize with empty loadout or load from save data
		SignalHandler.Subscribe(SignalHandler.Signals.ItemEquipped, OnItemEquipped);
	}

	private void ButtonEquipMainPressed()
	{
		GD.Print("Equip Main Hand");
	}

	private void ButtonEquipOffPressed()
	{
		GD.Print("Equip Off Hand");
	}

	private void ButtonEquipArmorPressed()
	{
		GD.Print("Equip Armor");
	}

	private void ButtonEquipAmuletPressed()
	{
		GD.Print("Equip Amulet");
	}

	private void ButtonEquipAmmoPressed()
	{
		GD.Print("Equip Ammo");
	}

	private void ButtonEquipConsumablePressed()
	{
		GD.Print("Equip Consumable");
	}

	public void UpdateLoadout(EquipedItemsData equipedItems)
	{
		if (equipedItems == null)
			throw new ArgumentNullException(nameof(equipedItems), "EquipedItemsData cannot be null when updating loadout.");

		var mainDependency = equipedItems.MainHandItem?.Dependency;
		var offDependency = equipedItems.OffHandItem?.Dependency;

		AmmoSlot.Visible = 
			mainDependency != null && mainDependency.IsAmmoDependency() != null
			&& offDependency != null && offDependency.IsAmmoDependency() != null;

		MainHandSlot.Icon = equipedItems.MainHandItem?.Icon;
		OffHandSlot.Icon = equipedItems.OffHandItem?.Icon;
		ArmorSlot.Icon = equipedItems.ArmorItem?.Icon;
		AmuletSlot.Icon = equipedItems.AmuletItem?.Icon;
		AmmoSlot.Icon = equipedItems.AmmoItem?.Icon;
		ConsumableSlot.Icon = equipedItems.ConsumableItem?.Icon;
	}
	private void OnItemEquipped(SignalHandler.Signals signal)
	{
		if (signal != SignalHandler.Signals.ItemEquipped)
			return;

		UpdateLoadout(SaveNode.Get().EquipedItemsData ?? throw new InvalidOperationException("EquipedItemsData is not available."));
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		SignalHandler.Unsubscribe(SignalHandler.Signals.ItemEquipped, OnItemEquipped);
	}


}

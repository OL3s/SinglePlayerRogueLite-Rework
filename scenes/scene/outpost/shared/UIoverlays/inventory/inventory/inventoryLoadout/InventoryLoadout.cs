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
	[Export] public PackedScene InventoryItemLoadoutShowcaseScene;
	private EquipedItemsData equipmentData => SaveNode.Get().EquipedItemsData;

	public override void _Ready()
	{
		base._Ready();
		if (MainHandSlot == null || OffHandSlot == null || ArmorSlot == null || AmuletSlot == null || AmmoSlot == null || ConsumableSlot == null || InventoryItemLoadoutShowcaseScene == null)
			throw new InvalidOperationException("All inventory slots and the showcase scene must be assigned in the inspector.");

		MainHandSlot.Pressed += ButtonEquipMainPressed;
		OffHandSlot.Pressed += ButtonEquipOffPressed;
		ArmorSlot.Pressed += ButtonEquipArmorPressed;
		AmuletSlot.Pressed += ButtonEquipAmuletPressed;
		AmmoSlot.Pressed += ButtonEquipAmmoPressed;
		ConsumableSlot.Pressed += ButtonEquipConsumablePressed;

		UpdateLoadout(equipmentData ?? throw new InvalidOperationException("EquipedItemsData is not available.")); // Initialize with empty loadout or load from save data
		SignalHandler.Subscribe(SignalHandler.Signals.ItemEquipped, OnItemEquipped);
	}

	private void ButtonPressedSlotBase(InventoryLoadoutButton slot)
	{
		if (slot?.Item == null)
			return;

		if (InventoryItemLoadoutShowcaseScene == null)
			throw new InvalidOperationException("The loadout showcase scene must be assigned in the inspector.");

		var showcase = InventoryItemLoadoutShowcaseScene.Instantiate<InventoryItemLoadoutShowcase>();
		showcase.UpdateItem(slot.Item);
		GlobalOverlay.Get().AddChild(showcase);
	}

	private void ButtonEquipMainPressed()
	{
		GD.Print("Equip Main Hand");
		ButtonPressedSlotBase(MainHandSlot);
	}

	private void ButtonEquipOffPressed()
	{
		GD.Print("Equip Off Hand");
		ButtonPressedSlotBase(OffHandSlot);
	}

	private void ButtonEquipArmorPressed()
	{
		GD.Print("Equip Armor");
		ButtonPressedSlotBase(ArmorSlot);
	}

	private void ButtonEquipAmuletPressed()
	{
		GD.Print("Equip Amulet");
		ButtonPressedSlotBase(AmuletSlot);
	}

	private void ButtonEquipAmmoPressed()
	{
		GD.Print("Equip Ammo");
		ButtonPressedSlotBase(AmmoSlot);
	}

	private void ButtonEquipConsumablePressed()
	{
		GD.Print("Equip Consumable");
		ButtonPressedSlotBase(ConsumableSlot);
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

		MainHandSlot.UpdateItem(equipedItems.MainHandItem);
		OffHandSlot.UpdateItem(equipedItems.OffHandItem);
		ArmorSlot.UpdateItem(equipedItems.ArmorItem);
		AmuletSlot.UpdateItem(equipedItems.AmuletItem);
		AmmoSlot.UpdateItem(equipedItems.AmmoItem);
		ConsumableSlot.UpdateItem(equipedItems.ConsumableItem);
	}
	private void OnItemEquipped(SignalHandler.Signals signal)
	{
		if (signal != SignalHandler.Signals.ItemEquipped)
			return;

		UpdateLoadout(equipmentData ?? throw new InvalidOperationException("EquipedItemsData is not available."));
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		SignalHandler.Unsubscribe(SignalHandler.Signals.ItemEquipped, OnItemEquipped);
	}


}

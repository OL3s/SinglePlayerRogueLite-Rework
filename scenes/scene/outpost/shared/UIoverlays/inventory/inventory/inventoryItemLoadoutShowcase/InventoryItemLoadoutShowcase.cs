using Godot;
using System;

public partial class InventoryItemLoadoutShowcase : ColorRect
{
	[Export] public Label LabelName;
	[Export] public TextureRect TextureIcon;
	[Export] public BaseButton ButtonCancel;
	[Export] public BaseButton ButtonUnequip;
	[Export] public ItemBase ItemData;

	public override void _Ready()
	{
		base._Ready();
		if (LabelName == null || TextureIcon == null || ButtonCancel == null || ButtonUnequip == null)
			throw new InvalidOperationException("All UI elements must be assigned in the inspector.");

		ButtonCancel.Pressed += () => QueueFree();
		ButtonUnequip.Pressed += ButtonUnequipPressed;
		if (ItemData != null)
			UpdateItem(ItemData);
	}

	public void UpdateItem(ItemBase item)
	{
		ItemData = item ?? throw new ArgumentNullException(nameof(item), "Cannot show a loadout showcase for an empty slot.");
		LabelName.Text = ItemData.ItemName;
		TextureIcon.Texture = ItemData.Icon;
	}

	public void ButtonUnequipPressed()
	{
		var equipedItemsData = SaveNode.Get().EquipedItemsData;
		switch (ItemData)
		{
			case ItemEquipable:
				if (equipedItemsData.MainHandItem == ItemData)
					equipedItemsData.MainHandItem = null;
				else if (equipedItemsData.OffHandItem == ItemData)
					equipedItemsData.OffHandItem = null;
				break;
			case ItemArmor:
				equipedItemsData.ArmorItem = null;
				break;
			case ItemAmulet:
				equipedItemsData.AmuletItem = null;
				break;
			case ItemAmmo:
				equipedItemsData.AmmoItem = null;
				break;
			case ItemConsumable:
				equipedItemsData.ConsumableItem = null;
				break;
		}

		GD.Print($"Unequipped {ItemData.ItemName} from loadout.");
		SignalHandler.EmitSignalStatic(SignalHandler.Signals.ItemEquipped);
		QueueFree();
	}

	public void ButtonCancelPressed()
	{
		QueueFree();
	}
}

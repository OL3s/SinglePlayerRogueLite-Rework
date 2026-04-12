using Godot;
using System;

public partial class InventoryItemShowcase : ColorRect
{
	[Export] public Label LabelName;
	[Export] public TextureRect TextureIcon;
	[Export] public BaseButton ButtonEquipMain;
	[Export] public BaseButton ButtonEquipOff;
	[Export] public BaseButton ButtonEquipAlt;
	[Export] public BaseButton ButtonCancel;
	[Export] public ItemBase ItemData;

	public override void _Ready()
	{
		base._Ready();
		if (LabelName == null || TextureIcon == null || ButtonEquipMain == null || ButtonEquipOff == null || ButtonEquipAlt == null || ButtonCancel == null)
			throw new InvalidOperationException("All UI elements must be assigned in the inspector.");
		if (ItemData != null)
			UpdateShowcase(ItemData);
		
		ButtonCancel.Pressed += ButtonClosePressed;
		ButtonEquipMain.Pressed += ButtonEquipMainPressed;
		ButtonEquipOff.Pressed += ButtonEquipOffPressed;
		ButtonEquipAlt.Pressed += ButtonEquipAltPressed;

	}

	private void DecideButtonVisibility()
	{
		switch (ItemData.GetType().Name)
		{
			case nameof(ItemEquipable):
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = true;
				ButtonEquipAlt.Visible = true;
				break;
			case nameof(ItemConsumable):
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = false;
				ButtonEquipAlt.Visible = false;
				break;
			case nameof(ItemArmor):
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = false;
				ButtonEquipAlt.Visible = false;
				break;
			case nameof(ItemAmulet):
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = false;
				ButtonEquipAlt.Visible = false;
				break;
			case nameof(ItemAmmo):
				ButtonEquipMain.Visible = true;
				ButtonEquipOff.Visible = false;
				ButtonEquipAlt.Visible = false;
				break;
			default:
				ButtonEquipMain.Visible = false;
				ButtonEquipOff.Visible = false;
				ButtonEquipAlt.Visible = false;
				break;
		}
	}

	private void ButtonClosePressed()
	{
		QueueFree();
	}

	private void ButtonEquipMainPressed()
	{
		throw new NotImplementedException("TODO: Implement equipping item to main slot.");
	}

	private void ButtonEquipOffPressed()
	{
		throw new NotImplementedException("TODO: Implement equipping item to off slot.");
	}

	private void ButtonEquipAltPressed()
	{
		throw new NotImplementedException("TODO: Implement equipping item to alt slot.");
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

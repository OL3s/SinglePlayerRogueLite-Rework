using Godot;
using System;

public partial class StoreItem : Control
{
	[Export] public ItemBase ItemData { get; set; }
	[Export] public Label ItemCostLabel { get; set; }
	[Export] public Label ItemNameLabel { get; set; }
	[Export] public TextureRect ItemIcon { get; set; }
	[Export] public PackedScene ItemDetailScene { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (ItemCostLabel == null || ItemNameLabel == null || ItemIcon == null || ItemDetailScene == null)
		{
			throw new InvalidOperationException("StoreItem: One or more UI elements or PackedScene are not assigned in the editor.");
		}
	}

	public override void _GuiInput(InputEvent @event)
	{
		base._GuiInput(@event);
		if (@event is InputEventScreenTouch touchEvent && touchEvent.Pressed)
		{
			if (ItemData == null)
			{
				GD.Print("StoreItem: No item data assigned, ignoring press.");
				return;
			}

			var itemDetailInstance = ItemDetailScene.Instantiate<PurchaseItem>();
			if (itemDetailInstance == null)
			{
				GD.PrintErr("StoreItem: Failed to instantiate ItemDetailScene. Ensure the PackedScene is of type PurchaseItem and has the correct script attached.");
				return;
			}
			itemDetailInstance.ItemData = ItemData; // Pass item data to the detail scene
		}
	}

	public void UpdateItemDisplay()
	{
		if (ItemData == null)
		{
			Visible = false;
			return;
		}

		ItemCostLabel.Text = $"{ItemData.Cost}";
		ItemNameLabel.Text = ItemData.ItemName;
		ItemIcon.Texture = ItemData.Icon;
		ItemCostLabel.Modulate = ItemData.Cost > SaveNode.Get().RunData.Gold ? Colors.Red : Colors.White; // Dim cost if item is free
	}
	
}

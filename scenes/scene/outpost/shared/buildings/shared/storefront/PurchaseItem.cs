using Godot;
using System;

public partial class PurchaseItem : Control
{
	[Export] public ItemBase ItemData { get; set; }
	[Export] public Label ItemNameLabel { get; set; }
	[Export] public Label ItemCostLabel { get; set; }
	[Export] public TextureRect ItemIcon { get; set; }
	[Export] public Button PurchaseButton { get; set; }
	[Export] public Button CancelButton { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (ItemNameLabel == null || ItemCostLabel == null || ItemIcon == null || PurchaseButton == null || CancelButton == null)
		{
			throw new InvalidOperationException("PurchaseItem: One or more UI elements are not assigned in the editor.");
		}

		PurchaseButton.Pressed += OnPurchaseButtonPressed;
		CancelButton.Pressed += OnCancelButtonPressed;
	}

	private void OnPurchaseButtonPressed()
	{
		if (ItemData == null)
		{
			GD.Print("PurchaseItem: No item data assigned, cannot process purchase.");
			return;
		}
		throw new NotImplementedException("PurchaseItem: Purchase logic not implemented yet.");
	}

	private void OnCancelButtonPressed()
	{
		QueueFree(); // Close the purchase item detail view
	}

}

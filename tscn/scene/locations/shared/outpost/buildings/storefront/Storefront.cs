using Godot;
using BuildingTypes;

public partial class Storefront : Control
{
	[Export] public Label StoreNameLabel { get; set; }
	[Export] public Label StoreSellerName { get; set; }
	[Export] public GridContainer StoreItemGrid { get; set; }
	[Export] public StorefrontTypes StoreType { get; set; }
	[Export] public bool UpdateLabelOnReady { get; set; } = true;

	public override void _Ready()
	{
		base._Ready();
		if (UpdateLabelOnReady)
			UpdateStorefront();
	}

	public void UpdateStorefront()
	{
		if (StoreNameLabel == null || StoreSellerName == null || StoreItemGrid == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}

		// Set store name and seller name based on StoreType
		switch (StoreType)
		{
			case StorefrontTypes.General:
				StoreNameLabel.Text = "General Goods";
				StoreSellerName.Text = "Garrick";
				break;
			case StorefrontTypes.Merchant:
				StoreNameLabel.Text = "Merchant's Emporium";
				StoreSellerName.Text = "Lydia";
				break;
			case StorefrontTypes.Blacksmith:
				StoreNameLabel.Text = "Blacksmith's Forge";
				StoreSellerName.Text = "Thorin";
				break;
			case StorefrontTypes.Alchemist:
				StoreNameLabel.Text = "Alchemist's Lab";
				StoreSellerName.Text = "Elara";
				break;
			case StorefrontTypes.Fletcher:
				StoreNameLabel.Text = "Fletcher's Workshop";
				StoreSellerName.Text = "Rowan";
				break;
			case StorefrontTypes.Letherworker:
				StoreNameLabel.Text = "Letherworker's Den";
				StoreSellerName.Text = "Mira";
				break;
			case StorefrontTypes.Mage:
				StoreNameLabel.Text = "Mage's Arcana";
				StoreSellerName.Text = "Selene";
				break;
			case StorefrontTypes.Florist:
				StoreNameLabel.Text = "Florist's Garden";
				StoreSellerName.Text = "Iris";
				break;
			case StorefrontTypes.Innkeeper:
				StoreNameLabel.Text = "Innkeeper's Lodge";
				StoreSellerName.Text = "Borin";
				break;
		}
	}
}

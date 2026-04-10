using Godot;
using MyTypes;

public partial class Storefront : Control
{
	[Export] public Label StoreNameLabel { get; set; }
	[Export] public Label StoreSellerName { get; set; }
	[Export] public GridContainer StoreItemGrid { get; set; }
	[Export] public BuildingTypes StoreType { get; set; }
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
			case BuildingTypes.Tavern:
				StoreNameLabel.Text = "The Hearthside Tavern";
				StoreSellerName.Text = "Borin";
				break;
			case BuildingTypes.Merchant:
				StoreNameLabel.Text = "Merchant's Emporium";
				StoreSellerName.Text = "Lydia";
				break;
			case BuildingTypes.Blacksmith:
				StoreNameLabel.Text = "Blacksmith's Forge";
				StoreSellerName.Text = "Thorin";
				break;
			case BuildingTypes.Goldsmith:
				StoreNameLabel.Text = "Goldsmith's Atelier";
				StoreSellerName.Text = "Aurel";
				break;
			case BuildingTypes.Alchemist:
				StoreNameLabel.Text = "Alchemist's Lab";
				StoreSellerName.Text = "Elara";
				break;
			case BuildingTypes.Fletcher:
				StoreNameLabel.Text = "Fletcher's Workshop";
				StoreSellerName.Text = "Rowan";
				break;
			case BuildingTypes.Arcanist:
				StoreNameLabel.Text = "Arcanist's Archive";
				StoreSellerName.Text = "Selene";
				break;
			case BuildingTypes.Enchanter:
				StoreNameLabel.Text = "Enchanter's Sanctum";
				StoreSellerName.Text = "Ilyas";
				break;
			default:
				StoreNameLabel.Text = "Unknown Store";
				StoreSellerName.Text = "Unknown Seller";
				break;
		}
	}
}

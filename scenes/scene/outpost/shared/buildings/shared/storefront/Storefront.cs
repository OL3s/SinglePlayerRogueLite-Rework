using Godot;
using MyTypes;

public partial class Storefront : Control
{
	[Export] public Label StoreNameLabel { get; set; }
	[Export] public Label StoreSellerName { get; set; }
	[Export] public BuildingTypes StoreType { get; set; }
	[Export] public ContainerGenerateItems ContainerGenerateItems { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (StoreNameLabel == null || StoreSellerName == null || ContainerGenerateItems == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}
	}

	public void UpdateStorefront(BuildingTypes storeType)
	{
		StoreType = storeType;
		if (StoreNameLabel == null || StoreSellerName == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}
		// Set store name and seller name based on StoreType
		var name = BuildingExtensions.GetDisplayName(StoreType);
		var owner = BuildingExtensions.GetOwnerName(StoreType, SaveNode.Get().RunData.CurrentBiome);
		StoreNameLabel.Text = name;
		StoreSellerName.Text = owner;
	}
}

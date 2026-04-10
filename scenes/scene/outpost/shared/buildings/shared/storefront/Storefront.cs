using Godot;
using MyTypes;

public partial class Storefront : Control
{
	[Export] public Label StoreNameLabel { get; set; }
	[Export] public Label StoreSellerName { get; set; }
	[Export] public BuildingTypes StoreType { get; set; }
	[Export] public PackedScene StoreItemScene { get; set; }
	[Export] public BoxContainer StoreItemsContainer { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (StoreNameLabel == null || StoreSellerName == null || StoreItemsContainer == null)
		{
			GD.PrintErr("Storefront: One or more UI elements are not assigned in the editor.");
			return;
		}

		FetchStoreItems();
		UpdateStorefront(StoreType);
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

	public void FetchStoreItems() {
		// clear existing items
		foreach (var child in StoreItemsContainer.GetChildren())
			child.QueueFree();

		// load mock data initilize StoreItem instances
		var placeholderIcon = new PlaceholderTexture2D();
		placeholderIcon.Size = new Vector2I(64, 64);
		var items = new ItemBase[] {
			new ItemConsumable { ItemName = "Health Potion", Cost = 50, Icon = placeholderIcon },
			new ItemConsumable { ItemName = "Mana Potion", Cost = 30, Icon = placeholderIcon },
			new ItemEquipable { ItemName = "Sword of Testing", Cost = 200, Icon = placeholderIcon }
		};
		foreach (var itemData in items)		{
			var storeItemInstance = StoreItemScene.Instantiate<StoreItem>();
			if (storeItemInstance == null)			{
				GD.PrintErr("Storefront: Failed to instantiate StoreItemScene. Ensure the PackedScene is of type StoreItem and has the correct script attached.");
				continue;
			}
			storeItemInstance.UpdateItemDisplay(itemData);
			StoreItemsContainer.AddChild(storeItemInstance);
		}
	}
}

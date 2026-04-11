using Godot;
using Godot.Collections;

public partial class InventoryData : Node
{
    [Export] public Array<ItemBase> Items { get; set; } = new Array<ItemBase>();

    public void AddItem(ItemBase item)
    {
        Items.Add(item);
    }

    public void RemoveItem(ItemBase item)
    {
        Items.Remove(item);
    }

    public ItemBase GetItemByID(string itemID)
    {
        foreach (var item in Items)
        {
            if (item.ItemID == itemID)
                return item;
        }
        return null;
    }
    
}
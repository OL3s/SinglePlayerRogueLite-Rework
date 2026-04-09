using Godot;
using Godot.Collections;

[GlobalClass]
public partial class ItemLibrary : Resource
{
	[Export] public int Version { get; set; } = 1;
	[Export] public Array<ItemBase> Items { get; set; } = new Array<ItemBase>() { 
		new ItemAmmo(),
		new ItemAmulet(),
		new ItemArmor(),
		new ItemEquipable(), 
		new ItemConsumable() 
	};

	public ItemLibrary() { }
}

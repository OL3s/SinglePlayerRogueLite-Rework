using Godot;
using System;

[GlobalClass]
public partial class PlayerData : Resource
{
    [Export] public EquipedItemsData EquipedItems { get; set; } = new();
}

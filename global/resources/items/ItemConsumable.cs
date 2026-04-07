using Godot;

[GlobalClass]
public partial class ItemConsumable : ItemBase
{
    [Export] public int CountMax { get; set; } = 0;
    [Export] public int CountCurrent { get; set; } = 0;
}
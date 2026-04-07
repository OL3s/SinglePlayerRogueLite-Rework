using Godot;

[GlobalClass]
public partial class ItemArmor : ItemBase
{
    [Export] public int ConditionMax { get; set; } = 0;
    [Export] public int ConditionCurrent { get; set; } = 0;
}
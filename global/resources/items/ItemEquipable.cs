using Godot;

[GlobalClass]
public partial class ItemEquipable : ItemBase
{
    [Export] public Texture2D EquippedTexture { get; set; } = null;
    [Export] public int ConditionMax { get; set; } = 0;
    [Export] public int ConditionCurrent { get; set; } = 0;
}
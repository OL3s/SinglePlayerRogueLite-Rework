#nullable enable

using Godot;
using System;

[GlobalClass]
public partial class ItemBase : Resource
{
	[Export] public string ItemName { get; set; } = "NONAME";
	[Export] public DependencyLevel? UseDependency { get; set; }
	[Export] public Texture2D Icon { get; set; } = new PlaceholderTexture2D();
	[Export] public int MaxStackSize { get; set; } = 1;
	[Export] public int Cost { get; set; } = 0;
	public bool IsStackable => MaxStackSize > 1;

	public ItemBase() { }

	public ItemBase(string itemName, DependencyLevel? useDependency, Texture2D icon, int maxStackSize, int cost)
	{
		ItemName = itemName;
		UseDependency = useDependency;
		Icon = icon;
		MaxStackSize = maxStackSize;
		Cost = cost;
	}
}

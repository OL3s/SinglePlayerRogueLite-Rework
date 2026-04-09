using Godot;
using System;

[GlobalClass]
public partial class ItemBase : Resource
{
	[Export]
	public string ItemName { get; set; } = "NONAME";

	[Export]
	public Texture2D Icon { get; set; } = null;

	[Export]
	public int MaxStackSize { get; set; } = 1;

	public ItemBase() { }

	public ItemBase(string name, Texture2D icon, int maxStackSize)
	{
		ItemName = name;
		Icon = icon;
		MaxStackSize = maxStackSize;
	}

}

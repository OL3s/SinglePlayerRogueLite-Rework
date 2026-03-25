using Godot;
using System;

public partial class ButtonCloseScene : Button
{
	[Export] Node NodeToClose;

	public override void _Ready()
	{
		Pressed += CloseNode;
	}

	private void CloseNode() 
	{
		if (NodeToClose == null)
		{
			GD.PushError("[ButtonCloseScene] NodeToClose is null");
			return;
		}

		NodeToClose.QueueFree();
	}

	
}

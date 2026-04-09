using Godot;
using System;

public partial class CloseButton : BaseButton
{
	public override void _Pressed()
	{
		base._Pressed();
		GlobalOverlay.CloseOverlayStatic();
	}
}

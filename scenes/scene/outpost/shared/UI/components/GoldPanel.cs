using Godot;
using System;

public partial class GoldPanel : Control
{
	[Export] public Label GoldAmountLabel { get; set; }
	public override void _Ready()
	{
		base._Ready();
		if (GoldAmountLabel == null)
		{
			GD.PrintErr("GoldAmountLabel must be assigned in the editor.");
			return;
		}

		UpdateGoldAmount(SaveNode.Get().RunData.Gold);
	}

	public void UpdateGoldAmount(int amount)
	{
		if (GoldAmountLabel == null)
			return;

		GoldAmountLabel.Text = amount.ToString();
	}
}

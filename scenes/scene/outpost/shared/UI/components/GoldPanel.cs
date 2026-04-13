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

		UpdateGoldAmount(GetGoldAmount());
		SignalHandler.Subscribe(SignalHandler.Signals.GoldAmountChanged, OnGoldAmountChanged);
	}

	public void UpdateGoldAmount(int amount)
	{
		if (GoldAmountLabel == null)
			return;

		GoldAmountLabel.Text = amount.ToString();
	}

	public void OnGoldAmountChanged(SignalHandler.Signals signal)
	{
		if (signal != SignalHandler.Signals.GoldAmountChanged)
			return;

		UpdateGoldAmount(GetGoldAmount());
	}

	private int GetGoldAmount()
	{
		return SaveNode.Get().RunData.Gold;
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		SignalHandler.Unsubscribe(SignalHandler.Signals.GoldAmountChanged, OnGoldAmountChanged);
	}
}

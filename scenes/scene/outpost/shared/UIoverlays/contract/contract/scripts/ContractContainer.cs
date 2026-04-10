using Godot;
using Godot.Collections;
using MyTypes;
using System;

public partial class ContractContainer : HBoxContainer
{
	[Export] public PackedScene ContractSelectComponentScene { get; set; }
	[Export] public Array<Contract> Contracts { get; set; }

	public override void _Ready()
	{
		if (ContractSelectComponentScene == null)
		{
			GD.PrintErr("ContractSelectComponentScene must be assigned in the editor.");
			return;
		}

		FetchContracts();
		float currentOffset = 0f;

		foreach (var contract in Contracts)
		{
			var contractSelectComponent = ContractSelectComponentScene.Instantiate<ContractSelectComponent>();
			contractSelectComponent.UpdateContract(contract);
			contractSelectComponent.TimerOffset = currentOffset;
			currentOffset += 0.3f;
			AddChild(contractSelectComponent);
		}
	}

	private void FetchContracts()
	{
		// Placeholder for fetching contracts from a data source
		// This could be from a file, database, or an API
		// TODO!!

		// Mock data for demonstration purposes
		Contracts = new Array<Contract>() {
			new Contract() { Biome = Biomes.GrasslandsA, EndLocation = Locations.Village},
			new Contract() { Biome = Biomes.DesertB, EndLocation = Locations.Sanctuary},
			new Contract() { Biome = Biomes.IcyC, EndLocation = Locations.Campsite}
		};
	}
}

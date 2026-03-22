using Godot;
using System;
using System.Collections.Generic;
using MapGeneration;

public partial class MapGenerated : Node2D
{
	[Export] public TileMapLayer TileDefault;
	[Export] public MapGenerator Generator;
	[Export] public int FloorSourceId = 0;
	[Export] public Vector2I FloorAtlasCoords = Vector2I.Zero;
	[Export] public int FloorAlternativeTile;
	public MapGeneratorData MapData;

	public override void _Ready()
	{
		if (TileDefault == null)
		{
			GD.PrintErr("TileDefault is not assigned. Please assign a TileMapLayer in the inspector.");
			return;
		}
		MapData = Generator.GenerateMap();
		MapGeneratorDataToTileMap(MapData, TileDefault, 1);
	}

	private void MapGeneratorDataToTileMap(MapGeneratorData data, TileMapLayer tilemap, int Offset)
	{
		HashSet<Vector2I> deepTiles = data.GetDeepTiles(Generator.DeepThreshold, Generator.DeepRadius);

		foreach (Vector2I pos in data.TileFloor)
		{
			Vector2I tilePos = new(pos.X + Offset, pos.Y + Offset);

			if (deepTiles.Contains(pos))
				tilemap.SetCell(tilePos, FloorSourceId, GetAtlasFromType(TileType.Deep), FloorAlternativeTile);
			else
				tilemap.SetCell(tilePos, FloorSourceId, GetAtlasFromType(TileType.Floor), FloorAlternativeTile);
		}

		foreach (Vector2I pos in data.TileWall)
		{
			Vector2I tilePos = new(pos.X + Offset, pos.Y + Offset);
			tilemap.SetCell(
				tilePos, 
				FloorSourceId, 
				GetAtlasFromType(TileType.Wall),
				FloorAlternativeTile
			);
		}
	}

	private Vector2I GetAtlasFromType(TileType type)
	{
		return type switch
		{
			TileType.Floor => new Vector2I(0, 0),
			TileType.Wall => new Vector2I(7, 0),
			TileType.Deep => new Vector2I(2, 2),
			_ => new Vector2I(0, 0)
		};
	}

	private enum TileType
	{
		Floor,
		Wall,
		Deep
	}
}

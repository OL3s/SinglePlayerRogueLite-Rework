using Godot;
using System;
using System.Collections.Generic;
using MapGenerationService;
using TileAtlasService;

public partial class LevelMap : Node2D
{
	[Export] public TileMapLayer TileWalls;
	[Export] public TileMapLayer TileFloors;
	[Export] public MapGenerator Generator;
	[Export] public int Offset = 1;
	[Export] public int WallSourceId = 0;
	[Export] public int FloorSourceId = 1;
	[Export] public Vector2I FloorAtlasCoords = new(1, 0);
	public MapGeneratorData MapData;

	public override void _Ready()
	{
		if (TileWalls == null)
		{
			GD.PrintErr("TileWalls is not assigned. Please assign a TileMapLayer in the inspector.");
			return;
		}
		if (TileFloors == null)
		{
			GD.PrintErr("TileFloors is not assigned. Please assign a TileMapLayer in the inspector.");
			return;
		}
		MapData = Generator.GenerateMap();
		

		MapGeneratorDataToTileWalls(MapData, TileWalls, Offset);
		MapGeneratorDataToTileFloors(MapData, TileFloors, Offset);
	}

	private void MapGeneratorDataToTileWalls(MapGeneratorData data, TileMapLayer tilemap, int Offset)
	{

		foreach (Vector2I pos in data.TileWall)
		{
			Vector2I tilePos = new(pos.X + Offset, pos.Y + Offset);
			tilemap.SetCell(
				tilePos, 
				sourceId: WallSourceId, 
				atlasCoords: TileAtlasHelper.GetAtlasFromHashSetPosition(pos, MapData.TileFloor),
				alternativeTile: 0
			);
		}
	}

	private void MapGeneratorDataToTileFloors(MapGeneratorData data, TileMapLayer tilemap, int Offset)
	{
		foreach (Vector2I pos in data.TileFloor)
		{
			Vector2I tilePos = new(pos.X + Offset, pos.Y + Offset);
			tilemap.SetCell(
				tilePos,
				sourceId: FloorSourceId,
				atlasCoords: FloorAtlasCoords,
				alternativeTile: 0
			);
		}
	}
}

using Godot;
using System.Collections.Generic;

namespace TileAtlasService
{
	public static class TileAtlasHelper
	{

		public static Vector2I GetAtlasFromHashSetPosition(Vector2I position, HashSet<Vector2I> floorTiles)
		{
			
			// get directions
			var defDirs = new List<Vector2I> {
				new Vector2I(0, -1), // Up
				new Vector2I(1, 0),  // Right
				new Vector2I(0, 1),  // Down
				new Vector2I(-1, 0)  // Left
			};

			// get neighbors
			var nbors = new HashSet<Vector2I>();
			foreach (var dir in defDirs)
			{
				if (floorTiles.Contains(position + dir))
					nbors.Add(dir);
			}

			var allDirs = new List<Vector2I> {
				new Vector2I(0, -1), // Up
				new Vector2I(1, 0),  // Right
				new Vector2I(0, 1),  // Down
				new Vector2I(-1, 0), // Left
				new Vector2I(-1, -1), // Up-Left
				new Vector2I(1, -1),  // Up-Right
				new Vector2I(1, 1),   // Down-Right
				new Vector2I(-1, 1)   // Down-Left
			};

			var allNbors = new HashSet<Vector2I>();
			foreach (var dir in allDirs)
			{
				if (floorTiles.Contains(position + dir))
					allNbors.Add(dir);
			}

			#region logic
			// full wall
			if (nbors.Count == 4) return new Vector2I(6, 5); // all neighbors, full wall
			// wall endings
			if (nbors.Count == 3) {
				if (!nbors.Contains(new Vector2I(0, -1))) return new Vector2I(4, 5); // pop down
				if (!nbors.Contains(new Vector2I(1, 0))) return new Vector2I(3, 5); // pop left
				if (!nbors.Contains(new Vector2I(0, 1))) return new Vector2I(2, 5); // pop up
				if (!nbors.Contains(new Vector2I(-1, 0))) return new Vector2I(5, 5); // pop right
			}
			// wall corners and straight pieces
			if (nbors.Count == 2) {
				if (nbors.Contains(new Vector2I(0, -1)) && nbors.Contains(new Vector2I(0, 1))) return new Vector2I(1, 4); // vertical
				if (nbors.Contains(new Vector2I(1, 0)) && nbors.Contains(new Vector2I(-1, 0))) return new Vector2I(0, 4); // horizontal
				if (nbors.Contains(new Vector2I(0, -1)) && nbors.Contains(new Vector2I(1, 0))) return new Vector2I(4, 4); // up right corner
				if (nbors.Contains(new Vector2I(1, 0)) && nbors.Contains(new Vector2I(0, 1))) return new Vector2I(6, 4); // down right corner
				if (nbors.Contains(new Vector2I(0, 1)) && nbors.Contains(new Vector2I(-1, 0))) return new Vector2I(0, 5); // down left corner
				if (nbors.Contains(new Vector2I(-1, 0)) && nbors.Contains(new Vector2I(0, -1))) return new Vector2I(2, 4); // up left corner
			}

			// wall sides
			if (nbors.Count == 1) {
				if (nbors.Contains(new Vector2I(0, -1))) return new Vector2I(4, 2); // up
				if (nbors.Contains(new Vector2I(1, 0))) return new Vector2I(0, 3); // right
				if (nbors.Contains(new Vector2I(0, 1))) return new Vector2I(4, 3); // down
				if (nbors.Contains(new Vector2I(-1, 0))) return new Vector2I(0, 2); // left
			}

			// special pieces
				// TODO - Add all special pieces, currently only easy ones with 1 or 0 neighbors are added
			#endregion

			// fallback on missing logic
			return new Vector2I(7, 5); 


		}

	}
}

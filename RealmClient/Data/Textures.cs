using System.Text.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace RealmClient.Data; 

public static class Textures {
	public enum AtlasId {
		GroundTiles = 1,
		Characters = 2,
		CharactersMask = 3,
		MapObjects = 4,
	}

	public enum Direction {
		Right = 0,
		Left = 1,
		Down = 3,
		Up = 2,
	}

	public enum Action {
		Stand = 0,
		Walk = 1,
		Attack = 2,
	}

	public static string SpritesheetJson;
	public static Image<Bgra32> Characters;
	public static Image<Bgra32> CharactersMask;
	public static Image<Bgra32> MapObjects;
	public static Image<Bgra32> GroundTiles;

	///<summary>sheetname:index:direction:action</summary>
	public static readonly Dictionary<string, Dictionary<int, Dictionary<Direction, Dictionary<Action, Image>>>> AnimatedSprites = new();

	///<summary>sheetname:index</summary>
	public static readonly Dictionary<string, Dictionary<int, Image>> Sprites = new();

	public static void Split() {
		var sheets = JsonSerializer.Deserialize<SpritesheetJson>(SpritesheetJson);
		var spritesheets = new Dictionary<int, Image>();
		spritesheets.Add((int)AtlasId.Characters, Characters);
		spritesheets.Add((int)AtlasId.CharactersMask, CharactersMask);
		spritesheets.Add((int)AtlasId.GroundTiles, MapObjects);
		spritesheets.Add((int)AtlasId.MapObjects, GroundTiles);

		foreach (var sheet in sheets.sprites) {
			var indeces = new Dictionary<int, Image>();
			Sprites.Add(sheet.spriteSheetName, indeces);
			foreach (var sprite in sheet.elements) {
				var pos = sprite.position;
				var image = spritesheets[sprite.aId].Clone(sheet => sheet.Crop(new Rectangle(pos.x, pos.y, pos.w, pos.h)));
				indeces.Add(sprite.index, image);
			}
		}
		foreach (var sprite in sheets.animatedSprites) {
			if (!AnimatedSprites.ContainsKey(sprite.spriteData.spriteSheetName)) {
				AnimatedSprites.Add(sprite.spriteData.spriteSheetName, new Dictionary<int, Dictionary<Direction, Dictionary<Action, Image>>>());
			}

			Console.WriteLine($"sheet {sprite.spriteSheetName}, index {sprite.index}, inner index {sprite.spriteData.index}");
			//continue;

			var indeces = AnimatedSprites[sprite.spriteData.spriteSheetName];
			if (!indeces.ContainsKey(sprite.index)) {
				indeces.Add(sprite.index, new Dictionary<Direction, Dictionary<Action, Image>>());
			}

			var direction = (Direction)sprite.direction;
			if (!indeces[sprite.index].ContainsKey(direction)) {
				indeces[sprite.index].Add(direction, new Dictionary<Action, Image>());
			}

			var action = (Action)sprite.action;
			var directions = indeces[sprite.index][direction];

			var pos = sprite.spriteData.position;

			var sheet = spritesheets[sprite.spriteData.aId];
			var rect = new Rectangle(pos.x, pos.y, pos.w, pos.h);
			//Console.WriteLine($"sprite index {sprite.index}, {sprite.spriteData.spriteSheetName}, sheet null {sheet == null}, {sheet?.Width ?? 0}x{sheet?.Height ?? 0}, rect {rect.ToString()}");
			var image = sheet.Clone(sheet => sheet.Crop(rect));
			//indeces.Add(sprite.index, image);

			if (!directions.ContainsKey(action)) {
				directions.Add(action, image);
			}
		}

		foreach (var anim in AnimatedSprites) {
			foreach (var index in anim.Value) {
				if (!Sprites.ContainsKey(anim.Key)) {
					Sprites.Add(anim.Key, new Dictionary<int, Image>());
				}

				if (index.Value.ContainsKey(Direction.Right)) {
					if (index.Value[Direction.Right].ContainsKey(Action.Stand)) {
						Sprites[anim.Key].Add(index.Key, index.Value[Direction.Right][Action.Stand]);
					} else {
						Sprites[anim.Key].Add(index.Key, index.Value[Direction.Right].First().Value);
					}
				}
			}
		}

		foreach (var go in GameObjects.Objects) {
			
		}
	}
}
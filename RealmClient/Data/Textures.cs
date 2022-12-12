using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RealmClient.Data; 

public static class Textures {
	public static string SpritesheetJson;
	public static Image<Bgra32> Characters;
	public static Image<Bgra32> CharactersMask;
	public static Image<Bgra32> MapObjects;
	public static Image<Bgra32> GroundTiles;
}
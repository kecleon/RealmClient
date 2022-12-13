namespace RealmClient.Data;

public class SpritesheetJson {
	public List<Sprite> sprites { get; set; }
	public List<AnimatedSprite> animatedSprites { get; set; }
}

public class AnimatedSprite {
	public int index { get; set; }
	public string spriteSheetName { get; set; }
	public int direction { get; set; }
	public int action { get; set; }
	public int set { get; set; }
	public SpriteData spriteData { get; set; }
}

public class Element {
	public int padding { get; set; }
	public int index { get; set; }
	public int aId { get; set; }
	public bool isT { get; set; }
	public Position position { get; set; }
	public MaskPosition maskPosition { get; set; }
	public MostCommonColor mostCommonColor { get; set; }
}

public class MaskPosition {
	public int x { get; set; }
	public int y { get; set; }
	public int w { get; set; }
	public int h { get; set; }
}

public class MostCommonColor {
	public int r { get; set; }
	public int g { get; set; }
	public int b { get; set; }
	public int a { get; set; }
}

public class Position {
	public int x { get; set; }
	public int y { get; set; }
	public int w { get; set; }
	public int h { get; set; }
}

public class Sprite {
	public string spriteSheetName { get; set; }
	public int atlasId { get; set; }
	public List<Element> elements { get; set; }
}

public class SpriteData {
	public int padding { get; set; }
	public int index { get; set; }
	public string spriteSheetName { get; set; }
	public int aId { get; set; }
	public bool isT { get; set; }
	public Position position { get; set; }
	public MaskPosition maskPosition { get; set; }
	public MostCommonColor mostCommonColor { get; set; }
}
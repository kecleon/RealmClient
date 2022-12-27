using System.Xml.Serialization;

namespace RealmClient.Assets;

[XmlRoot(ElementName="ImageSet", Namespace="")]public class ImageSet {
	[XmlAttribute(AttributeName="name", Namespace="")]
	public String name;
	[XmlAttribute(AttributeName="resource", Namespace="")]
	public String resource;
	[XmlAttribute(AttributeName="frameWidth", Namespace="")]
	public String frameWidth;
	[XmlAttribute(AttributeName="frameHeight", Namespace="")]
	public String frameHeight;
	[XmlAttribute(AttributeName="noDefinitions", Namespace="")]
	public String noDefinitions;
	[XmlAttribute(AttributeName="alphaPadding", Namespace="")]
	public String alphaPadding;
	[XmlAttribute(AttributeName="pixelPadding", Namespace="")]
	public String pixelPadding;
}

[XmlRoot(ElementName="Transform", Namespace="")]
public class Transform {
	[XmlAttribute(AttributeName="frame", Namespace="")]
	public String frame;
	[XmlAttribute(AttributeName="color", Namespace="")]
	public String color;
}

[XmlRoot(ElementName="ColorTransform", Namespace="")]
public class ColorTransform {
	[XmlElement(ElementName="Transform", Namespace="")]
	public List<Transform> Transform;
}

[XmlRoot(ElementName="ImageSets", Namespace="")]
public class ImageSets {
	[XmlElement(ElementName="ImageSet", Namespace="")]
	public List<ImageSet> ImageSet;
}

[XmlRoot(ElementName="AnimatedImageSet", Namespace="")]
public class AnimatedImageSet {
	[XmlAttribute(AttributeName="name", Namespace="")]
	public String name;
	[XmlAttribute(AttributeName="resource", Namespace="")]
	public String resource;
	[XmlAttribute(AttributeName="mask", Namespace="")]
	public String mask;
	[XmlAttribute(AttributeName="charWidth", Namespace="")]
	public String charWidth;
	[XmlAttribute(AttributeName="charHeight", Namespace="")]
	public String charHeight;
	[XmlAttribute(AttributeName="frameWidth", Namespace="")]
	public String frameWidth;
	[XmlAttribute(AttributeName="frameHeight", Namespace="")]
	public String frameHeight;
	[XmlAttribute(AttributeName="firstDir", Namespace="")]
	public String firstDir;
	[XmlAttribute(AttributeName="mergeAttackFrame", Namespace="")]
	public String mergeAttackFrame;
	[XmlAttribute(AttributeName="alphaPadding", Namespace="")]
	public String alphaPadding;
}

[XmlRoot(ElementName="AnimatedImageSets", Namespace="")]
public class AnimatedImageSets {
	[XmlElement(ElementName="AnimatedImageSet", Namespace="")]
	public List<AnimatedImageSet> AnimatedImageSet;
}

[XmlRoot(ElementName="ImporterSettings", Namespace="")]
public class ImporterSettings {
	[XmlAttribute(AttributeName="outputPath", Namespace="")]
	public String outputPath;
}

[XmlRoot(ElementName="Importer", Namespace="")]
public class Importer {
	[XmlElement(ElementName="ImageSets", Namespace="")]
	public ImageSets ImageSets;
	[XmlElement(ElementName="AnimatedImageSets", Namespace="")]
	public AnimatedImageSets AnimatedImageSets;
	[XmlElement(ElementName="ImporterSettings", Namespace="")]
	public ImporterSettings ImporterSettings;
}

[XmlRoot(ElementName="AtlasSettings", Namespace="")]
public class AtlasSettings {
	[XmlAttribute(AttributeName="type", Namespace="")]
	public String type;
	[XmlAttribute(AttributeName="sourcePath", Namespace="")]
	public String sourcePath;
	[XmlAttribute(AttributeName="outputPath", Namespace="")]
	public String outputPath;
	[XmlAttribute(AttributeName="defaultAlphaPadding", Namespace="")]
	public String defaultAlphaPadding;
	[XmlAttribute(AttributeName="groundTilesPixelPadding", Namespace="")]
	public String groundTilesPixelPadding;
}

[XmlRoot(ElementName="AssetSettings", Namespace="")]
public class AssetSettings {
	[XmlElement(ElementName="AtlasSettings", Namespace="")]
	public AtlasSettings AtlasSettings;
}

[XmlRoot(ElementName="DefinitionSettings", Namespace="")]
public class DefinitionSettings {
	[XmlAttribute(AttributeName="sourcePath", Namespace="")]
	public String sourcePath;
	[XmlAttribute(AttributeName="outputPath", Namespace="")]
	public String outputPath;
	[XmlAttribute(AttributeName="resourcePath", Namespace="")]
	public String resourcePath;
}

[XmlRoot(ElementName="Definitions", Namespace="")]
public class Definitions {
	[XmlElement(ElementName="DefinitionSettings", Namespace="")]
	public DefinitionSettings DefinitionSettings;
}

[XmlRoot(ElementName="TilesLibrary", Namespace="")]
public class TilesLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="ObjectsLibrary", Namespace="")]
public class ObjectsLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="ParticleLibrary", Namespace="")]
public class ParticleLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="SetLibrary", Namespace="")]
public class SetLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="CharactersLibrary", Namespace="")]
public class CharactersLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="SkinsLibrary", Namespace="")]
public class SkinsLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="TutorialLibrary", Namespace="")]
public class TutorialLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="ProtipsLibrary", Namespace="")]
public class ProtipsLibrary {
	[XmlAttribute(AttributeName="path", Namespace="")]
	public String path;
}

[XmlRoot(ElementName="Manifest", Namespace="")]
public class Manifest {
	[XmlElement(ElementName="Importer", Namespace="")]
	public Importer Importer;
	[XmlElement(ElementName="AssetSettings", Namespace="")]
	public AssetSettings AssetSettings;
	[XmlElement(ElementName="Definitions", Namespace="")]
	public Definitions Definitions;
	[XmlElement(ElementName="TilesLibrary", Namespace="")]
	public List<TilesLibrary> TilesLibrary;
	[XmlElement(ElementName="ObjectsLibrary", Namespace="")]
	public List<ObjectsLibrary> ObjectsLibrary;
	[XmlElement(ElementName="ParticleLibrary", Namespace="")]
	public ParticleLibrary ParticleLibrary;
	[XmlElement(ElementName="SetLibrary", Namespace="")]
	public SetLibrary SetLibrary;
	[XmlElement(ElementName="CharactersLibrary", Namespace="")]
	public CharactersLibrary CharactersLibrary;
	[XmlElement(ElementName="SkinsLibrary", Namespace="")]
	public SkinsLibrary SkinsLibrary;
	[XmlElement(ElementName="TutorialLibrary", Namespace="")]
	public List<TutorialLibrary> TutorialLibrary;
	[XmlElement(ElementName="ProtipsLibrary", Namespace="")]
	public ProtipsLibrary ProtipsLibrary;
	[XmlAttribute(AttributeName="version", Namespace="")]
	public String version;
}

[XmlRoot(ElementName="Setpiece")]
public class Setpiece {
	[XmlAttribute(AttributeName="slot")]
	public string Slot;
	[XmlAttribute(AttributeName="itemtype")]
	public string Itemtype;
	[XmlText]
	public string Text;
}

[XmlRoot(ElementName="ActivateOnEquipAll")]
public class ActivateOnEquipAll {
	[XmlAttribute(AttributeName="skinType")]
	public string SkinType;
	[XmlAttribute(AttributeName="size")]
	public string Size;
	[XmlAttribute(AttributeName="color")]
	public string Color;
	[XmlAttribute(AttributeName="bulletType")]
	public string BulletType;
	[XmlText]
	public string Text;
	[XmlAttribute(AttributeName="stat")]
	public string Stat;
	[XmlAttribute(AttributeName="amount")]
	public string Amount;
}

[XmlRoot(ElementName="ActivateOnEquip3")]
public class ActivateOnEquip3 {
	[XmlAttribute(AttributeName="stat")]
	public string Stat;
	[XmlAttribute(AttributeName="amount")]
	public string Amount;
	[XmlText]
	public string Text;
}

[XmlRoot(ElementName="ActivateOnEquip2")]
public class ActivateOnEquip2 {
	[XmlAttribute(AttributeName="stat")]
	public string Stat;
	[XmlAttribute(AttributeName="amount")]
	public string Amount;
	[XmlText]
	public string Text;
}

[XmlRoot(ElementName="EquipmentSet")]
public class EquipmentSet {
	[XmlElement(ElementName="Setpiece")]
	public List<Setpiece> Setpiece;
	[XmlElement(ElementName="ActivateOnEquipAll")]
	public List<ActivateOnEquipAll> ActivateOnEquipAll;
	[XmlElement(ElementName="ActivateOnEquip3")]
	public List<ActivateOnEquip3> ActivateOnEquip3;
	[XmlElement(ElementName="ActivateOnEquip2")]
	public List<ActivateOnEquip2> ActivateOnEquip2;
	[XmlAttribute(AttributeName="type")]
	public string Type;
	[XmlAttribute(AttributeName="id")]
	public string Id;
	[XmlElement(ElementName="ActivateOnEquipCustom")]
	public List<ActivateOnEquipCustom> ActivateOnEquipCustom;
}

[XmlRoot(ElementName="ActivateOnEquipCustom")]
public class ActivateOnEquipCustom {
	[XmlAttribute(AttributeName="skinType")]
	public string SkinType;
	[XmlAttribute(AttributeName="size")]
	public string Size;
	[XmlAttribute(AttributeName="color")]
	public string Color;
	[XmlAttribute(AttributeName="bulletType")]
	public string BulletType;
	[XmlAttribute(AttributeName="requiredItems")]
	public string RequiredItems;
	[XmlText]
	public string Text;
}

[XmlRoot(ElementName="EquipmentSets")]
public class EquipmentSets {
	[XmlElement(ElementName="EquipmentSet")]
	public List<EquipmentSet> EquipmentSet;
}
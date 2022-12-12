using System.Xml.Serialization;

namespace RealmClient.Xml;

[XmlRoot(ElementName = "Abilities")]
public class Abilities {
	[XmlElement(ElementName = "Ability")] public List<Ability> Ability { get; set; }
}

[XmlRoot(ElementName = "Ability")]
public class Ability {
	[XmlAttribute(AttributeName = "type")] public int Type { get; set; }

	[XmlAttribute(AttributeName = "power")]
	public int Power { get; set; }

	[XmlAttribute(AttributeName = "points")]
	public int Points { get; set; }
}

[XmlRoot(ElementName = "Account")]
public class Account {
	[XmlElement(ElementName = "Credits")] public int Credits { get; set; }

	[XmlElement(ElementName = "FortuneToken")]
	public int FortuneToken { get; set; }

	[XmlElement(ElementName = "UnityCampaignPoints")]
	public int UnityCampaignPoints { get; set; }

	[XmlElement(ElementName = "NextCharSlotPrice")]
	public int NextCharSlotPrice { get; set; }

	[XmlElement(ElementName = "EarlyGameEventTracker")]
	public int EarlyGameEventTracker { get; set; }

	[XmlElement(ElementName = "AccountId")]
	public double AccountId { get; set; }

	[XmlElement(ElementName = "CreationTimestamp")]
	public int CreationTimestamp { get; set; }

	[XmlElement(ElementName = "HasGifts")] public object HasGifts { get; set; }

	[XmlElement(ElementName = "VerifiedEmail")]
	public object VerifiedEmail { get; set; }

	[XmlElement(ElementName = "DecaSignupPopup")]
	public object DecaSignupPopup { get; set; }

	[XmlElement(ElementName = "MaxNumChars")]
	public int MaxNumChars { get; set; }

	[XmlElement(ElementName = "MutedUntil")]
	public int MutedUntil { get; set; }

	[XmlElement(ElementName = "LastServer")]
	public string LastServer { get; set; }

	[XmlElement(ElementName = "TeleportWait")]
	public int TeleportWait { get; set; }

	[XmlElement(ElementName = "Originating")]
	public string Originating { get; set; }

	[XmlElement(ElementName = "PetYardType")]
	public int PetYardType { get; set; }

	[XmlElement(ElementName = "ForgeFireEnergy")]
	public int ForgeFireEnergy { get; set; }

	[XmlElement(ElementName = "ForgeFireBlueprints")]
	public double ForgeFireBlueprints { get; set; }

	[XmlElement(ElementName = "Campaigns")]
	public object Campaigns { get; set; }

	[XmlElement(ElementName = "Name")] public string Name { get; set; }

	[XmlElement(ElementName = "NameChosen")]
	public object NameChosen { get; set; }

	[XmlElement(ElementName = "PaymentProvider")]
	public string PaymentProvider { get; set; }

	[XmlElement(ElementName = "Converted")]
	public object Converted { get; set; }

	[XmlElement(ElementName = "IsAgeVerified")]
	public int IsAgeVerified { get; set; }

	[XmlElement(ElementName = "SecurityQuestions")]
	public SecurityQuestions SecurityQuestions { get; set; }

	[XmlElement(ElementName = "Stats")] public Stats Stats { get; set; }
	[XmlElement(ElementName = "Guild")] public Guild Guild { get; set; }

	[XmlElement(ElementName = "AccessToken")]
	public string AccessToken { get; set; }

	[XmlElement(ElementName = "AccessTokenTimestamp")]
	public int AccessTokenTimestamp { get; set; }

	[XmlElement(ElementName = "AccessTokenExpiration")]
	public int AccessTokenExpiration { get; set; }

	[XmlElement(ElementName = "OwnedSkins")]
	public double OwnedSkins { get; set; }

	[XmlElement(ElementName = "OwnedTitles")]
	public double OwnedTitles { get; set; }

	[XmlElement(ElementName = "OwnedGravestones")]
	public int OwnedGravestones { get; set; }

	[XmlElement(ElementName = "Gravestones")]
	public string Gravestones { get; set; }
}

[XmlRoot(ElementName = "Account")]
public class Account {
	[XmlElement(ElementName = "Name")] public string Name { get; set; }
	[XmlElement(ElementName = "Credits")] public int Credits { get; set; }

	[XmlElement(ElementName = "FortuneToken")]
	public int FortuneToken { get; set; }

	[XmlElement(ElementName = "UnityCampaignPoints")]
	public int UnityCampaignPoints { get; set; }

	[XmlElement(ElementName = "NextCharSlotPrice")]
	public int NextCharSlotPrice { get; set; }

	[XmlElement(ElementName = "EarlyGameEventTracker")]
	public int EarlyGameEventTracker { get; set; }

	[XmlElement(ElementName = "AccountId")]
	public double AccountId { get; set; }

	[XmlElement(ElementName = "CreationTimestamp")]
	public int CreationTimestamp { get; set; }

	[XmlElement(ElementName = "VerifiedEmail")]
	public object VerifiedEmail { get; set; }

	[XmlElement(ElementName = "DecaSignupPopup")]
	public object DecaSignupPopup { get; set; }

	[XmlElement(ElementName = "MaxNumChars")]
	public int MaxNumChars { get; set; }

	[XmlElement(ElementName = "MutedUntil")]
	public int MutedUntil { get; set; }

	[XmlElement(ElementName = "LastServer")]
	public string LastServer { get; set; }

	[XmlElement(ElementName = "TeleportWait")]
	public int TeleportWait { get; set; }

	[XmlElement(ElementName = "Originating")]
	public string Originating { get; set; }

	[XmlElement(ElementName = "PetYardType")]
	public int PetYardType { get; set; }

	[XmlElement(ElementName = "ForgeFireEnergy")]
	public int ForgeFireEnergy { get; set; }

	[XmlElement(ElementName = "ForgeFireBlueprints")]
	public double ForgeFireBlueprints { get; set; }

	[XmlElement(ElementName = "Campaigns")]
	public object Campaigns { get; set; }

	[XmlElement(ElementName = "NameChosen")]
	public object NameChosen { get; set; }

	[XmlElement(ElementName = "PaymentProvider")]
	public string PaymentProvider { get; set; }

	[XmlElement(ElementName = "Converted")]
	public object Converted { get; set; }

	[XmlElement(ElementName = "IsAgeVerified")]
	public int IsAgeVerified { get; set; }

	[XmlElement(ElementName = "SecurityQuestions")]
	public SecurityQuestions SecurityQuestions { get; set; }

	[XmlElement(ElementName = "Stats")] public Stats Stats { get; set; }
	[XmlElement(ElementName = "Guild")] public Guild Guild { get; set; }

	[XmlElement(ElementName = "AccessToken")]
	public object AccessToken { get; set; }

	[XmlElement(ElementName = "AccessTokenTimestamp")]
	public int AccessTokenTimestamp { get; set; }

	[XmlElement(ElementName = "AccessTokenExpiration")]
	public int AccessTokenExpiration { get; set; }

	[XmlElement(ElementName = "OwnedSkins")]
	public double OwnedSkins { get; set; }

	[XmlElement(ElementName = "OwnedTitles")]
	public double OwnedTitles { get; set; }

	[XmlElement(ElementName = "OwnedGravestones")]
	public int OwnedGravestones { get; set; }

	[XmlElement(ElementName = "Gravestones")]
	public string Gravestones { get; set; }
}

[XmlRoot(ElementName = "AccountPowerups")]
public class AccountPowerups {
	[XmlElement(ElementName = "ClassPowerup")]
	public ClassPowerup ClassPowerup { get; set; }
}

[XmlRoot(ElementName = "AppSettings")]
public class AppSettings {
	[XmlElement(ElementName = "UseExternalPayments")]
	public int UseExternalPayments { get; set; }

	[XmlElement(ElementName = "MaxStackablePotions")]
	public int MaxStackablePotions { get; set; }

	[XmlElement(ElementName = "PotionPurchaseCooldown")]
	public int PotionPurchaseCooldown { get; set; }

	[XmlElement(ElementName = "PotionPurchaseCostCooldown")]
	public int PotionPurchaseCostCooldown { get; set; }

	[XmlElement(ElementName = "PotionPurchaseCosts")]
	public PotionPurchaseCosts PotionPurchaseCosts { get; set; }

	[XmlElement(ElementName = "FilterList")]
	public string FilterList { get; set; }

	[XmlElement(ElementName = "DisableRegist")]
	public int DisableRegist { get; set; }

	[XmlElement(ElementName = "MysteryBoxRefresh")]
	public int MysteryBoxRefresh { get; set; }

	[XmlElement(ElementName = "SalesforceMobile")]
	public int SalesforceMobile { get; set; }

	[XmlElement(ElementName = "UGDOpenSubmission")]
	public int UGDOpenSubmission { get; set; }

	[XmlElement(ElementName = "ForgeMaxIngredients")]
	public int ForgeMaxIngredients { get; set; }

	[XmlElement(ElementName = "ForgeMaxEnergy")]
	public int ForgeMaxEnergy { get; set; }

	[XmlElement(ElementName = "ForgeInitialEnergy")]
	public int ForgeInitialEnergy { get; set; }

	[XmlElement(ElementName = "ForgeDailyEnergy")]
	public int ForgeDailyEnergy { get; set; }

	[XmlElement(ElementName = "BuildId")] public string BuildId { get; set; }

	[XmlElement(ElementName = "BuildHash")]
	public string BuildHash { get; set; }

	[XmlElement(ElementName = "BuildVersion")]
	public string BuildVersion { get; set; }

	[XmlElement(ElementName = "BuildCDN")] public string BuildCDN { get; set; }

	[XmlElement(ElementName = "LauncherBuildId")]
	public string LauncherBuildId { get; set; }

	[XmlElement(ElementName = "LauncherBuildHash")]
	public string LauncherBuildHash { get; set; }

	[XmlElement(ElementName = "LauncherBuildVersion")]
	public string LauncherBuildVersion { get; set; }

	[XmlElement(ElementName = "LauncherBuildCDN")]
	public string LauncherBuildCDN { get; set; }
}

[XmlRoot(ElementName = "Char")]
public class Char {
	[XmlElement(ElementName = "ObjectType")]
	public int ObjectType { get; set; }

	[XmlElement(ElementName = "Seasonal")] public bool Seasonal { get; set; }
	[XmlElement(ElementName = "Level")] public int Level { get; set; }
	[XmlElement(ElementName = "Exp")] public int Exp { get; set; }

	[XmlElement(ElementName = "CurrentFame")]
	public int CurrentFame { get; set; }

	[XmlElement(ElementName = "Equipment")]
	public string Equipment { get; set; }

	[XmlElement(ElementName = "EquipQS")] public string EquipQS { get; set; }

	[XmlElement(ElementName = "MaxHitPoints")]
	public int MaxHitPoints { get; set; }

	[XmlElement(ElementName = "HitPoints")]
	public int HitPoints { get; set; }

	[XmlElement(ElementName = "MaxMagicPoints")]
	public int MaxMagicPoints { get; set; }

	[XmlElement(ElementName = "MagicPoints")]
	public int MagicPoints { get; set; }

	[XmlElement(ElementName = "Attack")] public int Attack { get; set; }
	[XmlElement(ElementName = "Defense")] public int Defense { get; set; }
	[XmlElement(ElementName = "Speed")] public int Speed { get; set; }

	[XmlElement(ElementName = "Dexterity")]
	public int Dexterity { get; set; }

	[XmlElement(ElementName = "HpRegen")] public int HpRegen { get; set; }
	[XmlElement(ElementName = "MpRegen")] public int MpRegen { get; set; }
	[XmlElement(ElementName = "PCStats")] public string PCStats { get; set; }

	[XmlElement(ElementName = "HealthStackCount")]
	public int HealthStackCount { get; set; }

	[XmlElement(ElementName = "MagicStackCount")]
	public int MagicStackCount { get; set; }

	[XmlElement(ElementName = "Dead")] public bool Dead { get; set; }
	[XmlElement(ElementName = "Account")] public Account Account { get; set; }
	[XmlElement(ElementName = "Texture")] public int Texture { get; set; }
	[XmlElement(ElementName = "Titles")] public double Titles { get; set; }

	[XmlElement(ElementName = "XpBoosted")]
	public int XpBoosted { get; set; }

	[XmlElement(ElementName = "XpTimer")] public int XpTimer { get; set; }
	[XmlElement(ElementName = "LDTimer")] public int LDTimer { get; set; }
	[XmlElement(ElementName = "LTTimer")] public int LTTimer { get; set; }

	[XmlElement(ElementName = "UniqueItemInfo")]
	public UniqueItemInfo UniqueItemInfo { get; set; }

	[XmlElement(ElementName = "HasBackpack")]
	public int HasBackpack { get; set; }

	[XmlElement(ElementName = "Has3Quickslots")]
	public int Has3Quickslots { get; set; }

	[XmlElement(ElementName = "CreationDate")]
	public DateTime CreationDate { get; set; }

	[XmlAttribute(AttributeName = "id")] public int Id { get; set; }
	[XmlText] public string Text { get; set; }
	[XmlElement(ElementName = "Pet")] public Pet Pet { get; set; }
	[XmlElement(ElementName = "Tex1")] public int Tex1 { get; set; }
	[XmlElement(ElementName = "Tex2")] public int Tex2 { get; set; }
}

[XmlRoot(ElementName = "Chars")]
public class Chars {
	[XmlElement(ElementName = "Char")] public List<Char> Char { get; set; }
	[XmlElement(ElementName = "Account")] public Account Account { get; set; }
	[XmlElement(ElementName = "News")] public News News { get; set; }
	[XmlElement(ElementName = "Servers")] public Servers Servers { get; set; }
	[XmlElement(ElementName = "Lat")] public double Lat { get; set; }
	[XmlElement(ElementName = "Long")] public double Long { get; set; }

	[XmlElement(ElementName = "NewsletterEmail")]
	public string NewsletterEmail { get; set; }

	[XmlElement(ElementName = "ClassAvailabilityList")]
	public ClassAvailabilityList ClassAvailabilityList { get; set; }

	[XmlElement(ElementName = "ItemCosts")]
	public ItemCosts ItemCosts { get; set; }

	[XmlElement(ElementName = "PowerUpStats")]
	public PowerUpStats PowerUpStats { get; set; }

	[XmlElement(ElementName = "DecaSignupPopup")]
	public object DecaSignupPopup { get; set; }

	[XmlElement(ElementName = "MaxClassLevelList")]
	public MaxClassLevelList MaxClassLevelList { get; set; }

	[XmlAttribute(AttributeName = "nextCharId")]
	public int NextCharId { get; set; }

	[XmlAttribute(AttributeName = "maxNumChars")]
	public int MaxNumChars { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "ClassAvailability")]
public class ClassAvailability {
	[XmlAttribute(AttributeName = "id")] public string Id { get; set; }
	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "ClassAvailabilityList")]
public class ClassAvailabilityList {
	[XmlElement(ElementName = "ClassAvailability")]
	public List<ClassAvailability> ClassAvailability { get; set; }
}

[XmlRoot(ElementName = "ClassPowerup")]
public class ClassPowerup {
	[XmlElement(ElementName = "Class")] public int Class { get; set; }
	[XmlElement(ElementName = "Dex")] public int Dex { get; set; }
	[XmlElement(ElementName = "Spd")] public int Spd { get; set; }
	[XmlElement(ElementName = "Vit")] public int Vit { get; set; }
	[XmlElement(ElementName = "Wis")] public int Wis { get; set; }
	[XmlElement(ElementName = "Def")] public int Def { get; set; }
	[XmlElement(ElementName = "Att")] public int Att { get; set; }
	[XmlElement(ElementName = "Mana")] public int Mana { get; set; }
	[XmlElement(ElementName = "Life")] public int Life { get; set; }
}

[XmlRoot(ElementName = "ClassStats")]
public class ClassStats {
	[XmlElement(ElementName = "BestLevel")]
	public int BestLevel { get; set; }

	[XmlElement(ElementName = "BestBaseFame")]
	public int BestBaseFame { get; set; }

	[XmlElement(ElementName = "BestTotalFame")]
	public int BestTotalFame { get; set; }

	[XmlAttribute(AttributeName = "objectType")]
	public string ObjectType { get; set; }

	[XmlText] public int Text { get; set; }

	[XmlAttribute(AttributeName = "class")]
	public int Class { get; set; }
}

[XmlRoot(ElementName = "Consecutive")]
public class Consecutive {
	[XmlAttribute(AttributeName = "days")] public int Days { get; set; }
}

[XmlRoot(ElementName = "Deals")]
public class Deals {
	[XmlElement(ElementName = "MiniGames")]
	public MiniGames MiniGames { get; set; }

	[XmlElement(ElementName = "Packages")] public Packages Packages { get; set; }
}

[XmlRoot(ElementName = "Guild")]
public class Guild {
	[XmlElement(ElementName = "Name")] public string Name { get; set; }
	[XmlElement(ElementName = "Rank")] public int Rank { get; set; }
	[XmlAttribute(AttributeName = "id")] public double Id { get; set; }
	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "Guild")]
public class Guild {
	[XmlElement(ElementName = "Name")] public string Name { get; set; }
	[XmlElement(ElementName = "Rank")] public int Rank { get; set; }
	[XmlAttribute(AttributeName = "id")] public double Id { get; set; }
	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "Item")]
public class Item {
	[XmlElement(ElementName = "Icon")] public string Icon { get; set; }
	[XmlElement(ElementName = "Title")] public string Title { get; set; }
	[XmlElement(ElementName = "Seasonal")] public bool Seasonal { get; set; }
	[XmlElement(ElementName = "TagLine")] public string TagLine { get; set; }
	[XmlElement(ElementName = "Link")] public string Link { get; set; }
	[XmlElement(ElementName = "Date")] public int Date { get; set; }
}

[XmlRoot(ElementName = "ItemCost")]
public class ItemCost {
	[XmlAttribute(AttributeName = "type")] public int Type { get; set; }

	[XmlAttribute(AttributeName = "purchasable")]
	public int Purchasable { get; set; }

	[XmlAttribute(AttributeName = "expires")]
	public int Expires { get; set; }

	[XmlText] public int Text { get; set; }
}

[XmlRoot(ElementName = "ItemCosts")]
public class ItemCosts {
	[XmlElement(ElementName = "ItemCost")] public List<ItemCost> ItemCost { get; set; }
}

[XmlRoot(ElementName = "ItemData")]
public class ItemData {
	[XmlAttribute(AttributeName = "type")] public int Type { get; set; }
}

[XmlRoot(ElementName = "ItemId")]
public class ItemId {
	[XmlAttribute(AttributeName = "quantity")]
	public int Quantity { get; set; }

	[XmlText] public int Text { get; set; }
}

[XmlRoot(ElementName = "Login")]
public class Login {
	[XmlElement(ElementName = "Days")] public int Days { get; set; }
	[XmlElement(ElementName = "ItemId")] public ItemId ItemId { get; set; }
	[XmlElement(ElementName = "Gold")] public int Gold { get; set; }
	[XmlElement(ElementName = "key")] public string Key { get; set; }
}

[XmlRoot(ElementName = "LoginRewards")]
public class LoginRewards {
	[XmlElement(ElementName = "NonConsecutive")]
	public NonConsecutive NonConsecutive { get; set; }

	[XmlElement(ElementName = "Consecutive")]
	public Consecutive Consecutive { get; set; }

	[XmlElement(ElementName = "Unlockable")]
	public Unlockable Unlockable { get; set; }

	[XmlAttribute(AttributeName = "serverTime")]
	public double ServerTime { get; set; }

	[XmlAttribute(AttributeName = "conCurDay")]
	public int ConCurDay { get; set; }

	[XmlAttribute(AttributeName = "nonconCurDay")]
	public int NonconCurDay { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "MaxClassLevel")]
public class MaxClassLevel {
	[XmlAttribute(AttributeName = "classType")]
	public int ClassType { get; set; }

	[XmlAttribute(AttributeName = "maxLevel")]
	public int MaxLevel { get; set; }
}

[XmlRoot(ElementName = "MaxClassLevelList")]
public class MaxClassLevelList {
	[XmlElement(ElementName = "MaxClassLevel")]
	public List<MaxClassLevel> MaxClassLevel { get; set; }
}

[XmlRoot(ElementName = "MiniGames")]
public class MiniGames {
	[XmlElement(ElementName = "MysteryBox")]
	public List<MysteryBox> MysteryBox { get; set; }

	[XmlAttribute(AttributeName = "version")]
	public double Version { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "MysteryBox")]
public class MysteryBox {
	[XmlElement(ElementName = "Description")]
	public object Description { get; set; }

	[XmlElement(ElementName = "Contents")] public string Contents { get; set; }

	[XmlElement(ElementName = "BonusPoints")]
	public int BonusPoints { get; set; }

	[XmlElement(ElementName = "Price")] public Price Price { get; set; }
	[XmlElement(ElementName = "Image")] public object Image { get; set; }
	[XmlElement(ElementName = "Icon")] public object Icon { get; set; }

	[XmlElement(ElementName = "StartTime")]
	public DateTime StartTime { get; set; }

	[XmlElement(ElementName = "Left")] public int Left { get; set; }
	[XmlElement(ElementName = "Total")] public int Total { get; set; }

	[XmlElement(ElementName = "MaxPurchase")]
	public int MaxPurchase { get; set; }

	[XmlElement(ElementName = "PurchaseLeft")]
	public int PurchaseLeft { get; set; }

	[XmlElement(ElementName = "Tags")] public object Tags { get; set; }
	[XmlElement(ElementName = "Slot")] public int Slot { get; set; }
	[XmlElement(ElementName = "Jackpots")] public string Jackpots { get; set; }

	[XmlElement(ElementName = "DisplayedItems")]
	public double DisplayedItems { get; set; }

	[XmlElement(ElementName = "EndTime")] public DateTime EndTime { get; set; }
	[XmlElement(ElementName = "Rolls")] public int Rolls { get; set; }
	[XmlElement(ElementName = "Category")] public string Category { get; set; }
	[XmlElement(ElementName = "Platform")] public int Platform { get; set; }

	[XmlElement(ElementName = "Background")]
	public int Background { get; set; }

	[XmlElement(ElementName = "Sale")] public Sale Sale { get; set; }
	[XmlAttribute(AttributeName = "id")] public int Id { get; set; }

	[XmlAttribute(AttributeName = "title")]
	public string Title { get; set; }

	[XmlAttribute(AttributeName = "weight")]
	public int Weight { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "News")]
public class News {
	[XmlElement(ElementName = "Item")] public List<Item> Item { get; set; }
}

[XmlRoot(ElementName = "NonConsecutive")]
public class NonConsecutive {
	[XmlElement(ElementName = "Login")] public List<Login> Login { get; set; }
	[XmlAttribute(AttributeName = "days")] public int Days { get; set; }
	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "Package")]
public class Package {
	[XmlElement(ElementName = "Description")]
	public object Description { get; set; }

	[XmlElement(ElementName = "Contents")] public double Contents { get; set; }
	[XmlElement(ElementName = "Price")] public Price Price { get; set; }

	[XmlElement(ElementName = "StartTime")]
	public DateTime StartTime { get; set; }

	[XmlElement(ElementName = "Left")] public int Left { get; set; }

	[XmlElement(ElementName = "MaxPurchase")]
	public int MaxPurchase { get; set; }

	[XmlElement(ElementName = "PurchaseLeft")]
	public int PurchaseLeft { get; set; }

	[XmlElement(ElementName = "Total")] public int Total { get; set; }
	[XmlElement(ElementName = "Tags")] public object Tags { get; set; }
	[XmlElement(ElementName = "Slot")] public int Slot { get; set; }
	[XmlElement(ElementName = "EndTime")] public DateTime EndTime { get; set; }
	[XmlElement(ElementName = "Image")] public object Image { get; set; }

	[XmlElement(ElementName = "ShowOnLogin")]
	public int ShowOnLogin { get; set; }

	[XmlElement(ElementName = "CharSlot")] public int CharSlot { get; set; }

	[XmlElement(ElementName = "VaultSlot")]
	public int VaultSlot { get; set; }

	[XmlElement(ElementName = "Gold")] public int Gold { get; set; }

	[XmlElement(ElementName = "PopupImage")]
	public object PopupImage { get; set; }

	[XmlElement(ElementName = "BonusPoints")]
	public int BonusPoints { get; set; }

	[XmlElement(ElementName = "Category")] public string Category { get; set; }

	[XmlElement(ElementName = "Background")]
	public int Background { get; set; }

	[XmlElement(ElementName = "Platform")] public int Platform { get; set; }

	[XmlElement(ElementName = "DisplayedItems")]
	public int DisplayedItems { get; set; }

	[XmlElement(ElementName = "Sale")] public Sale Sale { get; set; }
	[XmlAttribute(AttributeName = "id")] public int Id { get; set; }

	[XmlAttribute(AttributeName = "title")]
	public string Title { get; set; }

	[XmlAttribute(AttributeName = "weight")]
	public int Weight { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "Packages")]
public class Packages {
	[XmlElement(ElementName = "Package")] public List<Package> Package { get; set; }

	[XmlAttribute(AttributeName = "version")]
	public double Version { get; set; }

	[XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "Pet")]
public class Pet {
	[XmlElement(ElementName = "Abilities")]
	public Abilities Abilities { get; set; }

	[XmlAttribute(AttributeName = "name")] public string Name { get; set; }
	[XmlAttribute(AttributeName = "type")] public int Type { get; set; }

	[XmlAttribute(AttributeName = "instanceId")]
	public int InstanceId { get; set; }

	[XmlAttribute(AttributeName = "rarity")]
	public int Rarity { get; set; }

	[XmlAttribute(AttributeName = "maxAbilityPower")]
	public int MaxAbilityPower { get; set; }

	[XmlAttribute(AttributeName = "skin")] public int Skin { get; set; }

	[XmlAttribute(AttributeName = "createdOn")]
	public DateTime CreatedOn { get; set; }
}

[XmlRoot(ElementName = "PotionPurchaseCosts")]
public class PotionPurchaseCosts {
	[XmlElement(ElementName = "cost")] public List<int> Cost { get; set; }
}

[XmlRoot(ElementName = "PowerUpStats")]
public class PowerUpStats {
	[XmlElement(ElementName = "ClassStats")]
	public ClassStats ClassStats { get; set; }
}

[XmlRoot(ElementName = "Price")]
public class Price {
	[XmlAttribute(AttributeName = "amount")]
	public int Amount { get; set; }

	[XmlAttribute(AttributeName = "currency")]
	public int Currency { get; set; }
}

[XmlRoot(ElementName = "Result")]
public class Result {
	[XmlElement(ElementName = "StarredAccounts")]
	public List<string> StarredAccounts { get; set; }
}

[XmlRoot(ElementName = "Sale")]
public class Sale {
	[XmlAttribute(AttributeName = "price")]
	public int Price { get; set; }

	[XmlAttribute(AttributeName = "currency")]
	public int Currency { get; set; }
}

[XmlRoot(ElementName = "SecurityQuestions")]
public class SecurityQuestions {
	[XmlElement(ElementName = "HasSecurityQuestions")]
	public int HasSecurityQuestions { get; set; }

	[XmlElement(ElementName = "ShowSecurityQuestionsDialog")]
	public int ShowSecurityQuestionsDialog { get; set; }

	[XmlElement(ElementName = "SecurityQuestionsKeys")]
	public SecurityQuestionsKeys SecurityQuestionsKeys { get; set; }
}

[XmlRoot(ElementName = "SecurityQuestions")]
public class SecurityQuestions {
	[XmlElement(ElementName = "HasSecurityQuestions")]
	public int HasSecurityQuestions { get; set; }

	[XmlElement(ElementName = "ShowSecurityQuestionsDialog")]
	public int ShowSecurityQuestionsDialog { get; set; }

	[XmlElement(ElementName = "SecurityQuestionsKeys")]
	public SecurityQuestionsKeys SecurityQuestionsKeys { get; set; }
}

[XmlRoot(ElementName = "SecurityQuestionsKeys")]
public class SecurityQuestionsKeys {
	[XmlElement(ElementName = "SecurityQuestionsKey")]
	public List<string> SecurityQuestionsKey { get; set; }
}

[XmlRoot(ElementName = "SecurityQuestionsKeys")]
public class SecurityQuestionsKeys {
	[XmlElement(ElementName = "SecurityQuestionsKey")]
	public List<string> SecurityQuestionsKey { get; set; }
}

[XmlRoot(ElementName = "Server")]
public class Server {
	[XmlElement(ElementName = "Name")] public string Name { get; set; }
	[XmlElement(ElementName = "DNS")] public string DNS { get; set; }
	[XmlElement(ElementName = "Lat")] public double Lat { get; set; }
	[XmlElement(ElementName = "Long")] public double Long { get; set; }
	[XmlElement(ElementName = "Usage")] public double Usage { get; set; }
}

[XmlRoot(ElementName = "Server")]
public class Server {
	[XmlElement(ElementName = "Name")] public string Name { get; set; }
	[XmlElement(ElementName = "DNS")] public string DNS { get; set; }
	[XmlElement(ElementName = "Lat")] public double Lat { get; set; }
	[XmlElement(ElementName = "Long")] public double Long { get; set; }
	[XmlElement(ElementName = "Usage")] public double Usage { get; set; }
}

[XmlRoot(ElementName = "Servers")]
public class Servers {
	[XmlElement(ElementName = "Server")] public List<Server> Server { get; set; }
}

[XmlRoot(ElementName = "Servers")]
public class Servers {
	[XmlElement(ElementName = "Server")] public List<Server> Server { get; set; }
}

[XmlRoot(ElementName = "ServerStatus")]
public class ServerStatus {
	[XmlElement(ElementName = "Type")] public string Type { get; set; }
	[XmlElement(ElementName = "Link")] public object Link { get; set; }
	[XmlElement(ElementName = "Text")] public string Text { get; set; }
	[XmlElement(ElementName = "Date")] public int Date { get; set; }
} // using System.Xml.Serialization;// XmlSerializer serializer = new XmlSerializer(typeof(Chars));// using (StringReader reader = new StringReader(xml))// {//    var test = (Chars)serializer.Deserialize(reader);// }

[XmlRoot(ElementName = "Stats")]
public class Stats {
	[XmlElement(ElementName = "ClassStats")]
	public List<ClassStats> ClassStats { get; set; }

	[XmlElement(ElementName = "BestCharFame")]
	public int BestCharFame { get; set; }

	[XmlElement(ElementName = "TotalFame")]
	public int TotalFame { get; set; }

	[XmlElement(ElementName = "Fame")] public int Fame { get; set; }
}

[XmlRoot(ElementName = "UniqueItemInfo")]
public class UniqueItemInfo {
	[XmlElement(ElementName = "ItemData")] public List<ItemData> ItemData { get; set; }
}

[XmlRoot(ElementName = "Unlockable")]
public class Unlockable {
	[XmlAttribute(AttributeName = "days")] public int Days { get; set; }
}
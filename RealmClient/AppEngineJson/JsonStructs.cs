namespace RealmClient.AppEngineJson; 

public class LeaderboardActive
{
	public bool seasonal { get; set; }
	public string dungeon { get; set; }
	public int endDate { get; set; }
	public int startDate { get; set; }
	public string title { get; set; }
	public string desc { get; set; }
}

public class BattlePass
{
	public int weeklyExaltBxpCap { get; set; }
	public List<Milestone> milestones { get; set; }
	public int end { get; set; }
	public string title { get; set; }
	public bool exalted { get; set; }
	public int bxp { get; set; }
	public int start { get; set; }
	public string backgroundUrl { get; set; }
	public int weeklyBxpCap { get; set; }
	public List<object> claimed { get; set; }
	public int exaltedPrice { get; set; }
	public List<Boost> boost { get; set; }
	public long id { get; set; }
	public int coupons { get; set; }
	public Previous previous { get; set; }
}

public class Boost
{
	public int price { get; set; }
	public int amount { get; set; }
}

public class ExaltItem
{
	public int amount { get; set; }
	public int type { get; set; }
	public bool autoconsume { get; set; }
}

public class Item
{
	public int amount { get; set; }
	public int type { get; set; }
	public bool autoconsume { get; set; }
}

public class Milestone
{
	public int bxp { get; set; }
	public Rewards rewards { get; set; }
	public int id { get; set; }
}

public class Previous
{
	public int coupons { get; set; }
}

public class Rewards
{
	public List<Item> items { get; set; }
	public List<ExaltItem> exaltItems { get; set; }
	public int exaltedCoupons { get; set; }
	public int coupons { get; set; }
}

public class Root
{
	public int start { get; set; }
	public BattlePass battlePass { get; set; }
	public int end { get; set; }
	public long id { get; set; }
	public string name { get; set; }
}


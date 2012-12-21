using System;
using NUnit.Framework;

namespace myJSONFX
{
	[TestFixture()]
	public class JSONTest
	{
		[Test()]
		public void TestDecode()
		{			
			string json = "{\"Action\":{\"Value\":3,\"Action\":\"AchievementHoleInOnes\"},\"Id\":\"48\",\"Name\":\"Get 3 Hole in Ones\"}";

			JsonFx.Json.JsonReader reader = new JsonFx.Json.JsonReader();
			Achievement ach = (Achievement)reader.Read(json, typeof(Achievement) );
			
			Assert.AreEqual ("AchievementAction", ach.Action.GetType().ToString());
			
			Assert.AreEqual(ach.Action.Value, 3);
			Assert.AreEqual(ach.Action.Action, "AchievementHoleInOnes");
			Assert.AreEqual(ach.Id, "48");
			Assert.AreEqual(ach.Name, "Get 3 Hole in Ones");
		}
		
		[Test()]
		public void TestEncode()
		{			
			Achievement ach = new Achievement();
			ach.Action.Value = 17;
			ach.Action.Action = "Birdies";
			ach.Name = "IMBA";
			ach.Id = "0x0l0l0";
			


			JsonFx.Json.JsonWriter writer = new JsonFx.Json.JsonWriter();
			string actual = writer.Write(ach);

			string expectedJson = "{\"Action\":{\"Value\":17,\"Action\":\"Birdies\"},\"Id\":\"0x0l0l0\",\"Name\":\"IMBA\"}";
			Assert.AreEqual(expectedJson, actual );
		}
	}
}





	
/// <summary>
/// Action to unlock achievement.
/// Describes what and how many times.
/// Like get 5 birdies (Value=5, Action="birdie")
/// </summary>
public class AchievementAction 
{	
	public int Value = 0;
	public string Action = "";
	
	public AchievementAction (string action, int value) {
		
		this.Value = value;
		this.Action = action;
	}
	
	public AchievementAction () {}
}
	
/// <summary>
/// Achievement in Set of Levels in Universe.
/// Describes achievement & what should be done to unlock it.
/// </summary>
public class Achievement 
{
	
	// TODO: document what it does here
	public AchievementAction Action = new AchievementAction();
	
	/// <summary>
	/// Unique Achievement ID, can be used to unlock one.
	/// Must be a string, that contains number.
	/// Like "42"
	/// </summary>
	public string Id = "";
	
	/// <summary>
	/// Just a display name, not Identifier.
	/// </summary>
	public string Name = "";
	
	public Achievement (string id, string name, string action, int actionValue) {
		
		this.Id = id;
		this.Name = name;
		this.Action.Action = action;
		this.Action.Value = actionValue;
	}
	
	public Achievement () {}
}




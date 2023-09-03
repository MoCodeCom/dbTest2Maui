using System;
using SQLite;

namespace dbTest2.Model
{
	[Table("users")]
	public class userModel
	{
		[AutoIncrement, PrimaryKey]
		public int id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
	}
}


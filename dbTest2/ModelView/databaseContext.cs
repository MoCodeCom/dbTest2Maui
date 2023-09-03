using System;
using System.Linq.Expressions;
using dbTest2.Model;
using SQLite;


namespace dbTest2.ModelView
{
	public class databaseContext
	{
		private const string DbName = "sqlDb.db3";
		public static string DbPath { get; } = Path.Combine(FileSystem.AppDataDirectory, DbName);
		private readonly SQLiteConnection _database;
		public databaseContext()
		{
			_database = new SQLiteConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
			_database.CreateTable<userModel>();
		}
		
		private SQLiteAsyncConnection _conn;
		private SQLiteAsyncConnection Database =>
			(_conn ??= new SQLiteAsyncConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));

		
		public async Task<List<userModel>> GetAllUsers()
		{
			return await Database.Table<userModel>().ToListAsync();
		}

		public List<userModel> List()
		{
			return _database.Table<userModel>().ToList();
		}

	}
}


using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stoper
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<MyTime>();
        }

        public Task<int> AddMyTimes(List<MyTime> myTimes)
        {
            return db.InsertAllAsync(myTimes);
        }

        public Task<List<MyTime>> ReadMyTimes()
        {
            return db.Table<MyTime>().ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CRUDXamarin.Model;

namespace CRUDXamarin
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<EmployeeModel>();
        }

        public Task<int> CreateEmplyee(EmployeeModel employee)
        {
            return db.InsertAsync(employee);
        }

        public Task<List<EmployeeModel>> ReadEmployees()
        {
            return db.Table<EmployeeModel>().ToListAsync();
        }

        public Task<int> UpdateEmplyee(EmployeeModel employee)
        {
            return db.UpdateAsync(employee);
        }

        public Task<int> DeleteEmplyee(EmployeeModel employee)
        {
            return db.DeleteAsync(employee);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SQLite;
using ProjAula.Helpers;
using ProjAula.Models;

namespace ProjAula.Helpers
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelpers(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Estado>().Wait();
        }

        public Task<int> Insert(Estado p) 
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Estado>> Update(Estado p) 
        {
            string sql = "UPDATE Estado SET Nome=?, WHERE Codigo=?";
            return _conn.QueryAsync<Estado>(sql, p.Nome, p.Codigo);
        }

        public Task<int> Delete(int p) 
        {
            return _conn.Table<Estado>().DeleteAsync(i => i.Codigo == p);

            /*
             string sql = "DELETE Estado WHERE Codigo=?";
            _conn.QueryAsync<Estado>(sql, p); 
            feue
             */
        }
         
        public Task<List<Estado>> GetAll() 
        {
            return _conn.Table<Estado>().ToListAsync(); 
        }

        public Task<List<Estado>> Search(string p) 
        {
            string sql = "SELECT * FROM Estado WHERE Nome LIKE '%" + p + "%'";
            return _conn.QueryAsync<Estado>(sql);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain;

namespace Data
{
    public class DbRepository : IDbRepository
    {
        private readonly Setting _setting;

        public class Setting
        {
            public Setting(string connectionString)
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("DbRepository connection string cannot be null or empty string");
                }
                ConnectionString = connectionString;
            }

            public string ConnectionString { get; }
        }

        public DbRepository(Setting setting)
        {
            _setting = setting;
        }

        /// <summary>
        /// todo: implement
        /// </summary>
        /// <returns></returns>
        public Task CreateDatabase()
        {
            using (var connection = new SqlConnection(_setting.ConnectionString))
            {
            }
            throw new NotImplementedException();
        }

        public Task ResetData()
        {
            using (var connection = new SqlConnection(_setting.ConnectionString))
            {
            }
            throw new NotImplementedException();
        }
    }
}

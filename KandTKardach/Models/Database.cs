using System;
using MySql.Data.MySqlClient;

namespace KandTKardach.Models
{
    public abstract class Database
    {
		protected readonly string DB_NAME;
		protected readonly string DB_IP;
		protected readonly string DB_USER;
		protected readonly string DB_PW;
		protected readonly string DB_PORT;
        
		protected MySqlConnection _connection;
      
        protected Database(string db, string serv, string uid, string pw, string port)
        {
			DB_NAME = db;
			DB_IP = serv;
			DB_USER = uid;
			DB_PW = pw;
			DB_PORT = port;

			_connection = new MySqlConnection($"Database={DB_NAME};Server={DB_IP};Port={DB_PORT};Uid={DB_USER};Pwd={DB_PW}");
            try
            {
                _connection.Open();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }
        }
    }
}

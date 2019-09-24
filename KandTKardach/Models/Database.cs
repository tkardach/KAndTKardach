using System;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Threading;

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
        }

        protected Database(bool mock)
        {
            DB_NAME = "MockDB";
            DB_IP = "MockIP";
            DB_USER = "MockUser";
            DB_PW = "MockPW";
            DB_PORT = "MockPort";
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace KandTKardach.Models
{
	public class KAndTDatabase : Database
	{      
		private const string GET_ALL_ALBUMS = "SELECT * FROM album";
		private const string GET_ALL_IMAGES = "SELECT * FROM image";

		private static KAndTDatabase _instance;
		public static KAndTDatabase Instance
        {
            get
            {
                if (_instance == null)
					_instance = new KAndTDatabase();
                return _instance;
            }
        }

        public KAndTDatabase(bool mock) : base(mock)
        {

        }

		public KAndTDatabase() : base("ktkardach", "10.0.0.139", "ktuser", "gingerwaffles", "3306")
        {
			m_albums = new Dictionary<string, Album>();
			_connection.Open();
			try
			{            
                MySqlCommand command = _connection.CreateCommand();
				command.CommandText = GET_ALL_ALBUMS;
				var cursor = command.ExecuteReader();
                // Get all of the albums in the database
				while (cursor.Read())
				{               
                    int id = Convert.ToInt32(cursor["id"]);
                    string name = Convert.ToString(cursor["name"]);
					m_albums.Add(name, new Album(id, name));
				}
				cursor.Close();

                // For each album, add all associated images
				foreach (var album in m_albums.Values)
				{               
					command.CommandText = GET_ALL_IMAGES + $" where album_id = '{album.Id}'";
					cursor = command.ExecuteReader();
                    while (cursor.Read())
					{
                        int id = Convert.ToInt32(cursor["id"]);
						string name = Convert.ToString(cursor["name"]);
						string filename = Convert.ToString(cursor["filename"]);
						album.Images.Add(new Image(id, name, filename));
					}
				}
			}
            catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw e;
			}       
			finally
			{
				_connection.Close();
			}
        }
        
		protected IDictionary<string, Album> m_albums;
		public IDictionary<string, Album> Albums
		{
			get { return m_albums; }
		}
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace KandTKardach.Models
{
	public class KAndTDatabase : Database
	{      
		private const string GET_ALL_ALBUMS = "SELECT * FROM album";
		private const string GET_ALL_IMAGES = "SELECT * FROM image";

        protected bool m_mockMode;

		private static KAndTDatabase _instance;
		public static async Task<KAndTDatabase> GetInstanceAsync()
        {
            if (_instance == null)
            {
                _instance = new KAndTDatabase(Configuration.MockEnabled);
                await _instance.PullFromDatabaseAsync();
            }

            return _instance;
        }

        public static KAndTDatabase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new KAndTDatabase(Configuration.MockEnabled);
                _instance.PullFromDatabase();
            }

            return _instance;
        }

        private KAndTDatabase(bool mock) : base(mock)
        {
            m_mockMode = true;
            m_albums = new Dictionary<string, Album>();
            string serverPath = Configuration.ServerPath;

            m_albums.Add("Wedding", new Album(1, "Wedding", 0));
            m_albums.Add("Baby", new Album(2, "Baby", 1));

            string dirName = serverPath + @"Content\Mock\Images\";
            var files = System.IO.Directory.GetFiles(dirName);
            InitializeMockImages(files);
        }

		private KAndTDatabase() : base("ktkardach", "10.0.0.139", "ktuser", "gingerwaffles", "3306")
        {
            // TODO : If tumbnail does not exist for any given photo, create one
            m_mockMode = false;
            m_albums = new Dictionary<string, Album>();
        }
        
        /// <summary>
        /// Populate the KAndTDatabase objects from the database asynchronously
        /// </summary>
        /// <returns></returns>
        private async Task PullFromDatabaseAsync()
        {
            if (m_mockMode) return;
            try
            {
                await _connection.OpenAsync();

                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = GET_ALL_ALBUMS;
                var cursor = await command.ExecuteReaderAsync();
                // Get all of the albums in the database
                while (await cursor.ReadAsync())
                {
                    int id = Convert.ToInt32(cursor["id"]);
                    int coverId = Convert.ToInt32(cursor["cover_photo_id"]);
                    string name = Convert.ToString(cursor["name"]);
                    m_albums.Add(name, new Album(id, name, coverId));
                }
                cursor.Close();

                // For each album, add all associated images
                foreach (var album in m_albums.Values)
                {
                    command.CommandText = GET_ALL_IMAGES + $" where album_id = '{album.Id}'";
                    cursor = await command.ExecuteReaderAsync();
                    while (await cursor.ReadAsync())
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
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        /// <summary>
        /// Populate the KAndTDatabase objects from the database
        /// </summary>
        /// <returns></returns>
        private void PullFromDatabase()
        {
            if (m_mockMode) return;
            try
            {
                _connection.Open();

                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = GET_ALL_ALBUMS;
                var cursor = command.ExecuteReader();
                // Get all of the albums in the database
                while (cursor.Read())
                {
                    int id = Convert.ToInt32(cursor["id"]);
                    int coverId = Convert.ToInt32(cursor["cover_photo_id"]);
                    string name = Convert.ToString(cursor["name"]);
                    m_albums.Add(name, new Album(id, name, coverId));
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
        
        private void InitializeMockImages(string[] files)
        {
            foreach (var album in m_albums.Values)
            {
                int id = 0;
                foreach (var file in files)
                {
                    var thmbUrl = @"\Content\Mock\Thumbnails\" + Path.GetFileName(file);
                    var url = @"\Content\Mock\Images\" + Path.GetFileName(file);
                    album.Images.Add(new Models.Image(id++, Path.GetFileName(file), url, thmbUrl));
                }
            }
        }
    }
}

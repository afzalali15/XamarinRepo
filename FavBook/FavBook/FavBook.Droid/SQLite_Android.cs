using System;
using System.IO;
using FavBook.Droid;
using Xamarin.Forms;
using System.Diagnostics;
using SQLite;

[assembly: Dependency (typeof (SQLite_Android))]
namespace FavBook.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection (string dbName = "favbook")
        {
            try {
                var sqliteFilename = dbName + ".db3";
                string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine (documentsPath, sqliteFilename);

                // Create the connection
                var conn = new SQLiteConnection (path);

                // Create tables
                conn.CreateTable<Book> ();

                // Return the database connection
                return conn;
            } catch (Exception ex) {
                Debug.WriteLine ("Exception :" + ex.Message);
                return null;
            }
        }
    }
}


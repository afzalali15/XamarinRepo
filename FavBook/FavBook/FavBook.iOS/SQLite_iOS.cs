using System.IO;
using Xamarin.Forms;
using FavBook.iOS;
using SQLite;
using System;
using System.Diagnostics;

[assembly: Dependency (typeof (SQLite_iOS))]
namespace FavBook.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection (string dbName = "favbook")
        {
            try {
                var sqliteFilename = dbName + ".db3";
                string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine (libraryPath, sqliteFilename);

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


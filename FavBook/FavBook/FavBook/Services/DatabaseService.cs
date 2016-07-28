using System;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace FavBook
{
    public class DatabaseService
    {
        public static SQLite.SQLiteConnection db;
        public DatabaseService ()
        {
            db = DependencyService.Get<ISQLite> ().GetConnection ();
        }

        public void AddToCart (Book book)
        {
            db.Insert (book);
        }

        public void RemoveFromCart (Book book)
        {
            db.Delete (book);
        }

        public bool IsPresentInCart (Book book)
        {
            var bk = from b in db.Table<Book> ()
                     where b.isbn.Equals (book.isbn)
                     select b;

            if (bk.Count () > 0)
                return true;

            return false;
        }

        public List<Book> GetBooks ()
        {
            return db.Table<Book> ().ToList ();
        }
    }
}


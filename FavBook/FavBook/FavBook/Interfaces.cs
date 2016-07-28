using System;
using SQLite;

namespace FavBook
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection (string dbName = "favbook");
    }
}



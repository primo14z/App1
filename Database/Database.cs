using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using System.IO;

namespace App1.Database
{
    class Database
    {
        public static void Create()
        {
            var sqlpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath);

            conn.CreateTable<Stranka>();
            conn.CreateTable<Nalog>();
            conn.CreateTable<Opravilo>();


        }
    }
}

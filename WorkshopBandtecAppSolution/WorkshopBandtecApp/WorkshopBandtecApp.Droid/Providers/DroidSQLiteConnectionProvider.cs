using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using WorkshopBandtecApp.Droid.Providers;
using WorkshopBandtecApp.Providers;

[assembly: Xamarin.Forms.Dependency(typeof(DroidSQLiteConnectionProvider))]

namespace WorkshopBandtecApp.Droid.Providers
{
    class DroidSQLiteConnectionProvider : ISQLiteConnectionProvider
    {
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(
                new SQLitePlatformAndroid(),
                Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Banco.db3"));
        }
    }
}
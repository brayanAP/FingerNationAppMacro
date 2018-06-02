
using System.IO;

using FingerNationAppMacro.Droid.Services;
using Xamarin.Forms;
using FingerNationAppMacro.interfaces;

[assembly: Dependency(typeof(PathServiceSqlite))]
namespace FingerNationAppMacro.Droid.Services
{
    public class PathServiceSqlite : IPathServiceSqlite
    {
        public string GetDatabasePath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.DatabaseName);
        }
    }
}
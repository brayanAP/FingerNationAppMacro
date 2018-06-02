using FingerNationAppMacro.interfaces;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using FingerNationAppMacro.UWP.Services;

[assembly: Dependency(typeof(PathServiceSqlite))]
namespace FingerNationAppMacro.UWP.Services
{
    public class PathServiceSqlite : IPathServiceSqlite
    {
        public string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.DatabaseName);
        }
    }
}

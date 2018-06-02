using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FingerNationAppMacro.interfaces;
using FingerNationAppMacro.iOS.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathServiceSqlite))]
namespace FingerNationAppMacro.iOS.Services
{
    public class PathServiceSqlite : IPathServiceSqlite
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppSettings.DatabaseName);
        }
    }
}
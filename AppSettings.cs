using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro
{
    internal class AppSettings
    {
        private static string DataBaseName = "database.db";
        private static string DataBaseDirectory = FileSystem.AppDataDirectory;
        public static string DataBasePath = Path.Combine(DataBaseDirectory, DataBaseName);
    }
}

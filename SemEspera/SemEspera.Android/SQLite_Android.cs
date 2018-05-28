using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SemEspera.Data;
using SQLite;
using SemEspera.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace SemEspera.Droid
{
    public class SQLite_Android : ISqlite
    {

        private const string NomeArquivoDb = "SemEspera.db3";
        public SQLiteConnection GetConexao()
        {
           var CaminhoDb = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path,NomeArquivoDb);
            return new SQLite.SQLiteConnection(CaminhoDb);
        }
    }
}
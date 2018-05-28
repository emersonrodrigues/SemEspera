using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Data
{
    public interface ISqlite
    {
        SQLiteConnection GetConexao();
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SemEspera.Models
{
    public  class ProdutoBase
    {
        [PrimaryKey, AutoIncrement]
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public string Image { get; set; }
        public double Valor { get; set; }
        public string ValorMoeda
        {
            get
            {
                return string.Format("R$ {0}", Valor);

            }
            set { }
        }

      

      
     
    }
}


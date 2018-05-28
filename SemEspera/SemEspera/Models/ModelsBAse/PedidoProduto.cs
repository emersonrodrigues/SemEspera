using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models.ModelsBAse
{
    public class PedidoProduto
    {
        [PrimaryKey, AutoIncrement]
        public int PedidoProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models.ModelsBAse
{
    public class PedidoProdutoIngrediente
    {
        [PrimaryKey, AutoIncrement]
        public int PedidoProdutoIngredienteId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int IngredienteID { get; set; }
        public int Quantidade { get; set; }

        public PedidoProdutoIngrediente()
        {

        }
        public PedidoProdutoIngrediente(int pedidoId, int produtoId, int ingredienteID, int quantidade)
        {
            this.PedidoId = pedidoId;
            this.ProdutoId = produtoId;
            this.IngredienteID = ingredienteID;
            this.Quantidade = quantidade;
        }
    }
}

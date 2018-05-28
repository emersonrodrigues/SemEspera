using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models.ModelsBAse
{
    public class ProdutoIngrediente
    {
        [PrimaryKey, AutoIncrement]
        public int ProdutoIngredienteId { get; set; }
        public int ProdutoId { get; set; }
        public int IngredienteID { get; set; }
        public ProdutoIngrediente(int produtoId,int ingredienteId)
        {
            this.ProdutoId = produtoId;
            this.IngredienteID = ingredienteId;
        }
        public ProdutoIngrediente()
        {

        }
    }
}

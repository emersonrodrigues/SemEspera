using SemEspera.Models;
using SemEspera.Models.ModelsBAse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Data
{
    public class IngredienteDAO
    {
        private readonly SQLiteConnection Conexao;
        public IngredienteDAO(SQLiteConnection conexao)
        {
            this.Conexao = conexao;
            this.Conexao.CreateTable<Ingrediente>();
        }
        public List<Ingrediente> ListIngredientesByProdutoIngrediente(List<ProdutoIngrediente> ProdutoIngredientes)
        {
            var Ingredientes = new List<Ingrediente>();
            foreach (var pi in ProdutoIngredientes)
            {
                Ingredientes.Add(Conexao.Find<Ingrediente>(pi.IngredienteID));
            }
            return Ingredientes;
        }
    }
}

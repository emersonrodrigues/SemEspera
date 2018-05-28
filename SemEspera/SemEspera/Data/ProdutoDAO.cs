using SemEspera.Models;
using SemEspera.Models.ModelsBAse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Data
{
    public class ProdutoDAO
    {
        private readonly SQLiteConnection Conexao;
        public ProdutoDAO(SQLiteConnection conexao)
        {
            this.Conexao = conexao;  
            this.Conexao.CreateTable<ProdutoBase>();
            this.Conexao.CreateTable<ProdutoIngrediente>();     
        }
        public List<ProdutoBase> ListProdutosBase()
        {

            var lista = new List<ProdutoBase>();
            lista = new List<ProdutoBase>(Conexao.Table<ProdutoBase>());

            return lista;
        }
        public List<Ingrediente> ProdutosIngredientes(int ProdutoID)
        {

            var produtosIngredientes = new List<ProdutoIngrediente>(Conexao.Table<ProdutoIngrediente>());
            var IngredientesIds = new List<ProdutoIngrediente>(from i in Conexao.Table<ProdutoIngrediente>() where i.ProdutoId == ProdutoID select i);
            var Ingredientesdao = new IngredienteDAO(Conexao);

            return Ingredientesdao.ListIngredientesByProdutoIngrediente(IngredientesIds);
        }

    }
}

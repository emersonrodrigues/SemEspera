using SemEspera.Models;
using SemEspera.Models.ModelsBAse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SemEspera.Data
{
    public class PedidoDao 
    {
        private  Pedido Pedido { get; set; }
        public SQLiteConnection Conexao { get; set; }
        public PedidoDao(SQLiteConnection conexao, Pedido pedido)
        {
            this.Conexao = conexao;
            this.Pedido = pedido;
            Tables();

        }
        public PedidoDao(SQLiteConnection conexao)
        {
            this.Conexao = conexao;
            Tables();

        }

        private void Tables()
        {
            this.Conexao.CreateTable<PedidoBase>();
            this.Conexao.CreateTable<PedidoProduto>();
            this.Conexao.CreateTable<PedidoProdutoIngrediente>();
        }


        public void Salvar()
        {

            var TablePedidoBase = Conexao.Table<PedidoBase>();
          
            var TablePedidoProdutoIngrediente = Conexao.Table<PedidoProdutoIngrediente>();



            if (Conexao.Find<PedidoBase>(Pedido.PedidoBase.Id) == null) 
            {
                Conexao.Insert(Pedido.PedidoBase);
                InsertPedidoProdutoIngredientes();
            }
            else
            {
                Conexao.Update(Pedido.PedidoBase);
            }




        }
        private void InsertPedidoProdutos(ObservableCollection<ProdutoJson> pps)
        {
            var TablePedidoProduto = Conexao.Table<PedidoProduto>();
            foreach (var pp in pps)
            {
                Conexao.Insert(pp);
            }

        }

        private void InsertPedidoProdutoIngredientes()
        {
            var pb = GetLastItemInsert();
            var TablePedidoProduto = Conexao.Table<PedidoProdutoIngrediente>();
            foreach (var PJ in Pedido.ProdutosAlterados)
            {
                foreach (var ingrediente in PJ.IngredientesAlterados)
                {
                    Conexao.Insert(new PedidoProdutoIngrediente(pb.Id, PJ.ProdutoId, ingrediente.Key,ingrediente.Value));
                }
               
            }

        }


        public List<PedidoBase> GetPEdidosSalvos()
        {
           
            var lista = new List<PedidoBase>();
            lista = new List<PedidoBase>(Conexao.Table<PedidoBase>());
            if (lista == null)
            {
                return new List<PedidoBase>();
            }
            return lista;
        }
        public PedidoBase GetLastItemInsert()
        {

            //var query = "select * from Pedidos where PedidoID = max(PedidoID)";
            //var comand = Conexao.CreateCommand(query);
            
           
            var result = Conexao.FindWithQuery<PedidoBase>("SELECT LAST_INSERT_ROWID() AS ID");
            return result;
        }


    }
}

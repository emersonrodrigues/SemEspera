using SemEspera.Models.ModelsBAse;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace SemEspera.Models
{
    public class Pedido 
    {
        public int PedidoID { get { return PedidoBase.Id; } }
        public DateTime DataPedido { get { return PedidoBase.DataPedido; } set { PedidoBase.DataPedido = value; } }
        public int UserId { get { return PedidoBase.UserId; } set { PedidoBase.UserId = value; } }
        public string DataEditada { get { return PedidoBase.DataEditada; } }
        public PedidoBase PedidoBase { get; set; }
        public ObservableCollection<ProdutoJson> ProdutosAlterados { get; set; }

        public Pedido(PedidoBase pedidoBase, ObservableCollection<ProdutoJson> produtos)
        {
            this.PedidoBase = pedidoBase;
            this.ProdutosAlterados = produtos;
            ProdutosAlterados = new ObservableCollection<ProdutoJson>();
          
        }
        //public Pedido(ObservableCollection<ProdutoJson> produtos, User user)
        //{
        //    this.Produtos = produtos;
        //    this.DataPedido = DateTime.Now;
        //}
        public Pedido()
        {
            ProdutosAlterados = new ObservableCollection<ProdutoJson>();
         }
    
    }
}

using SemEspera.Models;
using SemEspera.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    class ListaProdutosViewModel
    {
        public List<ProdutoBase> Produtos { get; set; }
        //public List<ProdutoBase> Produtosnase { get; set; }
        public Pedido Pedido { get; set; }
        ProdutoBase produtoSelecionado;
        public ProdutoBase ProdutoSelecionado {
            get
            {
                return produtoSelecionado;
            }
            set
            {
                produtoSelecionado = value;
                if (produtoSelecionado != null)
                {
                    
                    MessagingCenter.Send(produtoSelecionado, "ProdutoSelecionado");
                }
                

            } }

        public ListaProdutosViewModel()
        {
            using (var conexao = DependencyService.Get<Data.ISqlite>().GetConexao())
            {
                
                this.Produtos = new List<ProdutoBase>(conexao.Table<ProdutoBase>());
            }

        }
        //public ListaProdutosViewModel(Pedido pedido)
        //{
        //    this.Pedido = pedido;
        //    var mock = new Mock();
        //    this.Produtos = mock.MockProdutos();
        //}
    }
}

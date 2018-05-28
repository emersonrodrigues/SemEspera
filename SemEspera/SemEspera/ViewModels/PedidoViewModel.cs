using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using SemEspera.Data;
using SemEspera.Helpers;
using SemEspera.Models;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public class PedidoViewModel : BaseViewModel
    {
        private static ObservableCollection<Produto> Produtos { get; set; }
        public ObservableCollection<Produto> ProdutosView { get { return Produtos; } }
        public Pedido Pedido { get; set; }
        public ICommand AdicionaProdutos { get; set; }
        public ICommand FinalizarPedido { get; set; }
        public ICommand RemoverProduto { get; set; }
        private Double valorTotal { get; set; }
        public Double ValorToral
        {
            get { return valorTotal; }
            set
            {
                valorTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorToral));
            }
        }


        private double ValorToralCalc()
        {
            ValorToral = 0.0;
            foreach (var produto in Produtos)
            {
                ValorToral += produto.Valor;
            }

            return ValorToral;

        }


        public PedidoViewModel(Produto _produto)
        {

            if (Produtos == null) { Produtos = new ObservableCollection<Produto>(); }
            //if (Pedido == null) { Pedido = new Pedido(); } 

            //Pedido.Produtos.Add(_produto);
            Produtos.Add(_produto);

            ValorToralCalc();



            AdicionaProdutos = new Command(() =>
            {

                MessagingCenter.Send(new Pedido(), "NovoPedido");
            });

            FinalizarPedido = new Command(() =>
            {
                MontarPedido();
                Produtos = new ObservableCollection<Produto>();
                if (SalvarPedido())
                {
                    MessagingCenter.Send(Pedido, "FinalizarPedido");
                }

            });
            RemoverProduto = new Command(
           (item) =>
           {
               var ProdutoItem = ((Produto)item);
               Produtos.Remove(ProdutoItem);
               //Pedido.Produtos.Remove(new ProdutoJson() {ProdutoId = ProdutoItem.ProdutoID,  });
               ValorToralCalc();
               if (Produtos.Count == 0)
               {
                   MessagingCenter.Send(new Pedido(), "NovoPedido");
               }
               OnPropertyChanged();
               OnPropertyChanged(nameof(Produto.Ingredientes));
           });
        }

        private void MontarPedido()
        {
            var ProdutosJson = new ObservableCollection<ProdutoJson>();
            foreach (var item in Produtos)
            {
                ProdutosJson.Add(new ProdutoJson()
                {
                    ProdutoId = item.ProdutoID
                    ,
                    IngredientesAlterados = item.IngredientesAlterados
                });
            }
            this.Pedido = new Pedido(new PedidoBase(LoginViewModel.usuario.Id,DateTime.Now), ProdutosJson);
        }
        public bool SalvarPedido()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                if (this.Pedido != null)
                {
                    var DAO = new PedidoDao(conexao,Pedido);

               
                    DAO.Salvar();
                    return true;
                }
                return false;
            }
        }
    }
}

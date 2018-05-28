using SemEspera.Data;
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    class ListaIngreditentesViewModel:BaseViewModel

    {
       
        public Produto Produto { get; set; }

        public ICommand AdicionaAoPedido { get; set; }
        public ICommand AdicionaQuantidade { get; set; }
        public ICommand RemoverQuantidade { get; set; }
        private ObservableCollection<Ingrediente> ingredientes { get; set; }
        public ObservableCollection<Ingrediente> Ingredientes
        {
            get{ return ingredientes; }
            set { ingredientes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ingredientes));
            } }
        public Dictionary<int, int> IngredientesAlterados { get; set; }
        

Ingrediente ingredienteSelecionado;
        public Ingrediente IngredienteSelecionado
        {
            get
            {
                return ingredienteSelecionado;
            }
            set
            {
                ingredienteSelecionado = value;
                if (ingredienteSelecionado != null)
                {
                    //MessagingCenter.Send(ingredienteSelecionado, "IngredienteSelecionado");
                }

            }
        }
        public ListaIngreditentesViewModel(ProdutoBase _produto)
        {
            IngredientesAlterados = new Dictionary<int, int>();
            this.Produto = new Produto(_produto);

            GetIngredientes();

            AdicionaAoPedido = new Command(() => {
                this.Produto.Ingredientes = Ingredientes;
                this.Produto.IngredientesAlterados = IngredientesAlterados;
                MessagingCenter.Send(Produto, "AdicionaAoPedido");
            });
            AdicionaQuantidade = new Command(
                        (item) =>
                        {
                            var IngredienteItem = ((Ingrediente)item);
                            var index =  Ingredientes.IndexOf(IngredienteItem);
                            IngredienteItem.Quantidade += 1;
                            Ingredientes[index]= IngredienteItem;
                            SetIngredienteAlterado(IngredienteItem);
                           
                            OnPropertyChanged();
                            OnPropertyChanged(nameof(Ingredientes));
                        });
            RemoverQuantidade = new Command(
            (item) =>
            {
                var IngredienteItem = ((Ingrediente)item);
                var index = Ingredientes.IndexOf(IngredienteItem);
                IngredienteItem.Quantidade -= 1;
                Ingredientes[index] = IngredienteItem;
                SetIngredienteAlterado(IngredienteItem);
                
                if (IngredienteItem.Quantidade <=0)
                {
                    
                    Ingredientes.RemoveAt(index);
                    SetIngredienteAlterado(IngredienteItem);
                    //IngredientesAlterados.Remove(IngredienteItem.IngredienteID);
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(ingredientes));
            });

        }
        public void SetIngredienteAlterado(Ingrediente ingrediente)
        {
            if (!IngredientesAlterados.ContainsKey(ingrediente.IngredienteID) && ingrediente.Quantidade >=0)
            {
                IngredientesAlterados.Add(ingrediente.IngredienteID, ingrediente.Quantidade);
            }
            if (IngredientesAlterados.ContainsKey(ingrediente.IngredienteID)&& ingrediente.Quantidade >= 0)
            {
                IngredientesAlterados.Remove(ingrediente.IngredienteID);
                IngredientesAlterados.Add(ingrediente.IngredienteID, ingrediente.Quantidade);
            }
        }
        public void GetIngredientes()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var DAO = new ProdutoDAO(conexao);
                Ingredientes =new ObservableCollection<Ingrediente>( DAO.ProdutosIngredientes(Produto.ProdutoID));
            }
            }
    }
}

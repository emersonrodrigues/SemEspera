using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemEspera.Models;
using SemEspera.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SemEspera.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaIngredientesView : ContentPage
    {
        public ProdutoBase Produto { get; set; }
        public ListaIngredientesView(ProdutoBase produto)
        {
            InitializeComponent();
            this.Produto = produto;
            this.BindingContext = new ListaIngreditentesViewModel(produto);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListViewIngredientes.SelectedItem = null;
            MessagingCenter.Subscribe<Ingrediente>(this, "IngredienteSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new IngredienteView(msg));
                });


        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ingrediente>(this, "IngredienteSelecionado");
            //MessagingCenter.Unsubscribe<Produto>(this, "AdicionaAoPedido");
        }

    }
}
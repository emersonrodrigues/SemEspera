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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutosView : ContentPage
    {
        
        public ListaProdutosView( )
        {
            InitializeComponent();

            this.BindingContext = new ListaProdutosViewModel();
        }

        protected override void OnAppearing()
        {
            ListViewProdutos.SelectedItem = null;
            base.OnAppearing();
            MessagingCenter.Subscribe<ProdutoBase>(this, "ProdutoSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new ListaIngredientesView(msg));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Produto>(this, "ProdutoSelecionado");
        }
    }
}
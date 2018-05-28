using SemEspera.Models;
using SemEspera.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SemEspera.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PedidoView : ContentPage
	{
        public Produto produto { get; set; }
        public PedidoView (Produto _produto)
        {
			InitializeComponent ();
            this.produto = _produto;
            this.BindingContext = new PedidoViewModel(produto);

            
            //LabelAP.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnLabelClicked()), });
        }
        
        protected override void OnAppearing()
        {
        

            base.OnAppearing();
            MessagingCenter.Subscribe<List<Produto>>(this, "AdicionaProdutos",
                (msg) =>
                {
                    Navigation.PushAsync(new ListaProdutosView());
                });



            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<List<Produto>>(this, "AdicionaProdutos");
            //MessagingCenter.Unsubscribe<string>(this, "FinalizarPedido");




        }
    }
}
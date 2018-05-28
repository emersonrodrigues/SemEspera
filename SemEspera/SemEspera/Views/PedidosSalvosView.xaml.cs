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
	public partial class PedidosSalvosView : ContentPage
	{
		public PedidosSalvosView ()
		{
			InitializeComponent ();
            this.BindingContext = new PedidosSalvosViewModel();
		}
        protected override void OnAppearing()
        {
         
            MessagingCenter.Subscribe<Pedido>(this, "NovoPedido",
                (msg) =>
                {
                    Navigation.PushAsync(new ListaProdutosView());
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Pedido>(this, "NovoPedido");
        }
    }
}
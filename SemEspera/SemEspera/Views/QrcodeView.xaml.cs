using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemEspera.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;


namespace SemEspera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrcodeView : ContentPage
    {
        public QrcodeViewModel viewModel { get; set; }
        public QrcodeView(Pedido Pedido)
        {
            InitializeComponent();
            viewModel = new QrcodeViewModel(Pedido);
            this.BindingContext = viewModel;
            stack.Children.Add(viewModel.BuiltQrcode());

            var SalvarPedido = new Label() { Text = "Salvar Pedido", FontSize = 10, HorizontalOptions = LayoutOptions.CenterAndExpand };
            SalvarPedido.GestureRecognizers.Add(new TapGestureRecognizer() { Command = viewModel.DescartarPedido });
            stack.Children.Add(SalvarPedido);

            var DescartarPedido = new Label() { Text = "Descartar Pedido", FontSize = 10, HorizontalOptions = LayoutOptions.CenterAndExpand };
            DescartarPedido.GestureRecognizers.Add(new TapGestureRecognizer() { Command = viewModel.DescartarPedido });

            stack.Children.Add(SalvarPedido);
            stack.Children.Add(DescartarPedido);

        }
    }
}
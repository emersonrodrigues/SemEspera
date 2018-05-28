using SemEspera.Data;
using SemEspera.Helpers;
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace SemEspera.ViewModels
{
    public class QrcodeViewModel
    {
        private Pedido Pedido { get; set; }
        private string PedidoJson { get { return JsonSerialize.Serialize<Pedido>(Pedido); } }

        public ICommand SalvarPedido { get; set; }
        public ICommand DescartarPedido { get; set; }


        public QrcodeViewModel(Pedido pedido)
        {
            this.Pedido = pedido;
            var teste = GetUltimoPedido();
            SalvarPedido = new Command(() =>
            {
                MessagingCenter.Send<User>(new User(), "SalvarPedido");
            });

            DescartarPedido = new Command(() =>
            {
                MessagingCenter.Send<User>(new User(), "DescartarPedido");
            });
        }



        public ZXingBarcodeImageView BuiltQrcode()
        {

            var QrCode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

                AutomationId = "ZXingBarcodeImageView",
                Margin = new Thickness(10),
                BarcodeFormat = ZXing.BarcodeFormat.QR_CODE,
            };




            QrCode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            QrCode.BarcodeOptions.Width = 400;
            QrCode.BarcodeOptions.Height = 400;
            QrCode.BarcodeOptions.Margin = 0;
            QrCode.BarcodeValue = PedidoJson;
            return QrCode;
        }
        public PedidoBase GetUltimoPedido()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var DAO = new PedidoDao(conexao,Pedido);

                return DAO.GetLastItemInsert();
            }


        }
    }
}
using SemEspera.Data;
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public class PedidosSalvosViewModel
    {
        public ICommand FazerPedidoCommand { get; set; }
        public List<PedidoBase> PedidosSalvos { get; set; }
        public PedidosSalvosViewModel()
        {
            PedidosSalvos = new List<PedidoBase>();
            GetPedidosSalvos();
            FazerPedidoCommand = new Command(()=> 
            {
            MessagingCenter.Send(new Pedido(), "NovoPedido");
            });
           
        }

        private void GetPedidosSalvos()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var DAO = new PedidoDao(conexao);

                 PedidosSalvos = DAO.GetPEdidosSalvos();
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SemEspera.Data;
using SemEspera.Mocks;
using SemEspera.Models;
using SemEspera.Views;
using Xamarin.Forms;

namespace SemEspera
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new LoginView();

        }
        
        protected override void OnStart ()
		{
            MessagingCenter.Subscribe<User>(this, "LoginPositivo",(msg) => { MainPage = new MasterDetailView(msg); });
            MessagingCenter.Subscribe<User>(this, "CadastrarPerfil", (msg) => { MainPage = new PerfilCadastroView(); });
            MessagingCenter.Subscribe<Pedido>(this, "NovoPedido", (msg) => { MainPage = new NavigationPage(new ListaProdutosView()); });
            MessagingCenter.Subscribe<Produto>(this, "AdicionaAoPedido",(msg) =>{ MainPage = new PedidoView(msg);});
            MessagingCenter.Subscribe<Pedido>(this, "FinalizarPedido",(msg) =>{ MainPage = new QrcodeView(msg);});
            MessagingCenter.Subscribe<User>(this, "SalvarPedido", (msg) => { MainPage = new  MasterDetailView(msg); });
            MessagingCenter.Subscribe<User>(this, "DescartarPedido", (msg) => { MainPage = new  MasterDetailView(msg); });
            new Mock();
            //CreateTables();
            //var mock = new Mock();
            //mock.PreencherIngredientes();
            //mock.PreencherProdutos();
            //PreencherProdutoIngrediente()

            // Handle when your app starts
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        public void CreateTables()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                new CreateTables(conexao);
            }
        }
	}
}

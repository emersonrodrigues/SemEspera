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
	public partial class MasterDetailView : MasterDetailPage
	{
        private readonly User usuario;
		public MasterDetailView (User usuario)
		{
			InitializeComponent ();
            this.usuario = usuario;
            this.Master = new PerfilView(usuario);
            this.Detail = new PedidosSalvosView();
        }
	}
}
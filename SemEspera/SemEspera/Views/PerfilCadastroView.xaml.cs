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
	public partial class PerfilCadastroView : ContentPage
	{
        public PerfilCadastroViewModel viewModel { get; set; }
        public PerfilCadastroView ()
		{
            viewModel = new PerfilCadastroViewModel();
            InitializeComponent ();
           
            this.BindingContext = viewModel;
          
        }
    }
}
	
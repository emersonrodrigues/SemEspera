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
	public partial class PerfilView : ContentPage
    {
        public PerfilViewModel ViewModel { get; set; }
        public PerfilView (User usuario)
		{
			InitializeComponent ();
            ViewModel = new PerfilViewModel(usuario);
            this.BindingContext = ViewModel;

        }
	}
}
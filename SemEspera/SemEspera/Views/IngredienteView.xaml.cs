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
	public partial class IngredienteView : ContentPage
	{
        
        public IngredienteView ( Ingrediente ingrediente)
		{
			InitializeComponent ();
            
            this.BindingContext = new IngredienteViewModel(ingrediente);
		}
	}
}
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public  class IngredienteViewModel : BaseViewModel
    {
        public ICommand AdicionaQuantidade { get; set; }
        public ICommand RemoverQuantidade { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public int IngredienteQuantidade
        {
            get
            {
                return Ingrediente.Quantidade;
            }
            set
            {
                Ingrediente.Quantidade = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Quantidade));

            }
        }
        public double Quantidade { get { return Ingrediente.Quantidade; } }
        public IngredienteViewModel(Ingrediente ingrediente)
        {
            this.Ingrediente = ingrediente;
            AdicionaQuantidade = new Command(
                () =>
                {
                    this.IngredienteQuantidade += 1;
                });
            RemoverQuantidade = new Command(
            () =>
            {
                this.IngredienteQuantidade -= 1;


            });

        }

    }
}

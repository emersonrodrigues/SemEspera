using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
     public class Ingrediente
    {
        public int IngredienteID { get; set; }
        public string NomeIngrediente { get; set; }
        public string Image { get; set; }
        public double Valor { get; set; }

        public Ingrediente(string nomeIngrediente,double valor)
        {
            this.NomeIngrediente = nomeIngrediente;
            this.Valor = valor; 
        }
    }
}

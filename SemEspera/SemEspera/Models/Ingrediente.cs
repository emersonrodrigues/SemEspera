using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models
{
     public class Ingrediente
    {
        [PrimaryKey, AutoIncrement]
        public int IngredienteID { get; set; }
        public string NomeIngrediente { get; set; }
        public string Image { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public Ingrediente()
        {

        }
        public Ingrediente(string nomeIngrediente, double valor, string image, int quantidade)
        {
           
            this.NomeIngrediente = nomeIngrediente;
            this.Image = image;
            this.Valor = valor;
            this.Quantidade = quantidade;
        }
    }
}

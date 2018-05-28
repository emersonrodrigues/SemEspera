using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string Image { get; set; }
        public double Valor { get; set; }

        public Produto(string nomeProduto,double valor, List<Ingrediente> ingredientes)
        {
            this.NomeProduto = nomeProduto;
            this.Valor = valor;
            this.Ingredientes = ingredientes;
        }
    }
}

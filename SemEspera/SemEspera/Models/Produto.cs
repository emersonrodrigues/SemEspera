using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SemEspera.Models
{
    public class Produto : ProdutoBase
    {
        public ObservableCollection<Ingrediente> Ingredientes { get; set; }
        public Dictionary<int,int> IngredientesAlterados { get; set; }

        public Produto( ProdutoBase produto)
        {
            this.ProdutoID = produto.ProdutoID;
            this.NomeProduto = produto.NomeProduto;
            this.Image = produto.Image;
            this.Valor = produto.Valor;

        }

        //public Produto(string nomeProduto,double valor, ObservableCollection<Ingrediente> ingredientes)
        //{
        //    this.NomeProduto = nomeProduto;
        //    this.Valor = valor;
        //    this.Ingredientes = ingredientes;
        //}

        public Produto(int produtoID, string nomeProduto, double valor, string image, ObservableCollection<Ingrediente> ingredientes)
        {
            IngredientesAlterados = new Dictionary<int, int>();
            Ingredientes = new ObservableCollection<Ingrediente>();

            this.ProdutoID = produtoID;
            this.NomeProduto = nomeProduto;
            this.Ingredientes = ingredientes;
            this.Image = image;
            this.Valor = valor;


           
        }
        public void SetIngredienteAlterado(Ingrediente ingrediente)
        {
            if (!IngredientesAlterados.ContainsKey(ingrediente.IngredienteID)&& ingrediente.Quantidade >0)
            {
                IngredientesAlterados.Add(ingrediente.IngredienteID,ingrediente.Quantidade);
            }
        }
    }
}

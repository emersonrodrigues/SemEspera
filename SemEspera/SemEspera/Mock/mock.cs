using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SemEspera.Data;
using SemEspera.Models;
using SemEspera.Models.ModelsBAse;
using Xamarin.Forms;

namespace SemEspera.Mocks
{
    public class Mock
    {

        private ObservableCollection<Ingrediente> Ingredientes { get; set; }
        private List<Produto> Produtos { get; set; }
        public Mock()
        {
            PreencherIngredientes();
            PreencherProdutos();
            PreencherProdutoIngrediente();
        }
        public ObservableCollection<Ingrediente> MockIngredientes()
        {
            ObservableCollection<Ingrediente> IngredienteList = new ObservableCollection<Ingrediente>();
            IngredienteList.Add(new Ingrediente( "Alface", 0.5, "vazio", 1));
            IngredienteList.Add(new Ingrediente( "Pão", 1.0, "vazio", 2));
            IngredienteList.Add(new Ingrediente( "Hamburger", 2.0, "vazio", 1));
            IngredienteList.Add(new Ingrediente( "Picles", 1.0, "vazio", 1));
            IngredienteList.Add(new Ingrediente( "Tomate", 0.75, "vazio", 1));
            IngredienteList.Add(new Ingrediente( "Molho", 1.5, "vazio", 1));
            //Ingredientes = IngredienteList;
            return IngredienteList;
        }
        public List<Produto> MockProdutos()
        {
            var produtoList = new List<Produto>();
            //produtoList.Add(new Produto(0,  "Big Mac", 20, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(1,  "Big Tasty", 22.5, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(2,  "Quarteirão", 29.0, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(3,  "Ticken Jr.", 5.30, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(4,  "Wooper", 30.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(5, "Hamburger 1", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(6, "Hamburger 2", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(7, "Hamburger 3", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(8, "Hamburger 4", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(9, "Hamburger 5", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(10, "Hamburger 6", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(11, "Hamburger 7", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(12, "Hamburger 8", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(13, "Hamburger 9", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(14, "Hamburger 10", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(15, "Hamburger 11", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(16, "Hamburger 12", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(17, "Hamburger 13", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(18, "Hamburger 14", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(19, "Hamburger 15", 41.5, "vazio", MockIngredientes()));
            produtoList.Add(new Produto(20, "Hamburger 16", 41.5, "vazio", MockIngredientes()));

            Produtos = produtoList;
            return produtoList;
        }

        public List<ProdutoBase> MockProdutosBase()
        {
            var produtoList = new List<ProdutoBase>();
            //produtoList.Add(new Produto(0,  "Big Mac", 20, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(1,  "Big Tasty", 22.5, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(2,  "Quarteirão", 29.0, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(3,  "Ticken Jr.", 5.30, "vazio", MockIngredientes()));
            //produtoList.Add(new Produto(4,  "Wooper", 30.5, "vazio", MockIngredientes()));
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 1", Valor = 41.5, Image = "vazio" });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 2", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 3", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 4", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 5", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 6", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 7", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 8", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 9", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 10", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 11", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 12", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 13", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 14", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 15", Valor = 41.5, Image = "vazio", });
            produtoList.Add(new ProdutoBase() { NomeProduto = "Hamburger 16", Valor = 41.5, Image = "vazio", });


            return produtoList;
        }
        public void PreencherProdutos()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var Dao = new ProdutoDAO(conexao);
                
               
                if (Dao.ListProdutosBase().Count == 0)
                {
                    conexao.InsertAll(MockProdutosBase());


                }
            }
        }
        public void PreencherIngredientes()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var Dao = new IngredienteDAO(conexao);
                var t = conexao.Table<Ingrediente>().Count();

                if (conexao.Table<Ingrediente>().Count() == 0)
                {
                    conexao.InsertAll(MockIngredientes());
                }
            }
        }
        public void PreencherProdutoIngrediente()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {

                if (conexao.Table<ProdutoIngrediente>().Count() ==0)
                {
                    var Dao = new ProdutoDAO(conexao);
                   var produtos =  Dao.ListProdutosBase();

                    foreach (var produto in produtos)
                    {
                        var ingredientes = new List<Ingrediente>(conexao.Table<Ingrediente>());
                        foreach (var Ingrediente in ingredientes)
                        {
                            conexao.Insert(new ProdutoIngrediente(produto.ProdutoID,Ingrediente.IngredienteID));
                        }
                    }
                }
                


                var t = conexao.Table<Ingrediente>().Count();

                if (conexao.Table<Ingrediente>().Count() == 0)
                {
                    conexao.InsertAll(MockIngredientes());
                }
            }
        }
    }
}

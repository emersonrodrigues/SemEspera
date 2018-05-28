using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Data
{
    public class CreateTables
    {
        public SQLiteConnection Conexao { get; set; }
        public CreateTables(SQLiteConnection conexao)
        {
            this.Conexao = conexao;

            var Tables = new List<string>();
            //Tables.Add("CREATE TABLE IF NOT EXISTS Ingredientes (IngredienteID int,NomeIngrediente Varchar(250),Image varchar(251),Valor decimal(18,2),Quantidade int,PRIMARY KEY (IngredienteID))");
            //Tables.Add("CREATE TABLE IF NOT EXISTS Produtos (ProdutoID int,NomeProduto Varchar(250),Image varchar(251),Valor decimal(18,2),PRIMARY KEY (ProdutoID))");
            //Tables.Add("CREATE TABLE IF NOT EXISTS IngredientesProdutos (IngredientesProdutosID int,ProdutoID int,IngredienteID int ,PRIMARY KEY (IngredientesProdutosID))");
            //Tables.Add("CREATE TABLE IF NOT EXISTS Pedidos (PedidoID int,UserID int,DataPedido Varchar(250) ,PRIMARY KEY (PedidoID))");
            //Tables.Add("CREATE TABLE IF NOT EXISTS IngredientesProdutosPedido (IngredientesProdutosPedidoID,PedidoID int,ProdutoID int,IngredienteID Int ,PRIMARY KEY (IngredientesProdutosPedidoID))");

            foreach (var table in Tables)
            {
                var comand = Conexao.CreateCommand(table);
                comand.ExecuteNonQuery();
            }

            var tes = "";
        }

    }
}

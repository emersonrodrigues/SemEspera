using SemEspera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SemEspera.Data
{
    public class UserDao
    {
        private readonly SQLiteConnection Conexao;
        public UserDao(SQLiteConnection conexao)
        {

            
                this.Conexao = conexao;
            
            
            this.Conexao.CreateTable<User>();
            this.Conexao.CreateCommand("teste()");

        }

        public void Salvar(User usuario)
        {

         var Table = from U in Conexao.Table<User>() where U.Email.Equals(usuario.Email)  select U;   
            var users = Table.GetEnumerator() as Collection<User>;


            if (users == null)
            {
                Conexao.Insert(usuario);
                
            }
            else
            {
                Conexao.Update(usuario);
            }

        }
        public User GetUserByEmailAndPassword(string Email, string Senha)
        {


            var Table = from U in Conexao.Table<User>() where U.Email.ToLower().Equals(Email.ToLower()) && U.Senha.Equals(Senha) select U;


            var comand = "CREATE TABLE IF NOT EXISTS Produto (ProdutoID int,NomeProduto Varchar(250),Image varchar(251),Valor decimal(18,2),PRIMARY KEY (ProdutoID))";
            var teste = Conexao.CreateCommand(comand);
            var t = teste.ExecuteNonQuery();
            this.Conexao.CreateTable<ProdutoBase>();

            if (Table.Count() == 0)
            {
                return null;
            }
            return Table.First();
        }

        public List<User> ListUsers()
        {
            
            var lista = new List<User>();
            lista = new List<User>(Conexao.Table<User>());
            
            return lista;
        }

    }
}

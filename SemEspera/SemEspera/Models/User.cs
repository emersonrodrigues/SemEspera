using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models
{
    public class User
    {   [PrimaryKey,AutoIncrement]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        [Unique]
        public string Email { get;  private set; }
        public string Senha { get; private set; }
        public string NomeCompleto { get { return string.Format("{0}{1}", Nome, SobreNome); } }

        public User(string nome, string soreNome, string email, DateTime dataNascimento, string senha)
        {

            this.Nome = nome;
            this.SobreNome = soreNome;
            this.DataNascimento = dataNascimento;
            this.Email = email;
            this.Senha = senha;

        }
        public User()
        {

        }



    }
}

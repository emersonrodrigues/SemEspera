using SemEspera.Data;
using SemEspera.Helpers;
using SemEspera.Midia;
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public class PerfilCadastroViewModel : BaseViewModel
    {
        public User Usuario { get; private set; }
        public EntryCellPassWord entrycell { get; set; }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string sobreNome;
        public string SobreNome
        {
            get { return sobreNome; }
            set { sobreNome = value; }
        }

        private DateTime dataNascimento;
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public ICommand  TirarFoto { get; private set; }
        public ICommand CadastrarUsuario { get; private set; }

        private ImageSource fotoPerfil ="PerfilAnonimo.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            set {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }


        public PerfilCadastroViewModel()
        {
            CadastrarUsuario = new Command(() =>
            {
                Salvar();
            });
                TirarFoto = new Command(()=> 
            {
                DependencyService.Get<Icamera>().TirarFoto();
            });
            MessagingCenter.Subscribe<byte[]>(this, "FotoCapturada",(ImageBytes)=>
            {
                FotoPerfil = ImageSource.FromStream(()=> new MemoryStream(ImageBytes));

            });
        }

        private  void Salvar()
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var DAO = new UserDao(conexao);
                if (!string.IsNullOrEmpty(Nome) && !string.IsNullOrWhiteSpace(Nome)
                    && !string.IsNullOrEmpty(SobreNome) && !string.IsNullOrWhiteSpace(SobreNome)
                    && !string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Email)
                    && !string.IsNullOrEmpty(Senha) && !string.IsNullOrWhiteSpace(Senha)
                    )
                {
                    if (DataNascimento < DateTime.Now)
                    {
                        if (Email.Contains("@") && Email.Contains("."))
                        {
                            User user = new User(Nome, SobreNome, Email, DataNascimento, Senha);
                            DAO.Salvar(user);
                            var Login = new LoginViewModel(user);
                        } else { App.Current.MainPage.DisplayAlert("Email Invalido", "Email invalido!", "OK"); }
                    }
                    else { App.Current.MainPage.DisplayAlert("Data  Invalido", "Data de nascimento Invalida!", "OK"); }

                }
                else {
                    App.Current.MainPage.DisplayAlert("Cadastro Invalido", "Todos OS campos são obrigatorios", "OK");
                }


                
            }
        }
    }
}

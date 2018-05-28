using SemEspera.Data;
using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public class LoginViewModel
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }
        public static User usuario { get; private set; }
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }
        public ICommand LogarCommand { get; set; }
        public ICommand CadastrarPerfil { get; set; }
        public LoginViewModel()
        {
            InicializarCommand();
        }
        public LoginViewModel(User user)
        {
            Logar(user.Email,user.Senha);
        }

        private void InicializarCommand()
        {
            LogarCommand = new Command(() =>
            {
                Logar(Email, Senha);
            }, () => { return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Senha); });

            CadastrarPerfil = new Command(() =>
            {
                MessagingCenter.Send<User>(new User(), "CadastrarPerfil");
            });
        }

        private void Logar( string emailUsuer, string senhaUser)
        {
            using (var conexao = DependencyService.Get<ISqlite>().GetConexao())
            {
                var DAO = new UserDao(conexao);
                LoginViewModel.usuario = DAO.GetUserByEmailAndPassword(emailUsuer, senhaUser);
                if (LoginViewModel.usuario is null)
                {
                    App.Current.MainPage.DisplayAlert("Login Invalido", "Email e/ou senha estão incorretos. Tente novamente!", "OK");

                }
                else
                
                       
                        MessagingCenter.Send<User>(LoginViewModel.usuario, "LoginPositivo");

                

             
            }
        }

    }

    }


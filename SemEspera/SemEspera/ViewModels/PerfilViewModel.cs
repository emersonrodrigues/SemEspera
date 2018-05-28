using SemEspera.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SemEspera.ViewModels
{
    public class PerfilViewModel
    {

        private ImageSource fotoPerfil = "PerfilAnonimo.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { fotoPerfil = value; }
        }

        public string Nome
        {
            get { return this.Usuario.Nome; }
            
            
        }
        public string Email
        {
            get { return Usuario.Email; }
            
        }

        private  User Usuario;
            public PerfilViewModel(User usuario)
        {
            this.Usuario = usuario; 
        }
    }
}

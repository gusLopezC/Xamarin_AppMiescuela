using DAL;
using AppMiescuela.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using COMMON.Interfaces;
using COMMON.Entidades;
using BIZ;

namespace AppMiescuela
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            IUsuariosManager manager = new UsuarioManager(new GenericRepository<Usuario>());
            btnIniciarSesion.Clicked += (sender, e) =>
            {
                Usuario usuario = manager.Login(txbUsuario.Text, pswClave.Text);
                if (usuario != null)
                {
                    Navigation.PushAsync(new ViewEscuela(usuario));
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Usuario o contraseña incorrecta", "Ok");
                }
            };
            btnCrearCuenta.Clicked += (sender, e) =>
            {
                Usuario usuario = manager.CrearCuenta(txbUsuario.Text, pswClave.Text);
                if (usuario != null)
                {
                    DisplayAlert("Mi Escuela", "Cuenta creada correctamente, ya puede iniciar sesión...", "Ok");
                    Navigation.PushAsync(new Vistas.ViewEscuela(usuario));
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al crear la cuenta, intente mas tarde", "Ok");
                }
            };
        }
    }
}


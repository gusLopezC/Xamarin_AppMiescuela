using COMMON.Entidades;
using COMMON.Interfaces;
using DAL;
using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMiescuela.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewEscuela : ContentPage
	{
        Usuario usuario;
        public ViewEscuela (Usuario usuario)
		{
			InitializeComponent ();
            this.usuario = usuario;
            btnAgregarMateria.Clicked += BtnAgregarMateria_Clicked;
            btnAgregarCompaniero.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewCompaniero(new Companiero()
                {
                    IdUsuario = usuario.Id
                }, true));
            };
            lstCompanieros.ItemTapped += (sender, e) =>
            {
                if (lstCompanieros.SelectedItem != null)
                {
                    Navigation.PushAsync(new ViewCompaniero(lstCompanieros.SelectedItem as Companiero, false));
                }
            };
            lstMaterias.ItemTapped += (sender, e) =>
            {
                if (lstMaterias.SelectedItem != null)
                {
                    Navigation.PushAsync(new ViewMateria(lstMaterias.SelectedItem as Materia, false));
                }
            };

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ICompanieroManager manager = new CompanieroManager(new GenericRepository<Companiero>());
            lstCompanieros.ItemsSource = manager.CompanierosDeUsuario(usuario.Id);
            IMateriaManager materiaManager = new MateriasManager(new GenericRepository<Materia>());
            lstMaterias.ItemsSource = materiaManager.BuscarMateriasDeUsuario(usuario.Id);
        }

        private void BtnAgregarMateria_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewMateria(new Materia()
            {
                IdUsuario = usuario.Id
            }, true));
        }
    }
}
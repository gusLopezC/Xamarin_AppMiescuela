using COMMON.Interfaces;
using COMMON.Entidades;
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
	public partial class ViewCompaniero : ContentPage
	{
        ICompanieroManager manager;
        public ViewCompaniero (Companiero companiero, bool nuevo)
		{
			InitializeComponent ();
            manager = new CompanieroManager(new GenericRepository<Companiero>());
            Contenedor.BindingContext = companiero;

            btnGuardar.Clicked += (sender, e) => {
                Companiero resultado;
                if (nuevo)
                {
                    resultado = manager.Agregar(Contenedor.BindingContext as Companiero);
                }
                else
                {
                    resultado = manager.Modificar(Contenedor.BindingContext as Companiero);
                }
                if (resultado != null)
                {
                    DisplayAlert("Mi Escuela", "Compañero Guardado", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al guardar :'(   ...", "Ok");
                }
            };
            btnEliminar.Clicked += (sender, e) =>
            {
                if (manager.Eliminar(companiero.Id))
                {
                    DisplayAlert("Mi Escuela", "Compañero eliminado", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al eliminar", "ok");
                }
            };
        }
    
	}
}
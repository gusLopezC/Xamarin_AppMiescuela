using COMMON.Entidades;
using COMMON.Interfaces;
using BIZ;
using DAL;
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
	public partial class ViewTarea : ContentPage
	{
        private bool nuevo;
        Tarea tarea;
        ITareaManager tareaManager;

        public ViewTarea(Tarea tarea, bool nuevo)
		{
            this.nuevo = nuevo;
            this.tarea = tarea;
            InitializeComponent ();
            tareaManager = new TareaManager(new GenericRepository<Tarea>());
            contenedor.BindingContext = tarea;

            btnGuardar.Clicked += (sender, e) =>
            {
                Tarea resultado;
                if (nuevo)
                {
                    resultado = tareaManager.Agregar(contenedor.BindingContext as Tarea);
                }
                else
                {
                    resultado = tareaManager.Modificar(contenedor.BindingContext as Tarea);
                }
                if (resultado != null)
                {
                    DisplayAlert("Mi Escuela", "Tarea Guardado", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Mi Escuela", "Error al guardar :'(   ...", "Ok");
                }

            };
            btnEliminar.Clicked += (sender, e) =>
            {
                if (!nuevo)
                {
                    if (tareaManager.Eliminar(tarea.Id))
                    {
                        DisplayAlert("Mi Escuela", "Tarea Eliminada Correctamente", "OK");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Mi Escuela", "No se pudo eliminar la Tarea", "OK");
                    }
                }
            };


        }
    }
}
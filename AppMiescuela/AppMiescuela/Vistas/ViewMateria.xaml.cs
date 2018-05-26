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
	public partial class ViewMateria : ContentPage
	{
        private bool nuevo;
        Materia materia;
        
        IMateriaManager materiaManager;
        ITareaManager tareaManager;
        public ViewMateria (Materia materia, bool nuevo)
		{
			InitializeComponent ();
            this.nuevo = nuevo;
            this.materia = materia;
            materiaManager = new MateriasManager(new GenericRepository<Materia>());
            tareaManager = new TareaManager(new GenericRepository<Tarea>());
            contenedor.BindingContext = materia;
            this.Appearing += ViewMateria_Appearing;

            btnGuardar.Clicked += (sender, e) =>
            {
                Materia resultado;
                if (nuevo)
                {
                    resultado = materiaManager.Agregar(contenedor.BindingContext as Materia);
                }
                else
                {
                    resultado = materiaManager.Modificar(contenedor.BindingContext as Materia);
                }
                if (resultado != null)
                {
                    DisplayAlert("Mi Escuela", "Materia Guardado", "Ok");
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
                    if (materiaManager.Eliminar(materia.Id))
                    {
                        DisplayAlert("Mi Escuela", "Materia Eliminada Correctamente", "OK");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Mi Escuela", "No se pudo eliminar la materia", "OK");
                    }
                }
            };

            btnAgregarTarea.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewTarea(new Tarea()
                {
                    IdMateria = materia.Id
                }, true));
            };
            lstTareas.ItemTapped += (sender, e) =>
            {

                if (lstTareas.SelectedItem != null)
                {
                    Navigation.PushAsync(new ViewTarea(lstTareas.SelectedItem as Tarea, false));
                }
            };
            }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    IMateriaManager materiaManager = new MateriasManager(new GenericRepository<Materia>());
        //    lstTareas.ItemsSource = materiaManager.BuscarMateriasDeUsuario(materia.Id);

        //}

            public void ViewMateria_Appearing(object sender, EventArgs e)
        {
           
            lstTareas.ItemsSource = null;
            lstTareas.ItemsSource = tareaManager.BuscarTareasDeMateria(materia.Id);
        }


    }
}
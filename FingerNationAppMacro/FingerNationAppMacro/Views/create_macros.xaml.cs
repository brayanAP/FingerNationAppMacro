using FingerNationAppMacro.models;
using FingerNationAppMacro.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FingerNationAppMacro.views
{
   

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class create_macros : ContentPage
	{
        

        public create_macros()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            ObservableCollection<string> listCa = new ObservableCollection<string>();
            listCa.Add("Masculino");
            listCa.Add("Femenino");

            pickersexo.ItemsSource = listCa;
            pickersexo.SelectedItem = "Masculino";

            ObservableCollection<string> listumd = new ObservableCollection<string>();
            listumd.Add("Aumentar peso rápido");
            listumd.Add("Aumentar peso lentamente");
            listumd.Add("Aumentar peso lentamente");
            listumd.Add("Mantener mi peso actual");
            listumd.Add("Perder peso lentamente");
            listumd.Add("Perder peso rápido");
            pickerobjetivo.ItemsSource = listumd;
            pickerobjetivo.SelectedItem = "Mantener mi peso actual";

            ObservableCollection<string> lista = new ObservableCollection<string>();
            lista.Add("Sedentario");
            lista.Add("Actividad baja");
            lista.Add("Activo");
            lista.Add("Muy Activo");
            pickeractividad.ItemsSource = lista;
            pickeractividad.SelectedItem = "Activo";
        }
    }
}
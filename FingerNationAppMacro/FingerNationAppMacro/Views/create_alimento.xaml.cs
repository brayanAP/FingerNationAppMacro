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
    public class Medidas
    {
        public string unidadmedida { get; set; }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class create_alimento : ContentPage
	{
        
		public  create_alimento()
		{
			InitializeComponent ();
           // guardaCategorias();


        }

        

        protected async override void OnAppearing()
        {
            ObservableCollection<string> listCa = new ObservableCollection<string>();
            listCa.Add("Leche y productos lácteos");
            listCa.Add("Frutas y Verduras");
            listCa.Add("Carne, pescado y huevos");
            listCa.Add("Salchichonería");
            listCa.Add("Cereales, panes, pasta y otros derivados");
            listCa.Add("Jugos y Bebidas");
            listCa.Add("Legumbres (o leguminosas)");
            listCa.Add("Tubérculos");
            listCa.Add("Frutos secos");
            listCa.Add("Congelados");
            listCa.Add("Comida rápida");
            listCa.Add("Otros");

            pickercategoria.ItemsSource = listCa;

            ObservableCollection<string> listumd = new ObservableCollection<string>();
            listumd.Add("ml");
            listumd.Add("gr");
            pickerumd.ItemsSource = listumd;


        }

    }
}
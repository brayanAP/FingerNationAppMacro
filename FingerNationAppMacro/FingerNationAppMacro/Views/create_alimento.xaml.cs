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
	public partial class create_alimento : ContentPage
	{
        
		public  create_alimento(Alimentos a)
		{
			InitializeComponent ();

        }

        public create_alimento()
        {
            InitializeComponent();
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
            pickercategoria.SelectedItem = "Otros";

            ObservableCollection<string> listumd = new ObservableCollection<string>();
            listumd.Add("ml");
            listumd.Add("gr");
            pickerumd.ItemsSource = listumd;
            pickerumd.SelectedItem = "gr";
        }

        public async void guardarAlimento()
        {
            SrvFingerNation srv = new SrvFingerNation();
            Alimentos alimento = new Alimentos();
            try
            {
                alimento.id = 0;
                alimento.categoria = pickercategoria.SelectedItem.ToString();
                alimento.nombre = nombre.Text.ToString().ToLower();
                alimento.calorias = float.Parse(calorias.Text.ToString());
                alimento.marca = marca.Text.ToString();
                alimento.cantidad = int.Parse(cantidad.Text.ToString());
                alimento.unidadmedida = pickerumd.SelectedItem.ToString();
                alimento.carbohidratos = float.Parse(carbohidratos.Text.ToString());
                alimento.fibra = float.Parse(fibra.Text.ToString());
                alimento.azucar = float.Parse(azucar.Text.ToString());
                alimento.proteinas = float.Parse(proteinas.Text.ToString());
                alimento.grasas = float.Parse(grasas.Text.ToString());
                alimento.monoinsaturadas = float.Parse(monoinsaturadas.Text.ToString());
                alimento.poliinsaturadas = float.Parse(poliinsaturadas.Text.ToString());
                alimento.saturadas = float.Parse(saturadas.Text.ToString());
                alimento.sodio = float.Parse(sodio.Text.ToString());
            }
            catch
            {
                await DisplayAlert("ERROR", "DATOS INCORRECTOS.", "OK");
            }
            

            await srv.InsertAlimentos(alimento);

            nombre.Text = "";
            calorias.Text = "";
            marca.Text = "";
            cantidad.Text = "";
            carbohidratos.Text = "";
            fibra.Text = "";
            azucar.Text = "";
            proteinas.Text = "";
            grasas.Text = "";
            monoinsaturadas.Text = "";
            poliinsaturadas.Text = "";
            saturadas.Text = "";
            sodio.Text = "";
        
        }


        public void btn_ClickedSave(object sender, EventArgs e)
        {
            guardarAlimento();
            
        }//GUARDAR ALIMENTO

    }
}
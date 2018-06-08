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
	public partial class create_dia : ContentPage
	{
		public create_dia ()
		{
			InitializeComponent ();
		}

        public create_dia(ConsumoDia dia)
        {
            InitializeComponent();
            comida.SelectedItem = dia.Comida;
            autoComplete.Text = dia.Alimento;
            cantidad.Text = dia.Cantidad+"";
        }


        protected async override void OnAppearing()
        {
            SrvFingerNation srv = new SrvFingerNation();
            var lista = await srv.GetAllAlimentos();
            ObservableCollection<string> listaAlimentos = new ObservableCollection<string>();
            if(lista.Count != 0)
            {
                foreach (Alimentos a in lista)
                {
                    listaAlimentos.Add(a.nombre);
                }
            }

            autoComplete.DataSource = listaAlimentos;

            ObservableCollection<string> com = new ObservableCollection<string>()
            {
                "Almuerzo",
                "Comida",
                "Cena",
                "Otros"
            };

            comida.ItemsSource = com;
            comida.SelectedItem = "Otros";
        }

        private async void guardarAlimentoDia()
        {
            SrvFingerNation srv = new SrvFingerNation();
            ConsumoDia dia = new ConsumoDia();

            var listaAlimento = await srv.GetAllAlimentos();

            if(listaAlimento.Count!= 0)
            {
                foreach(Alimentos a in listaAlimento)
                {
                    
                    if(a.nombre == autoComplete.Text.ToString())
                    {
                        /*AQUI ESTA EL ALIMENTO*/
                        double calorias = (a.calorias / 100) * double.Parse(cantidad.Text.ToString());
                        double proteinas = (a.proteinas / 100) * double.Parse(cantidad.Text.ToString());
                        double grasas = (a.grasas / 100) * double.Parse(cantidad.Text.ToString());
                        double carbohidratos = (a.carbohidratos / 100) * double.Parse(cantidad.Text.ToString());

                        dia.Id = 0;
                        dia.Alimento = a.nombre;
                        dia.Cantidad = int.Parse(cantidad.Text.ToString());
                        dia.Calorias = calorias;
                        dia.Proteina = proteinas;
                        dia.Grasa = grasas;
                        dia.Carbohidratos = carbohidratos;
                        dia.Comida = comida.SelectedItem.ToString();
                        dia.Fecha = DateTime.Now.ToString();
                        dia.Terminado = "I";

                        await srv.InsertConsumoDia(dia);
                    } 
                }//recorrer alimentos
            }//verificar que no este vacia la lista
        }

        public void btn_ClickedSave(object sender, EventArgs e)
        {
            guardarAlimentoDia();
            MainPage mp = new MainPage();
            Type page = typeof(index_dias);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GUARDAR ALIMENTO

        public void cancel(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            Type page = typeof(index_dias);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GO INSERT

    }
}
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
	public partial class index_calculadora : ContentPage
	{
        Macronutrientes mcros;
		public index_calculadora ()
		{
			InitializeComponent ();
            

            
        }

        protected async override void OnAppearing()
        {
            getMacros();
        }

        public async void getMacros()
        {
            SrvFingerNation srv = new SrvFingerNation();
            var lista = await srv.GetAllMacronutrientes();

            mcros = new Macronutrientes();

            if(lista.Count != 0)
            {
                foreach(Macronutrientes m in lista)
                {
                    if(m.fecha == "OK")
                    {
                        mcros.id = m.id;
                        mcros.meta = m.meta;
                        mcros.proteinas = m.proteinas;
                        mcros.calorias = m.calorias;
                        mcros.proteinas = m.proteinas;
                        mcros.carbohidratos = m.carbohidratos;
                        mcros.grasas = m.grasas;
                    }
                }


                calorias.Text = ((int)mcros.calorias) + "cal";
                proteinas.Text = mcros.proteinas + "gr";
                grasas.Text = mcros.grasas + "gr";
                carbohidratos.Text = mcros.carbohidratos + "gr";

                string obj = mcros.meta;

                opcion.Text = "<"+mcros.meta+">";

                switch (obj)
                {
                    case "Aumentar peso rápido":
                        imagen.Source = "srapido.png";
                        break;
                    case "Aumentar peso lentamente":
                        imagen.Source = "slento.png";
                        break;
                    case "Mantener mi peso actual":
                        imagen.Source = "mantener.png";
                        break;
                    case "Perder peso lentamente":
                        imagen.Source = "blento.png";
                        break;
                    case "Perder peso rápido":
                        imagen.Source = "brapido.png";
                        break;
                }
            }
            else
            {
                await DisplayAlert("ERROR", "MACROS NO ENCONTRADO", "OK");
            }
        }//getMacros

        public void Create(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            Type page = typeof(create_macros);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GUARDAR ALIMENTO
    }
}
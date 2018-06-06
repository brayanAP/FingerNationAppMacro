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
            /*getMacros();

            calorias.Text = mcros.calorias+"cal";
            proteinas.Text = mcros.proteinas+"gr";
            grasas.Text = mcros.grasas+"gr";
            carbohidratos.Text = mcros.carbohidratos+"gr";

            string obj = mcros.meta;

            opcion.Text = "<< AUMENTAR PESO RAPIDO >>";

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
            }*/
        }

        public async void getMacros()
        {
            SrvFingerNation srv = new SrvFingerNation();
            var lista = await srv.GetAllMacronutrientes();

            mcros = new Macronutrientes()
            {
                id = lista[0].id,
        fecha = lista[0].fecha,
        meta = lista[0].meta,
        proteinas = lista[0].proteinas,
        carbohidratos = lista[0].carbohidratos,
        grasas = lista[0].grasas,
       calorias = lista[0].calorias
    };
        }

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
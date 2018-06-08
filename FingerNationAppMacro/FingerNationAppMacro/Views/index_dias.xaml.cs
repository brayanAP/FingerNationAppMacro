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

    public class TempConsumoDia
    {
        public string Alimento { get; set; }
        public int Cantidad { get; set; }
        public double Calorias { get; set; }
        public double Proteina { get; set; }
        public double Grasa { get; set; }
        public double Carbohidratos { get; set; }
        public string Comida { get; set; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class index_dias : ContentPage
	{
		public index_dias ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            ObservableCollection<TempConsumoDia> listaGrid = new ObservableCollection<TempConsumoDia>();

            SrvFingerNation srv = new SrvFingerNation();

            var lista = await srv.GetAllConsumoDia();
            if(lista.Count != 0)
            {
                foreach(ConsumoDia c in lista)
                {
                    TempConsumoDia temp = new TempConsumoDia()
                    {
                        Alimento = c.Alimento,
                        Calorias = c.Calorias,
                        Proteina = c.Proteina,
                        Grasa = c.Grasa,
                        Cantidad = c.Cantidad,
                        Carbohidratos = c.Carbohidratos,
                        Comida = c.Comida
                    };
                    listaGrid.Add(temp);
                }
            }

            dataGrid.ItemsSource = listaGrid;
        }

        public void goCreateDiaInsert(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            Type page = typeof(create_dia);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GO INSERT


        private async void Delete(object sender, EventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                TempConsumoDia a = dataGrid.SelectedItem as TempConsumoDia;
                SrvFingerNation sr = new SrvFingerNation();
                var lista = await sr.GetAllConsumoDia();

                foreach (ConsumoDia alimento in lista)
                {
                    if (alimento.Alimento == a.Alimento)
                    {
                        await sr.DeleteConsumoDia(alimento);
                        MainPage mp = new MainPage();
                        Type page = typeof(index_dias);
                        mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                        mp.IsPresented = false;
                        App.Current.MainPage = mp;
                    }
                }
            }
        }

        private async void Edit(object sender, EventArgs e)
        {
            if (dataGrid.SelectedItem!= null)
            {
                TempConsumoDia a = dataGrid.SelectedItem as TempConsumoDia;
                SrvFingerNation sr = new SrvFingerNation();
                var lista = await sr.GetAllConsumoDia();

                foreach (ConsumoDia alimento in lista)
                {
                    if (alimento.Alimento == a.Alimento)
                    {
                        App.Current.MainPage = new create_dia(alimento);
                    }
                }
            }
        }//EDIT

    }
}
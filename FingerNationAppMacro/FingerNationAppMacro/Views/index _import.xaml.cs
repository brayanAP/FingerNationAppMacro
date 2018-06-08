using FingerNationAppMacro.models;
using FingerNationAppMacro.Services;
using Microcharts;
using SkiaSharp;
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
	public partial class index_import : ContentPage
	{
       
        public index_import ()
		{
			InitializeComponent ();
        }

        private async void importAlm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var ws = await w.getWebServiceAlm();
            List<Alimentos> lista = new List<Alimentos>();

            foreach (Alimentos t in ws)
            {
                lista.Add(t);
            }
            await x.setXamarinAlm(lista);
        }//IMPORTAR DESDE EL REST A XAMARIN

        private async void exportAlm()
        {
            ConnectWebService w = new ConnectWebService();
            ConnectXamarin x = new ConnectXamarin();

            var xa = await x.getXamarinAlm();

            List<Alimentos> lista = new List<Alimentos>();

            foreach (Alimentos t in xa)
            {
                lista.Add(t);
            }

            await w.setWebServiceAlm(lista);
        }//EXPORTAR PARA EL REST

        protected async override void OnAppearing()
        {
            ConnectWebService cw = new ConnectWebService();
            ObservableCollection<TempAlimento> listaAli = new ObservableCollection<TempAlimento>();
            try
            {
                var lista = await cw.getWebServiceAlm();
                if (lista.Count != 0)
                {
                    foreach (Alimentos a in lista)
                    {
                        listaAli.Add(new TempAlimento()
                        {
                            Nombre = a.nombre,
                            Categoria = a.categoria,
                            Calorias = a.calorias,
                            Proteinas = a.proteinas,
                            Carbohidratos = a.carbohidratos,
                            Grasas = a.grasas
                        });
                    }
                }
            }
            catch
            {
                await DisplayAlert("ERROR", "Error al Conectar al WS.", "Ok");
            }
            

            

            dataGrid.ItemsSource = listaAli;
        }
    }

    public class TempAlimento
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public float Calorias { get; set; }
        public float Proteinas { get; set; }
        public float Carbohidratos { get; set; }
        public float Grasas { get; set; }

    }
}
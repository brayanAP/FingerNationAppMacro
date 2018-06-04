using FingerNationAppMacro.models;
using FingerNationAppMacro.services;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FingerNationAppMacro.views
{
    public class tempAlimentos
    {
        public string nombre { get; set; }
        public string categoria { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class index_alimentos : ContentPage
    {

        ObservableCollection<tempAlimentos> listaAli;

        public async void getAlimentos()
        {
            SrvFingerNation a = new SrvFingerNation();
            var lista = await a.GetAllAlimentos();
            
            if(lista!= null)
            {
                foreach (Alimentos alimento in lista)
                {
                    tempAlimentos tla = new tempAlimentos();
                    tla.nombre = alimento.nombre;
                    tla.categoria = alimento.categoria;
                    listaAli.Add(tla);
                }
            }
        }//getAllAli


        public index_alimentos()
        {
            InitializeComponent();
            listaAli = new ObservableCollection<tempAlimentos>();
        }

        protected async override void OnAppearing()
        {
            getAlimentos();
            listView.ItemsSource = listaAli;
        }

        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterAlimento;
                this.listView.DataSource.RefreshFilter();
            }
        }

        private bool FilterAlimento(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var contacts = obj as tempAlimentos;
            if (contacts.nombre.ToLower().Contains(searchBar.Text.ToLower())
                 || contacts.categoria.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }


        public void goCreateAlimentoInsert(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            Type page = typeof(create_alimento);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GO INSERT


        private async void Delete(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                tempAlimentos a = listView.SelectedItem as tempAlimentos;
                SrvFingerNation sr = new SrvFingerNation();
                var lista = await sr.GetAllAlimentos();

                foreach (Alimentos alimento in lista)
                {
                    if (alimento.nombre == a.nombre)
                    {
                        await sr.DeleteAlimentos(alimento);
                        MainPage mp = new MainPage();
                        Type page = typeof(index_alimentos);
                        mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                        mp.IsPresented = false;
                        App.Current.MainPage = mp;
                    }
                }
            }
        }

        private async void Edit(object sender, EventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                tempAlimentos a = listView.SelectedItem as tempAlimentos;
                SrvFingerNation sr = new SrvFingerNation();
                var lista = await sr.GetAllAlimentos();

                foreach (Alimentos alimento in lista)
                {
                    if (alimento.nombre == a.nombre)
                    {
                        App.Current.MainPage = new create_alimento(alimento);
                    }
                }
            }
        }//EDIT




    }

}
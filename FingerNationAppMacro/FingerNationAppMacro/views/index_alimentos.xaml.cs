using Syncfusion.ListView.XForms;
using System.Collections.ObjectModel;
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
        ObservableCollection<tempAlimentos> listaEva = new ObservableCollection<tempAlimentos>()
        {
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Pechuga de pollo",
                categoria = "Carnes"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Galleta Maria",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Galleta Oreo",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Perro"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Gato"
            },
            new tempAlimentos
            {
                nombre = "Avena Quaker",
                categoria = "Cereales"
            }
        };

       

        public index_alimentos()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            listView.ItemsSource = listaEva;
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



        
    }

}
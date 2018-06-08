using FingerNationAppMacro.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FingerNationAppMacro
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList
        {
            get;
            set;
        }

        public MainPage()
    {
        InitializeComponent();
        menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
        menuList.Add(new MasterPageItem()
        {
                Title = "Home",
                Icon = "home.png",
                TargetType = typeof(views.index)
        });
            menuList.Add(new MasterPageItem()
            {
                Title = "Mi Dia",
                Icon = "add.png",
                TargetType = typeof(views.index_dias)

            });
            menuList.Add(new MasterPageItem()
        {
            Title = "Mis alimentos",
            Icon = "alimentos.png",
            TargetType = typeof(views.index_alimentos)
        });//LISTOOOOOOOOOOOOO
            menuList.Add(new MasterPageItem()
        {
            Title = "Calculadora de Macronutrientes",
            Icon = "calculadora.png",
            TargetType = typeof(views.index_calculadora)
        });
            menuList.Add(new MasterPageItem()
        {
            Title = "Mis logros",
            Icon = "logros.png",
            TargetType = typeof(views.index_logros)
        });
        menuList.Add(new MasterPageItem()
        {
             Title = "Configuración",
                Icon = "configuracion.png",
                TargetType = typeof(views.index_configuracion)
            
        });
            menuList.Add(new MasterPageItem()
            {
                Title = "Importar Alimentos",
                Icon = "configuracion.png",
                TargetType = typeof(views.index_import)

            });

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
        // Initial navigation, this can be used for our home page  
        Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(views.index)));
    }
    // Event for Menu Item selection, here we are going to handle navigation based  
    // on user selection in menu ListView  
    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = (MasterPageItem)e.SelectedItem;
        Type page = item.TargetType;
        Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        IsPresented = false;
    }
}
}


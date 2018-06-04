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
		public index_calculadora ()
		{
			InitializeComponent ();
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
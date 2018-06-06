using FingerNationAppMacro.models;
using FingerNationAppMacro.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FingerNationAppMacro.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class index_configuracion : ContentPage
	{

        Usuario usuario;
		public  index_configuracion ()
		{
			InitializeComponent ();
        
                getUsuario();
                
            
            
            
        }

        public async void getUsuario()
        {/*
            SrvFingerNation srv = new SrvFingerNation();
            var temp = await srv.GetIdUsuario(1);

            usuario = new Usuario()
            {
                id = temp.id,
                nombre = temp.nombre,
                edad = temp.edad,
                peso = temp.peso,
                altura = temp.altura,
                sexo = temp.sexo

            };*/
        }

        protected async override void OnAppearing()
        {
/*
            edad.Text = usuario.edad + "";
            altura.Text = usuario.altura + "";
            peso.Text = usuario.peso + "";*/

        }


         public async void guardarUsuario()
         {
            SrvFingerNation srv = new SrvFingerNation();
            Usuario user = new Usuario();
            try
            {
                user.id = 1;
                user.nombre = "BRAYAN ULISSES ARIAS PEREZ";
                user.edad = int.Parse(edad.Text.ToString());
                user.peso = float.Parse(peso.Text.ToString());
                user.altura = float.Parse(altura.Text.ToString());
                user.sexo = "Hombre";

            }
            catch
            {
                await DisplayAlert("ERROR", "DATOS INCORRECTOS.", "OK");
            }


            await srv.InsertUsuario(user);

        }


        public void btn_ClickedSave(object sender, EventArgs e)
        {
            guardarUsuario();
            MainPage mp = new MainPage();
            Type page = typeof(index_configuracion);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GUARDAR ALIMENTO
    }
}
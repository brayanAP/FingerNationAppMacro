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



        }

        public async void getUsuario()
        {
            SrvFingerNation srv = new SrvFingerNation();
            var temp = await srv.GetAllUsuario();

            if(temp!= null)
            {
                foreach (Usuario u in temp)
                {
                    if (u.nombre == "BRAYAN ULISSES ARIAS PEREZ")
                    {
                        usuario = new Usuario()
                        {
                            id = u.id,
                            nombre = u.nombre,
                            edad = u.edad,
                            peso = u.peso,
                            altura = u.altura,
                            sexo = u.sexo

                        };
                    }
                }
            }
            else
            {
                await DisplayAlert("ERROR", "USURIO NO ENCONTRADO", "OK");
            }
            
            
        }

        protected async override void OnAppearing()
        {
            /*
                        */
            getUsuario();
            peso.Text = usuario.peso.ToString();


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
                user.peso = double.Parse(peso.Text.ToString());
                user.altura = double.Parse(altura.Text.ToString());
                user.sexo = "Hombre";
                await srv.InsertUsuario(user);
            }
            catch
            {
                await DisplayAlert("ERROR", "DATOS INCORRECTOS.", "OK");
            }


            

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
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
            try
            {
                SrvFingerNation srv = new SrvFingerNation();
                var temp = await srv.GetAllUsuario();
                //await DisplayAlert("OK", user.nombre, "OK");

            
            
            if(temp.Count != 0)
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
                            //await DisplayAlert("OK",usuario.id.ToString(),"ok");
                            edad.Text = usuario.edad.ToString();
                            peso.Text = usuario.peso.ToString();
                            altura.Text = usuario.altura.ToString();

                        }
                        else {
                            await DisplayAlert("ok","nuestros datos no coinciden habla a soporte","ok");
                        }
                    }
                }
            else
            {
                await DisplayAlert("ERROR", "USURIO NO ENCONTRADO", "OK");
            }
            }
            catch (Exception e)
            {
                await DisplayAlert("OK", e.Message, "OK");
            }

        }

        protected async override void OnAppearing()
        {
            /*
            
            
            Usuario user = new Usuario();
            user.id = 3;
            user.nombre = "Edgar Eduardo Nuñez Gonzalez";
            user.edad = 21;
            user.altura = 45;
            user.peso = 46;
            user.sexo = "M";
            await srv.DeleteUsuario(user);
            await srv.InsertUsuario(user);
            */
            /*
             * 
            peso.Text = usuario.peso.ToString();
                        */
            
            getUsuario();

        }


         public async void guardarUsuario()
         {
            SrvFingerNation srv = new SrvFingerNation();
            Usuario user = new Usuario();
            try
            {
                user.id = 2;
                user.nombre = "BRAYAN ULISSES ARIAS PEREZ";
                user.edad = int.Parse(edad.Text.ToString());
                user.peso = double.Parse(peso.Text.ToString());
                user.altura = double.Parse(altura.Text.ToString());
                user.sexo = "H";
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
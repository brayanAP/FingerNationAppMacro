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
	public partial class create_macros : ContentPage
	{
        

        public create_macros()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            ObservableCollection<string> listumd = new ObservableCollection<string>();
            listumd.Add("Aumentar peso rápido");
            listumd.Add("Aumentar peso lentamente");
            listumd.Add("Aumentar peso lentamente");
            listumd.Add("Mantener mi peso actual");
            listumd.Add("Perder peso lentamente");
            listumd.Add("Perder peso rápido");
            pickerobjetivo.ItemsSource = listumd;
            pickerobjetivo.SelectedItem = "Mantener mi peso actual";

            ObservableCollection<string> lista = new ObservableCollection<string>();
            lista.Add("Sedentario");
            lista.Add("Actividad baja");
            lista.Add("Activo");
            lista.Add("Muy Activo");
            pickeractividad.ItemsSource = lista;
            pickeractividad.SelectedItem = "Activo";
        }


        /*CODIGO DE GUARDAR Y CANCELAR*/
        public async void guardarMacronutrientes()
        {
            SrvFingerNation srv = new SrvFingerNation();
            Macronutrientes macro = new Macronutrientes();
            Usuario usuario = new Usuario();

            var usu = await srv.GetIdUsuario(1);
            try
            {
                /*DATOS USUARIO*/
                usuario.id = usu.id;
                usuario.nombre = usu.nombre;
                usuario.edad = usu.edad;
                usuario.altura = usu.altura;
                usuario.peso = int.Parse(peso.Text.ToString());
                usuario.sexo = usu.sexo;

                /*GUARDAR CAMBIOS*/
                await srv.InsertUsuario(usuario);

                string actividad = pickeractividad.SelectedItem.ToString();
                macro.id = 0;
                macro.fecha = "OK";
                macro.meta = pickerobjetivo.SelectedItem.ToString();

                double caloriasVivir = 0;

                if(usuario.sexo == "Hombre")
                {
                    caloriasVivir = (10 * usuario.peso) + (6.25 * usuario.altura) - (5 * usuario.edad) + 5;
                }
                else
                {
                    caloriasVivir = (10 * usuario.peso) + (6.25 * usuario.altura) - (5 * usuario.edad) - 161;
                }

                switch (actividad)
                {
                    case "Sedentario":
                        caloriasVivir = caloriasVivir * 1.2;
                        break;
                    case "Actividad baja":
                        caloriasVivir = caloriasVivir * 1.375;
                        break;
                    case "Activo":
                        caloriasVivir = caloriasVivir * 1.55;
                        break;
                    case "Muy Activo":
                        caloriasVivir = caloriasVivir * 1.725;
                        break;
                }
                

                double proteina = 2.2 * usuario.peso;
                double grasas = 0.9 * usuario.peso;

                double caloriasP = proteina * 4;
                double caloriasG = grasas * 9;

                double caloriasC = caloriasVivir - (caloriasP + caloriasG);
                double carbohidratos = caloriasC / 4;

                double calorias = 0;

                switch (macro.meta)
                {
                    case "Aumentar peso rápido":
                        calorias = caloriasVivir + 800;
                        break;
                    case "Aumentar peso lentamente":
                        calorias = caloriasVivir + 500;
                        break;
                    case "Mantener mi peso actual":
                        calorias = caloriasVivir;
                        break;
                    case "Perder peso lentamente":
                        calorias = caloriasVivir - 500;
                        break;
                    case "Perder peso rápido":
                        calorias = caloriasVivir - 800;
                        break;
                }

                macro.proteinas = (float)proteina;
                macro.grasas = (float)grasas;
                macro.carbohidratos = (float)carbohidratos;
                macro.calorias = (float)calorias;

            }
            catch
            {
                await DisplayAlert("ERROR", "DATOS INCORRECTOS.", "OK");
            }


            await srv.InsertMacronutrientes(macro);

            peso.Text = "";

        }


        public void btn_ClickedSave(object sender, EventArgs e)
        {
            guardarMacronutrientes();
            MainPage mp = new MainPage();
            Type page = typeof(index_calculadora);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GUARDAR ALIMENTO


        public void Cancel(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            Type page = typeof(index_calculadora);
            mp.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            mp.IsPresented = false;
            App.Current.MainPage = mp;

        }//GUARDAR ALIMENTO
    }
}
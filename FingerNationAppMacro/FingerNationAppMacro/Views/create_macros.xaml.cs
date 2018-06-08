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

            var usu = await srv.GetAllUsuario();
            try
            {
                if (usu.Count != 0)
                {
                    /*DATOS USUARIO*/
                    foreach(Usuario t in usu)
                    {
                        if(t.nombre == "BRAYAN ULISSES ARIAS PEREZ")
                        {
                            usuario.id = t.id;
                            usuario.nombre = t.nombre;
                            usuario.edad = t.edad;
                            usuario.altura = t.altura;
                            if(peso.Text.Count() == 0)
                            {
                                usuario.peso = usuario.peso;
                            }
                            else
                            {
                                usuario.peso = int.Parse(peso.Text.ToString());
                            }
                            usuario.sexo = t.sexo;
                        }
                    }

                    /*GUARDAR CAMBIOS*/
                    await srv.InsertUsuario(usuario);

                    string actividad = pickeractividad.SelectedItem.ToString();
                    macro.id = 0;
                    macro.fecha = "OK";
                    macro.meta = pickerobjetivo.SelectedItem.ToString();

                    double TMB = 0;

                    if (usuario.sexo == "H")
                    {
                        //Hombres: TMB = 66 + [13,7 x peso (kg)] + [5 x altura (cm)] – [6,76 x edad (años)]
                        TMB = 66 + (((13.7 * usuario.peso)+(5 * usuario.altura))-(6.76 * usuario.edad));
                    }
                    else
                    {
                        //Mujeres: TMB = 655 + [9,6 x peso (kg)] + [1,8 x altura (cm)] – [4,7 x edad (años)]
                        TMB = 655+ (((9.6 * usuario.peso) + (1.8 * usuario.altura)) - (4.7 * usuario.edad));
                    }

                    switch (actividad)
                    {
                        case "Sedentario":
                            TMB = TMB * 1.2;
                            break;
                        case "Actividad baja":
                            TMB = TMB  * 1.375;
                            break;
                        case "Activo":
                            TMB = TMB * 1.55;
                            break;
                        case "Muy Activo":
                            TMB = TMB * 1.725;
                            break;
                    }


                    double proteina = 2.2 * usuario.peso;
                    double grasas = 0.9 * usuario.peso;

                    double caloriasP = proteina * 4;
                    double caloriasG = grasas * 9;

                    double caloriasC = TMB - (caloriasP + caloriasG);
                    double carbohidratos = (caloriasC / 4)*-1;

                    double calorias = 0;

                    switch (macro.meta)
                    {
                        case "Aumentar peso rápido":
                            calorias = TMB + 800;
                            break;
                        case "Aumentar peso lentamente":
                            calorias = TMB + 500;
                            break;
                        case "Mantener mi peso actual":
                            calorias = TMB;
                            break;
                        case "Perder peso lentamente":
                            calorias = TMB - 500;
                            break;
                        case "Perder peso rápido":
                            calorias = TMB - 800;
                            break;
                    }

                    macro.proteinas = (float)proteina;
                    macro.grasas = (float)grasas;
                    macro.carbohidratos = (float)carbohidratos;
                    macro.calorias = (float)calorias;

                }
                else
                {
                    await DisplayAlert("ERROR", "USURIO NO ENCONTRADO", "OK");
                }
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
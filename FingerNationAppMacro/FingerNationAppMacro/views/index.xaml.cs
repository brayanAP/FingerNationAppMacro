using Microcharts;
using SkiaSharp;
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
	public partial class index : ContentPage
	{
        List<Microcharts.Entry> entriesProteinas = new List<Microcharts.Entry>
        {

             new Microcharts.Entry(176)
             {
                 Label = "Totales",
                 ValueLabel = "176",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(89)
             {
                 Label = "Consumidas",
                 ValueLabel = "89",
                 Color = SKColor.Parse("#FF0000")
             }
        };

        List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {

             new Microcharts.Entry(212)
             {
                 Label = "05/06/2018",
                 ValueLabel = "3100",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(514)
             {
                 Label = "06/06/2018",
                 ValueLabel = "2900",
                 Color = SKColor.Parse("#FF0000")
             },
             new Microcharts.Entry(212)
             {
                 Label = "07/06/2018",
                 ValueLabel = "3001",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(514)
             {
                 Label = "08/06/2018",
                 ValueLabel = "3012",
                 Color = SKColor.Parse("#FF0000")
             },
             new Microcharts.Entry(212)
             {
                 Label = "09/06/2018",
                 ValueLabel = "3001",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(514)
             {
                 Label = "10/06/2018",
                 ValueLabel = "3012",
                 Color = SKColor.Parse("#FF0000")
             }
        };

        List<Microcharts.Entry> entriesCarbohidratos = new List<Microcharts.Entry>
        {

             new Microcharts.Entry(410)
             {
                 Label = "Totales",
                 ValueLabel = "410",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(214)
             {
                 Label = "Consumidos",
                 ValueLabel = "214",
                 Color = SKColor.Parse("#FF0000")
             }
        };

        List<Microcharts.Entry> entriesGrasas = new List<Microcharts.Entry>
        {

             new Microcharts.Entry(72)
             {
                 Label = "Totales",
                 ValueLabel = "72",
                 Color = SKColor.Parse("#212121")
             },
             new Microcharts.Entry(33)
             {
                 Label = "Consumidas",
                 ValueLabel = "33",
                 Color = SKColor.Parse("#FF0000")
             }
        };


        public index ()
		{
			InitializeComponent ();

            proteinasG.Chart = new DonutChart { Entries = entriesProteinas };
            carbohidratosG.Chart = new DonutChart { Entries = entriesCarbohidratos };
            grasasG.Chart= new DonutChart { Entries = entriesGrasas };

            tiempoCalorias.Chart = new BarChart()
            {
                Entries = entries
            };
        }
	}
}
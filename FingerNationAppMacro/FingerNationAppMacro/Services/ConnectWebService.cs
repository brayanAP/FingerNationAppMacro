using FingerNationAppMacro.models;
using FingerNationAppMacro.services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FingerNationAppMacro.Services
{
    public class ConnectWebService
    {
        private HttpClient _Client = new HttpClient();
        private const string URL = "http://localhost:51339/ServiceFingerNation.svc/";

        public async Task setWebServiceAlm(List<Alimentos> item)
        {
            /*URL A USAR*/
            const string url = URL + "createalm";
            var uri = new Uri(string.Format(url, string.Empty));

            /*CREAMOS EN JSON*/
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            /*ENVIAMOS EL JSON*/
            HttpResponseMessage response = null;
            response = await _Client.PostAsync(uri, content);

            /*RECIBIMOS LA RESPUESTA*/
            if (response.IsSuccessStatusCode)
            {


            }

        }//POST WEB SERVICE Alimentos

        public async Task<ObservableCollection<Alimentos>> getWebServiceAlm()
        {
            /*URL A USAR*/
            const string url = URL + "findallalm";

            /*PREGUNTA*/
            var content = await _Client.GetStringAsync(url);

            /*RESPUESTA, SE TRABAJA EL JSON DE RESPUESTA*/
            var post = JsonConvert.DeserializeObject<List<Alimentos>>(content);

            /*LO PASAMOS A UN FORMATO DE MANEJO*/
            return new ObservableCollection<Alimentos>(post);
        }//GET WEB SERVICE Alimentos
    }


    public class ConnectXamarin
    {
        SrvFingerNation sqlite = new SrvFingerNation();

        public async Task<IList<Alimentos>> getXamarinAlm()
        {
            return await sqlite.GetAllAlimentos();
        }//GET XAMARIN Alimentos

        public async Task setXamarinAlm(List<Alimentos> item)
        {
            var lista = await this.getXamarinAlm();
            bool exists = false;

            for (int i = 0; i < item.Count; i++)
            {
                for (int dx = 0; dx < lista.Count; dx++)
                {
                    if (item[i].nombre == lista[dx].nombre)
                    {
                        exists = true;
                    }
                }//FOR SECUNDARIO BUSCAR YA INSERTADO

                if (!(exists))
                {
                    Alimentos inv = item[i];
                    await sqlite.InsertAlimentos(inv);
                }
                else
                {
                    exists = false;
                }
            }//FOR PRINCIPAL
        }//SET XAMARIN Alimentos
    }
}

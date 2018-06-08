using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceFingerNation
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceFingerNation" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceFingerNation
    {
        #region CRUD TABLA: Alimentos
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallalm", ResponseFormat = WebMessageFormat.Json)]
        List<Alimentos> findAllAlm();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findalm/{id}", ResponseFormat = WebMessageFormat.Json)]
        Alimentos findAlm(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "createalm", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool createAlm(List<Alimentos> alimentos);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "editalm", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool editAlm(Alimentos alimentos);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "deletealm", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool deleteAlm(Alimentos alimentos);
        #endregion  
    }
}

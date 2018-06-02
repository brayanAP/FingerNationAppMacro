using FingerNationAppMacro.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FingerNationAppMacro.interfaces
{
    public interface ISrvFingerNation
    {
        //CRUD CATEGORIAS
        Task<IList<Categorias>> GetAllCategorias();
        Task InsertCategorias(Categorias item);
        Task DeleteCategorias(Categorias item);
        Task<Categorias> GetIdCategorias(int id);

        //CRUD ALIMENTOS
        Task<IList<Alimentos>> GetAllAlimentos();
        Task InsertAlimentos(Alimentos item);
        Task DeleteAlimentos(Alimentos item);
        Task<Alimentos> GetIdAlimentos(int id);

        //CRUD USUARIO
        Task<IList<Usuario>> GetAllUsuario();
        Task InsertUsuario(Usuario item);
        Task DeleteUsuario(Usuario item);
        Task<Usuario> GetIdUsuario(int id);

        //CRUD MACRONUTRIENTES
        Task<IList<Macronutrientes>> GetAllMacronutrientes();
        Task InsertMacronutrientes(Macronutrientes item);
        Task DeleteMacronutrientes(Macronutrientes item);
        Task<Macronutrientes> GetIdMacronutrientes(int id);

        //CRUD LOGROS
        Task<IList<Logros>> GetAllLogros();
        Task InsertLogros(Logros item);
        Task DeleteLogros(Logros item);
        Task<Logros> GetIdLogros(int id);

        //CRUD CONSUMO DIA
        Task<IList<ConsumoDia>> GetAllConsumoDia();
        Task InsertConsumoDia(ConsumoDia item);
        Task DeleteConsumoDia(ConsumoDia item);
        Task<ConsumoDia> GetIdConsumoDia(int id);

        //CRUD CONTEO CONSUMO DIA ALIMENTO
        Task<IList<ConteoConsumoDiaAlimento>> GetAllConteoConsumoDiaAlimento();
        Task InsertConteoConsumoDiaAlimento(ConteoConsumoDiaAlimento item);
        Task DeleteConteoConsumoDiaAlimento(ConteoConsumoDiaAlimento item);
        Task<ConteoConsumoDiaAlimento> GetIdConteoConsumoDiaAlimento(int id);

    }
}

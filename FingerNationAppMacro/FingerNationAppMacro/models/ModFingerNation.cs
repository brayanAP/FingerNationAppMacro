using SQLite;
using System;
using System.Text;

namespace FingerNationAppMacro.models
{
    public class Alimentos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public float calorias { get; set; }
        public string marca { get; set; }
        public int cantidad { get; set; }
        public string unidadmedida { get; set; }
        public float carbohidratos { get; set; }
        public float fibra { get; set; }
        public float azucar { get; set; }
        public float proteinas { get; set; }
        public float grasas { get; set; }
        public float monoinsaturadas { get; set; }
        public float poliinsaturadas { get; set; }
        public float saturadas { get; set; }
        public float sodio { get; set; }
    } 

    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public string sexo { get; set; }
    }

    public class Macronutrientes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string fecha { get; set; }
        public string meta { get; set; }
        public float proteinas { get; set; }
        public float carbohidratos { get; set; }
        public float grasas { get; set; }
        public float calorias { get; set; }
    }

    public class Logros
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public float pesoComienzo { get; set; }
        public float pesoLogrado { get; set; }
        public string metaLograda { get; set; }
    }

    public class ConsumoDia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Alimento { get; set; }
        public int Cantidad { get; set; }
        public double Calorias { get; set; }
        public double Proteina { get; set; }
        public double Grasa { get; set; }
        public double Carbohidratos { get; set; }
        public string Comida { get; set; }
        public string Fecha { get; set; }
        public string Terminado { get; set; }
    }

}

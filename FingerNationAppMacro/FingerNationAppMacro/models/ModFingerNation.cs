using System;
using System.Collections.Generic;
using System.Text;

namespace FingerNationAppMacro.models
{
    public class Categorias
    {
        public int id { get; set; }
        public int nombre { get; set; }
    }

    public class Alimnetos
    {
        public int id { get; set; }
        public int categoria { get; set; }
        public string nombre { get; set; }
        public float calorias { get; set; }
        public string marca { get; set; }
        public int cantidad { get; set; }
        public string unidadmedida { get; set; } //ml o gr
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
        public string nombre { get; set; }
        public int edad { get; set; }
        public float altura { get; set; }
        public float peso { get; set; }
        public char sexo { get; set; }
    }

    public class Macronutrientes
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string meta { get; set; }
        public float proteinas { get; set; }
        public float carbohidratos { get; set; }
        public float grasas { get; set; }
    }

    public class Logros
    {
        public int id { get; set; }
        public float pesoComienzo { get; set; }
        public float pesoLogrado { get; set; }
        public string metaLograda { get; set; }
    }
}

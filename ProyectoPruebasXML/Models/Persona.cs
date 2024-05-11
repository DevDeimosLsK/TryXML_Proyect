

using System;

namespace ProyectoPruebasXML.Models
{
    [Serializable]
    public class Persona
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string ciudad { get; set; }
    }
}

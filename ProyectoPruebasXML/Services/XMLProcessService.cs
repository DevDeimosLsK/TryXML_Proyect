using System;
using System.Collections.Generic;
using ProyectoPruebasXML.Models;
using System.Xml.Serialization;
using System.IO;

namespace ProyectoPruebasXML
{
    class XMLProcessService
    {
        public void CrearPersona(string path)
        {
            List<Persona> personas = LeerPersonas(path);
            Random NumeroRamdon = new Random();
            
            // Agregar una nueva persona
            personas.Add(new Persona { id = Guid.NewGuid().ToString(), nombre = "Jane Roe "+ NumeroRamdon.Next().ToString(), edad = NumeroRamdon.Next() , ciudad = "Los Angeles" });

            // Guardar la lista modificada en el archivo XML
            GuardarPersonas(personas, path);

            // Mostrar todas las personas
            foreach (var persona in personas)
            {
                Console.WriteLine($"Nombre: {persona.nombre}, Edad: {persona.edad}, Ciudad: {persona.ciudad}");
            }
        }

        public List<Persona> LeerPersonas(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Persona>));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Persona>)serializer.Deserialize(fileStream);
                }
                catch
                {
                    return new List<Persona>();
                }
            }
        }

        private void GuardarPersonas(List<Persona> personas, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Persona>));
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fileStream, personas);
            }
        }
    }
}

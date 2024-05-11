using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ProyectoPruebasXML.Models;

namespace ProyectoPruebasXML
{
    class PDFService
    {
        public void PDFMaker(string path)
        {
            XMLProcessService XMLObject = new XMLProcessService();
            List<Persona> personas = XMLObject.LeerPersonas(path);

            // Asumiendo que quieres un PDF para cada persona (o ajusta según sea necesario)
            foreach (var persona in personas)
            {
                string pdfPath = $"C:\\Users\\DeimosLsK\\source\\repos\\ProyectoPruebasXML\\ProyectoPruebasXML\\Responses\\Persona_{persona.id}.pdf";
                using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Paragraph($"Id Usuario: {persona.id}"));
                    pdfDoc.Add(new Paragraph($"Nombre: {persona.nombre}"));
                    pdfDoc.Add(new Paragraph($"Edad: {persona.edad}"));
                    pdfDoc.Add(new Paragraph($"Ciudad: {persona.ciudad}"));
                    pdfDoc.Close();
                }
            }
        }

    }
}

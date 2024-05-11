namespace ProyectoPruebasXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\DeimosLsK\\source\\repos\\ProyectoPruebasXML\\ProyectoPruebasXML\\Libs\\persona.xml";
            XMLProcessService XMLObject = new XMLProcessService();
            XMLObject.CrearPersona(path);
            PDFService ObjPdf = new PDFService();
            ObjPdf.PDFMaker(path);
        }

        
    }
}

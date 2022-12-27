using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UIKT.Models;

namespace UIKT
{
    public class Logic
    {

        static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string folder = "UIKT";
        static string file = "Vloge.xml";
        
        private static void CreteFile()
        {

            if (!Directory.Exists(Path.Combine(docPath, folder)))
            {
                Directory.CreateDirectory(Path.Combine(docPath, folder));
            }

            if (!File.Exists(Path.Combine(docPath, folder, file)))
            {
                //var f = File.Create(Path.Combine(docPath, folder, file));
                //f.Close();

                List<Vloga> vloge = new List<Vloga>();

                XmlSerializer serializer = new XmlSerializer(typeof(List<Vloga>));

                using (XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(docPath, folder, file)))
                {
                    xmlWriter.WriteStartDocument();
                    serializer.Serialize(xmlWriter, vloge);
                }
            }

        }

        public static void WriteFile(Vloga vloga)
        {
            CreteFile();

            List<Vloga> vloge = ReadFile();
            vloge.Add(vloga);
            
            if (File.Exists(Path.Combine(docPath, folder, file)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Vloga>));
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = false
                };

                using (XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(docPath, folder, file), settings))
                {
                    xmlWriter.WriteStartDocument();
                    serializer.Serialize(xmlWriter, vloge);
                }
            }


        }


        public static List<Vloga> ReadFile()
        {
            CreteFile();

            List<Vloga> vloge = null;

            if (File.Exists(Path.Combine(docPath, folder, file)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Vloga>));

                using (StreamReader reader = new StreamReader(Path.Combine(docPath, folder, file)))
                {
                    vloge = (List<Vloga>)serializer.Deserialize(reader);
                }
            }

            return vloge;

        }

        public static List<Vloga> ReadFileForUser(int Id)
        {

            List<Vloga> vloge = ReadFile();

            return vloge.Where(v => v.UserId == Id).ToList();

        }

    }
}

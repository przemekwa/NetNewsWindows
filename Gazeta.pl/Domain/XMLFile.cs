
using gazetaNews;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Gazeta.pl.Domain
{
    public static class XMLFile
    {
        public static void TypeToXML<T>(this T ob, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));

            using (var file = new StreamWriter(fileName))
            {
                xml.Serialize(file, ob);
            }
        }

        public static T XMLToType<T>(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));

            T rezult;

            using (var textReader = new StreamReader(fileName))
            {
                rezult = (T)xml.Deserialize(textReader);
            }

            return rezult;


        }
    }
}

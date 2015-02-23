

using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Gazeta.pl.Domain
{
    public static class XMLFile
    {
        public static void TypeToXML<T>(this T ob)
        {
            var fileName = typeof(T).Name + ".xml";

            var type = ob.GetType();

            XmlSerializer xml = new XmlSerializer(type);

                       
            using (var file = new StreamWriter(fileName))
            {
                xml.Serialize(file, ob);
            }
        }

        public static T XMLToType<T>()
        {
            var fileName = typeof(T).Name + ".xml";
            
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

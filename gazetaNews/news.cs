using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gazetaNews
{
    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(News))]
    [System.Xml.Serialization.XmlInclude(typeof(EmptyNews))]
    public abstract class NewsData
    {
        public abstract bool isNull { get;}
        
        public string link { get; set; }
        public DateTime czasZapisania { get; set; }
        public string naglowek { get; set; }
        public string obrazek_link { get; set; }
        public string opis { get; set; }
        public byte[] hash { get; set; }
    }
    
    public class News : NewsData
    {
        public override bool isNull { get { return false; } }
    }

    public class EmptyNews : NewsData
    {
        public override bool isNull { get { return true; } }  
    }
    
}

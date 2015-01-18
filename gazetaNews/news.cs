using NetNewsWindowsPluginDomain;

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
    public abstract class NewsData : INews
    {
        public abstract bool isNull { get;}
        
        public string link { get; set; }
        public DateTime czasZapisania { get; set; }
        public string naglowek { get; set; }
        public string obrazek_link { get; set; }
        public string opis { get; set; }
        public byte[] hash { get; set; }

        public string NewsUrl
        {
            get { return this.link; }
        }

        public string Header
        {
            get { return this.naglowek; }
        }

        public string News
        {
            get { return this.opis; }
        }

        public string ImgUrl
        {
            get { return this.obrazek_link; }
        }


        public DateTime TimeUpdate
        {
            get { return this.czasZapisania; }
        }
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

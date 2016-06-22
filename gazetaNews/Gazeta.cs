namespace gazetaNews
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.Composition;
    using NetNewsWindowsPluginDomain;


    [Export(typeof(INewsPlugin))]
    public class Gazeta : INewsPlugin
    {
        private HtmlDocument doc;

        public Gazeta()
        {
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-2")
            };

            this.doc = new HtmlDocument();

            doc = web.Load("http://www.gazeta.pl/0,0.html");
        }


        public Message PobierzWiadomośćNaŻywo()
        {
            var mainDivTag = doc.DocumentNode.SelectSingleNode("//div[@class=\"col-md-12 col-sm-12 col-xs-12 slider_area two_themes\"]");

            var f = mainDivTag.SelectSingleNode("a[@class=\"cutter_pict_layer pict_container\"]");


            return null;
        }

        public bool IsLiveMessage() => doc.DocumentNode.SelectSingleNode("//div[@class=\"mammoth_head\"]") != null;

        public Message PobierzWiadomosc()
        {
            var lista = new List<Message>();

            var mainDivTag = doc.DocumentNode.SelectSingleNode("//div[@class=\"mt_pict_layer\"]");

            if (mainDivTag == null)
            {
                return new Message();
            }

            var linkTag = mainDivTag.SelectSingleNode("a");

            if (linkTag == null)
            {
                return new Message();
            }

            var imgTag = linkTag.SelectSingleNode("img");

            if (imgTag == null)
            {
                return new Message();
            }


            var wiadomosc = new Message();

            wiadomosc.NewsUrl = linkTag.GetAttributeValue("href", "brak");

            wiadomosc.Header = linkTag.GetAttributeValue("title", "brak");

            wiadomosc.ImgUrl = imgTag.GetAttributeValue("src", "");

            wiadomosc.TimeUpdate = System.DateTime.Now;

            wiadomosc.News = linkTag.GetAttributeValue("title", "brak");

            return wiadomosc;
        }

        public IEnumerable<Message> GetNews()
        {
            var result = new List<Message>();

            if (this.IsLiveMessage())
            {
                result.Add(this.PobierzWiadomośćNaŻywo());
            }

            result.Add(this.PobierzWiadomosc());

            return result;
        }
    }
}

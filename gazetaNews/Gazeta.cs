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
        public Message PobierzWiadomosc()
        {
            var lista = new List<Message>();

            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-2")
            };

            HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load("http://www.gazeta.pl/0,0.html");
            }
            catch
            {
                return null;
            }

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
            yield return this.PobierzWiadomosc();
        }
    }
}

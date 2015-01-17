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
        public NewsData PobierzWiadomosc()
        {
            var lista = new List<News>();

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
                    return new EmptyNews();
                }

                var nagłowek = doc.DocumentNode.SelectSingleNode("//div[@class=\"col-md-8 col-sm-8 col-xs-12 mt_pict\"]/h2/a/span[@class=\"title\"]");
                
                if (nagłowek != null)
                {
                    var obrazek = doc.DocumentNode.SelectSingleNode("//div[@class=\"mt_pict_layer\"]/a[@id=\"LinkArea:MT\"]/img");

                    if (obrazek != null)
                    {
                        var opis = doc.DocumentNode.SelectSingleNode("//div[@class=\"mt_txt_layer\"]/p/a[@id=\"LinkArea:MT\"]");

                        if (opis != null)
                        {
                            var wiadomosc = new News();

                            wiadomosc.link = opis.GetAttributeValue("href", "brak");

                            wiadomosc.naglowek = nagłowek.InnerText;

                            wiadomosc.obrazek_link = obrazek.GetAttributeValue("src", "");

                            wiadomosc.czasZapisania = System.DateTime.Now;

                            wiadomosc.opis = opis.InnerHtml;

                            wiadomosc.hash = CheckSum.Create(wiadomosc.link);

                            return wiadomosc;
                        }
                    }
                }
                return new EmptyNews();
            
        }

        public IEnumerable<INews> GetNews()
        {
            yield return this.PobierzWiadomosc();
        }
    }
}

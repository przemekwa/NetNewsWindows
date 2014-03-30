using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gazetaNews
{
    public class Gazeta : IGazetaNews
    {
        public List<news> PobierzWiadomosci()
        {

            var lista = new List<news>();

            using (var plikHtm = new HTMLtoFile("http://www.gazeta.pl/0,0.html"))
            {
                HtmlDocument doc = new HtmlDocument();
                
                doc.Load(plikHtm.ConvertHTMLtoFile());

                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    if (link.Id == "LinkArea:MT")
                    {
                        var wiadomosc = new news();

                        wiadomosc.tytul = link.GetAttributeValue("title", "brak");

                        wiadomosc.link = link.GetAttributeValue("href", "brak");

                        wiadomosc.tresc = link.InnerText;

                        wiadomosc.czasZapisania = System.DateTime.Now;

                        lista.Add(wiadomosc);
                        
                      }
                }
                return lista;
            }
        }

    }
}

namespace gazetaNews
{
    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Gazeta : IGazetaNews
    {
        public List<news> PobierzWiadomosci()
        {
            var lista = new List<news>();

            using (var plikHtm = new HTMLtoFile("http://www.gazeta.pl/0,0.html"))
            {
                HtmlDocument doc = new HtmlDocument();
                
                doc.Load(plikHtm.ConvertHTMLtoFile());

                var nagłowek = doc.DocumentNode.SelectSingleNode("//div[@class=\"c0 wide\"]/header/h1/a");
                
                if (nagłowek != null)
                {
                    var obrazek = doc.DocumentNode.SelectSingleNode("//div[@class=\"imgw\"]/a[@id=\"LinkArea:MT\"]/img");

                    if (obrazek != null)
                    {
                        var opis = doc.DocumentNode.SelectSingleNode("//div[@class=\"lead\"]/p/span/a[@id=\"LinkArea:MT\"]");

                        if (opis != null)
                        {
                            var wiadomosc = new news();

                            wiadomosc.link = nagłowek.GetAttributeValue("href", "brak");

                            wiadomosc.naglowek = nagłowek.InnerText;

                            wiadomosc.obrazek_link = obrazek.GetAttributeValue("src", "");

                            wiadomosc.czasZapisania = System.DateTime.Now;

                            wiadomosc.opis = opis.InnerHtml;

                            lista.Add(wiadomosc);
                        }
                    }


                    
                }




                //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//span"))
                //{
                //    if (link.GetAttributeValue("class","") == "text")
                //    {
                //        HtmlNode h = link.SelectSingleNode("a");
                        
                //        var wiadomosc = new news();

                //        wiadomosc.link = h.GetAttributeValue("href", "brak");

                //        wiadomosc.tresc = h.InnerText;

                //        wiadomosc.czasZapisania = System.DateTime.Now;

                //        foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//a[@id='LinkArea:MT']/img"))
                //        {
                //            wiadomosc.obrazek_link = img.GetAttributeValue("src", "");
                //        }


                //        lista.Add(wiadomosc);
                //    }
                //}

                

          

                return lista;
            }
        }

    }
}

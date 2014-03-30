using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace gazetaNews
{
    class HTMLtoFile : IDisposable
    {
        public string nazwaPliku { get; set; }

        string adresStronyKlasa { get; set; }


        public HTMLtoFile(string adresStrony)
        {
            nazwaPliku = Path.GetRandomFileName();
            adresStronyKlasa = adresStrony;
        }

        public string ConvertHTMLtoFile() 
        {
            WebClient webClient = new WebClient();
           
            webClient.DownloadFile(adresStronyKlasa, nazwaPliku);


            return nazwaPliku;
        }

        public void Dispose()
        {
            File.Delete(this.nazwaPliku);
        }


    }
}

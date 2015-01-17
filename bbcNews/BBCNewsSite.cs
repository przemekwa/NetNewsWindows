using HtmlAgilityPack;
using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbcNews
{
      [Export(typeof(INewsPlugin))]
    public class BBCNewsSite : INewsPlugin
    {
        public IEnumerable<INews> GetNews()
        {
            return new List<INews>();
        }

        private INews BBCNewsBuldier(MainNewsBuldier newsBuldier)
        {
             HtmlWeb web = new HtmlWeb();
             HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load("http://www.bbc.com/");
            }
            catch
            {
                return new BBCNews();
            }

            return newsBuldier.Build(doc.DocumentNode);
        }
    }
}

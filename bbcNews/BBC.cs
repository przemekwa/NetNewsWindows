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
    public class BBC : INewsPlugin
    {
        internal static readonly Uri BBCUrl = new Uri("http://www.bbc.com/");

        public IEnumerable<INews> GetNews()
        {
            var rezult = new List<INews>();

            rezult.Add(this.BBCNewsBuldier(new MainNewsBuldier()));

            return rezult;
        }

        private INews BBCNewsBuldier(MainNewsBuldier newsBuldier)
        {
             HtmlWeb web = new HtmlWeb();
             HtmlDocument doc = new HtmlDocument();

            try
            {
                doc = web.Load(BBCUrl.ToString());
            }
            catch
            {
                return new BBCNews();
            }

            return newsBuldier.Build(doc.DocumentNode);
        }
    }
}

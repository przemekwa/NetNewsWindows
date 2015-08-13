using HtmlAgilityPack;
using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bbcNews
{
    class MainNewsBuldier : INewsBuldier
    {
        private Message news = new Message();

        public Message Build(HtmlNode html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            var aMarkup = html.SelectSingleNode("//div[@class=\"media__content\"]/h3/a");

            if (aMarkup == null)
            {
                return null;
            }

            news.Header = aMarkup.InnerText;

            news.NewsUrl = new Uri(BBC.BBCUrl, aMarkup.GetAttributeValue("href", "empty")).ToString();

            var imgMarkup = aMarkup.SelectSingleNode("//div[@class=\"delayed-image-load\"]/img");

            if (imgMarkup == null)
            {
                return null;
            }

            news.ImgUrl = imgMarkup.GetAttributeValue("src", "empty");


            var pMarkup = html.SelectSingleNode("//div[@class=\"media__content\"]/p[@class=\"media__summary\"]");

            if (pMarkup == null)
            {
                return null;
            }

            news.News = pMarkup.InnerText;

            news.TimeUpdate = DateTime.Now;

            var ownerImgUrl = html.SelectSingleNode("//abbr/img");

            news.OwnerImgUrl = "http://static.bbci.co.uk/frameworks/barlesque/2.84.11/orb/4/img/bbc-blocks-light.png";//ownerImgUrl.GetAttributeValue("src","empty");

            return news;

        }
    }
}

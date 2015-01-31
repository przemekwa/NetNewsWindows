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
        private BBCNews news = new BBCNews();

        public INews Build(HtmlNode html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            var aMarkup = html.SelectSingleNode("//div[@class=\"promo module2 clearfix\"]/div/a");

            if (aMarkup == null)
            {
                return null;
            }

            news.Header = aMarkup.GetAttributeValue("title", "empty");

            news.NewsUrl = new Uri(BBC.BBCUrl, aMarkup.GetAttributeValue("href", "empty")).ToString();

            var imgMarkup = aMarkup.SelectSingleNode("./img");

            if (imgMarkup == null)
            {
                return null;
            }

            news.ImgUrl = imgMarkup.GetAttributeValue("src", "empty");


            var pMarkup = html.SelectSingleNode("//div[@class=\"promo module2 clearfix\"]/div/p[@class=\"hero_summary\"]");

            if (pMarkup == null)
            {
                return null;
            }

            news.News = pMarkup.InnerText;

            news.TimeUpdate = DateTime.Now;

            var ownerImgUrl = html.SelectSingleNode("//abbr/img");

            news.OwnerImgUrl = ownerImgUrl.GetAttributeValue("src","empty");

            return news;

        }
    }
}

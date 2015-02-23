using HtmlAgilityPack;
using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbcNews
{
    interface INewsBuldier
    {
        Message Build(HtmlNode htmlNode);
    }
}

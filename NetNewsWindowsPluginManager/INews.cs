using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    public interface INews
    {
        string NewsUrl { get; }
        string Header { get; }
        string News { get; }
        string ImgUrl { get; }
    }
}

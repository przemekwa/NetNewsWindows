using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginDomain
{
    public interface INews 
    {
        string NewsUrl { get; }
        string Header { get; }
        string News { get; }
        string ImgUrl { get; }
        DateTime TimeUpdate { get; }
        string OwnerImgUrl { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    public interface INewsPlugin
    {
        IEnumerable<INews> GetNews();
    }
}

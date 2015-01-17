using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    public class PluginManager : IPluginManager
    {
        public IEnumerable<INews> GetNews()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<INewsPlugin> GetNewsPlugins()
        {
            return new List<INewsPlugin>();
        }
    }
}

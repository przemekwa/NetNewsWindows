using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    class PluginInterfaceBuilder
    {
        [ImportMany(typeof(INewsPlugin))]
        public IEnumerable<INewsPlugin> Plugins { get; set; }
    }
}

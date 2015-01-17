using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginManager
{
    public class PluginInterfaceBuilder
    {
        [ImportMany(typeof(INewsPlugin))]
        public IEnumerable<INewsPlugin> Plugins { get; set; }
    }
}

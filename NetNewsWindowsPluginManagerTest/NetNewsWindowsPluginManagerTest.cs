using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetNewsWindowsPluginManagerTest
{
    [TestClass]
    public class NetNewsWindowsPluginManagerTest
    {
        [TestMethod]
        public void TestPluginManagerLoadAssembly()
        {
            var pm = new NetNewsWindowsPluginManager.PluginManager();

            Assert.AreNotEqual(null, pm);
        }
    }
}

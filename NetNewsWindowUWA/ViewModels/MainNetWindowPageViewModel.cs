using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;

namespace NetNewsWindowUWA.ViewModels
{
    public class MainNetWindowPageViewModel : ViewModelBase
    {
        private string test;

        public string onOff
        {
            get { return test; }
            set { this.SetProperty<string>(ref test, value); }
        }

    }
}

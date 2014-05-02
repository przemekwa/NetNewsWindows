using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Gazeta.pl.Applications.Views;
using System.Collections.ObjectModel;
using Gazeta.pl;
using gazetaNews;
using System.Timers;
using System.Windows.Threading;
using Gazeta.pl.Domain;
using System.Collections;

namespace Gazeta.pl.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;
        private readonly DelegateCommand startStopCommand;
        
        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            this.KolekcjaWiadomosci = new ObservableCollection<NewsData>();

            onOff = onoff.Wyłączony.ToString();
            exitCommand = new DelegateCommand(Close);
            startStopCommand = new DelegateCommand(WypelnijListe);
        }


        public string Title { get { return ApplicationInfo.ProductName; } }

        public ICommand ExitCommand { get { return exitCommand; } }

        public ICommand startStop { get { return startStopCommand; } }

        string _onOff {get; set;}


        DispatcherTimer dt = new DispatcherTimer();

        public string onOff
        {
            get
            {
                return _onOff;
            }

            set
            {
                _onOff = value;
                RaisePropertyChanged("onOff");
            }
        }


        string _czas { get; set; }

        public string Czas {
            get
            {
                return _czas;
            }

            set
            {
                _czas = value;
                RaisePropertyChanged("Czas");
            }
        }

        public ObservableCollection<NewsData> KolekcjaWiadomosci { get; set; }
        

        public void Show()
        {
            ViewCore.Show();
        }

        private void Close()
        {
            ViewCore.Close();
        }


        private void StartStop()
        {

        }

        public void WypelnijListe()
        {
            if (dt.IsEnabled)
            {
                dt.Stop();
                onOff = onoff.Wyłączony.ToString();
            }
            else
            {
                dt.Interval = new System.TimeSpan(0, 10, 0);

                dt.Tick += dt_Tick;

                dt.Start();
                dt_Tick(new object(), new System.EventArgs());

                
                onOff = onoff.Włączony.ToString();
            }
        }

        void dt_Tick(object sender, System.EventArgs e)
        {
            gazetaNews.Gazeta gazeta = new gazetaNews.Gazeta();

            Czas = System.DateTime.Now.ToString("HH:mm:ss");
          
            var wiadomosc = gazeta.PobierzWiadomosc();

            if (!wiadomosc.isNull)
            {
                bool czyJest = false;

                foreach (var k in KolekcjaWiadomosci)
                {
                    if (!StructuralComparisons.StructuralEqualityComparer.Equals(k.hash, wiadomosc.hash))
                    {
                        czyJest = true;
                    }
                }

                if (!czyJest)
                {
                    KolekcjaWiadomosci.Add(wiadomosc);
                }
            }
        }
    }
}

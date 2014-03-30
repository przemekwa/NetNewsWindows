using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Gazeta.pl.Applications.Views;
using System.Collections.ObjectModel;
using Gazeta.pl;
using gazetaNews;
using System.Timers;
using System.Windows.Threading;

namespace Gazeta.pl.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;


        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            this.KolekcjaWiadomosci = new ObservableCollection<news>();
            
            WypelniListe();
            exitCommand = new DelegateCommand(Close);
        }


        public string Title { get { return ApplicationInfo.ProductName; } }

        public ICommand ExitCommand { get { return exitCommand; } }

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

        public ObservableCollection<news> KolekcjaWiadomosci { get; set; }




        public void Show()
        {
            ViewCore.Show();
        }

        private void Close()
        {
            ViewCore.Close();
        }


        public void WypelniListe()
        {
          


            DispatcherTimer dt = new DispatcherTimer();
            
            dt.Interval = new System.TimeSpan(0, 0, 5);

            dt.Tick += dt_Tick;

            dt.Start();

          
            


          
        }

        void dt_Tick(object sender, System.EventArgs e)
        {
            gazetaNews.Gazeta gazeta = new gazetaNews.Gazeta();

            Czas = System.DateTime.Now.ToString("HH:mm:ss");
          

            KolekcjaWiadomosci.Clear();


            gazeta.PobierzWiadomosci().ForEach(wiadomosc => KolekcjaWiadomosci.Add(wiadomosc));
        }

       
    }
}

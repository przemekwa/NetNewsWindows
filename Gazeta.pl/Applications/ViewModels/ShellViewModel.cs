using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Gazeta.pl.Applications.Views;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Gazeta.pl.Domain;
using System.Collections;
using System.Collections.Generic;
using Growl.Connector;
using System.Drawing;
using NetNewsWindowsPluginManager;
using NetNewsWindowsPluginDomain;
using System.Linq;

namespace Gazeta.pl.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;
        private readonly DelegateCommand startStopCommand;
        private readonly DelegateCommand ReadXMLFileCommand;
        private readonly DelegateCommand RefreshCommand;

        private GrowlConnector growl;

        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            this.KolekcjaWiadomosci = new ObservableCollection<INews>();

            onOff = onoff.Wyłączony.ToString();
            naŻywo = false;
            exitCommand = new DelegateCommand(Close);
            startStopCommand = new DelegateCommand(WypelnijListe);
            ReadXMLFileCommand = new DelegateCommand(WczytajXML);
            RefreshCommand = new DelegateCommand(Odswiez);
            
            
            this.growl = new GrowlConnector();


            Application app = new Application("Gazeta.pl");

        }


        public string Title { get { return "Net News Windows"; } }

        public ICommand ExitCommand { get { return exitCommand; } }

        public ICommand startStop { get { return startStopCommand; } }

        public ICommand WczytajPlik { get { return ReadXMLFileCommand; } }

        public ICommand Odśwież { get { return RefreshCommand; } }


        private short pluginNumber;

        public short PluginNumber
        {
            get
            {
                return pluginNumber;
            }

            set
            {
                pluginNumber = value;
                RaisePropertyChanged("PluginNumber");
            }
        }


        string _onOff {get; set;}

        bool _naŻywo { get; set; }


        

        public bool naŻywo
        {
            get
            {
                return _naŻywo;
            }

            set
            {
                _naŻywo = value;
                RaisePropertyChanged("naŻywo");
            }
        }


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

        public ObservableCollection<INews> KolekcjaWiadomosci { get; set; }
        

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

        public void Odswiez()
        {
            dt_Tick(null, new System.EventArgs());
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

        void WczytajXML()
        {
            var wiadomosci = XMLFile.XMLToType<ObservableCollection<INews>>();

            foreach (var w in wiadomosci)
            {
                KolekcjaWiadomosci.Add(w);
            }
        }

        
        void dt_Tick(object sender, System.EventArgs e)
        {
            Czas = System.DateTime.Now.ToString("HH:mm:ss");

            var pluginManager = new PluginManager();

            this.PluginNumber = (short)pluginManager.GetNewsPlugins().Count();

            var czyJest = false;

            foreach (var news in pluginManager.GetNews())
            {
                if (news == null || string.IsNullOrEmpty(news.ImgUrl))
                {
                    continue;
                }

                foreach (var k in KolekcjaWiadomosci)
                {

                        if (StructuralComparisons.StructuralEqualityComparer.Equals(k.ImgUrl.GetHashCode(), news.ImgUrl.GetHashCode()))
                        {
                            czyJest = true;
                        }

                        if (naŻywo && czyJest)
                        {
                            czyJest = false;
                        }
                }


                if (!czyJest)
                {
                    KolekcjaWiadomosci.Insert(0, news);
                }


            }

           // XMLFile.TypeToXML<ObservableCollection<INews>>(KolekcjaWiadomosci);




           



        //    gazetaNews.Gazeta gazeta = new gazetaNews.Gazeta();

            


          
        //    var wiadomosc = gazeta.PobierzWiadomosc();

        //    if (!wiadomosc.isNull)
        //    {
        //        bool czyJest = false;

        //        foreach (var k in KolekcjaWiadomosci)
        //        {
        //            if (StructuralComparisons.StructuralEqualityComparer.Equals(k.hash, wiadomosc.hash))
        //            {
        //                czyJest = true;
        //            }

        //            if (naŻywo)
        //            {
        //                if (k.obrazek_link != wiadomosc.obrazek_link)
        //                {
        //                    czyJest = false;
        //                }
        //            }
        //        }

              

                
               
        //        if (!czyJest)  
        //        {
        //            KolekcjaWiadomosci.Insert(0, wiadomosc);

        //            Notification notification = new Notification("Gazeta.pl", "Test2", wiadomosc.czasZapisania.ToString(), wiadomosc.naglowek, wiadomosc.opis);
                 
        //            growl.Notify(notification);

                    
        //            XMLFile.TypeToXML<ObservableCollection<NewsData>>(KolekcjaWiadomosci);
        //        }
        //    }
        
            }
       
    }
}

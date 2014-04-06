using System.ComponentModel.Composition;
using System.Windows;
using Gazeta.pl.Applications.Views;
using System.Windows.Navigation;
using System.Diagnostics;

namespace Gazeta.pl.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}

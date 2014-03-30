using System.ComponentModel.Composition;
using System.Windows;
using Gazeta.pl.Applications.Views;

namespace Gazeta.pl.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}

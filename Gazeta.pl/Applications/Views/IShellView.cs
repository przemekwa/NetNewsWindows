using System.Waf.Applications;

namespace Gazeta.pl.Applications.Views
{
    internal interface IShellView : IView
    {
        void Show();

        void Close();
    }
}

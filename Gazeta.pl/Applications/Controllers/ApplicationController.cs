using System.ComponentModel.Composition;
using Gazeta.pl.Applications.ViewModels;

namespace Gazeta.pl.Applications.Controllers
{
    [Export]
    internal class ApplicationController
    {
        private readonly ShellViewModel shellViewModel;


        [ImportingConstructor]
        public ApplicationController(ShellViewModel shellViewModel)
        {
            this.shellViewModel = shellViewModel;
        }

        public void Initialize()
        {
        }

        public void Run()
        {
            shellViewModel.Show();
        }

        public void Shutdown()
        {
        }
    }
}

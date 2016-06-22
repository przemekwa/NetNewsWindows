using Prism.Unity.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Prism.Mvvm;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NetNewsWindowUWA
{
    sealed partial class App : PrismUnityApplication
    {
        /// <summary>    
        /// Initializes the singleton application object.  This is the first line of authored code    
        /// executed, and as such is the logical equivalent of main() or WinMain().    
        /// </summary>    
        public App()
        {
            this.InitializeComponent();
            base.Suspending += OnSuspending;
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);

            Window.Current.Activate();

            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            RegisterTypes();
            return base.OnInitializeAsync(args);
        }

        private void RegisterTypes()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(System.Globalization.CultureInfo.InvariantCulture, "MyPrismApp.ViewModels.{0}ViewModel, MyPrismApp", viewType.Name);
                var viewModelType = Type.GetType(viewModelTypeName);
                return viewModelType;
            });
        }

        /// <summary>    
        /// Invoked when Navigation to a certain page fails    
        /// </summary>    
        /// <param name="sender">The Frame which failed navigation</param>    
        /// <param name="e">Details about the navigation failure</param>    
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>    
        /// Invoked when application execution is being suspended.  Application state is saved    
        /// without knowing whether the application will be terminated or resumed with the contents    
        /// of memory still intact.    
        /// </summary>    
        /// <param name="sender">The source of the suspend request.</param>    
        /// <param name="e">Details about the suspend request.</param>    
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity    
            deferral.Complete();
        }
    }
}

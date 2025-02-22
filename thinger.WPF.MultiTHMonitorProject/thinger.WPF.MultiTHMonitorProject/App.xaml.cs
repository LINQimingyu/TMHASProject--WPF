using System.Configuration;
using System.Data;
using System.Windows;
using thinger.WPF.MultiTHMonitorProject.Views;

namespace thinger.WPF.MultiTHMonitorProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }

}

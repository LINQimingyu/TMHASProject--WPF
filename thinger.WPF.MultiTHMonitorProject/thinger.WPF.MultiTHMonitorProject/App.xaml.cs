using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using thinger.WPF.MultiTHMonitorProject.Command;
using thinger.WPF.MultiTHMonitorProject.ViewModels;
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
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<MonitorView, MonitorViewModel>();
            containerRegistry.RegisterForNavigation<ParamSetView, ParamSetViewModel>();
            containerRegistry.RegisterForNavigation<RecipeView, RecipeViewModel>();
            containerRegistry.RegisterForNavigation<AlarmView, AlarmViewModel>();
            containerRegistry.RegisterForNavigation<HistoryView, HistoryViewModel>();
            containerRegistry.RegisterForNavigation<UserManageView, UserManageViewModel>();
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }
            });
            //通过自定义的配置服务接口，获取需要显示的内容和用户名
            var service = App.Current.MainWindow.DataContext as IConfigureService;
            if (service != null)
            {
                service.Configure();
            }
            base.OnInitialized();
        }
    }
}

using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.WPF.MultiTHMonitorProject.Command;

namespace thinger.WPF.MultiTHMonitorProject.ViewModels
{
    public class MainViewModel : IConfigureService
    {
        private readonly IRegionManager _regionManager;

        public MainViewModel(IRegionManager regionManager)
        {
            OpenViewCommand = new DelegateCommand<string>(OpenView);
            this._regionManager = regionManager;
        }



        #region 命令属性
        public DelegateCommand<string> OpenViewCommand { get; private set; }


        #endregion

        private void OpenView(string obj)
        {
            //通过区域去设置需要显示的内容
            _regionManager.Regions["ContentRegion"].RequestNavigate(obj);
        }

        public void Configure()
        {
            _regionManager.Regions["ContentRegion"].RequestNavigate("MonitorView");
        }
    }
}

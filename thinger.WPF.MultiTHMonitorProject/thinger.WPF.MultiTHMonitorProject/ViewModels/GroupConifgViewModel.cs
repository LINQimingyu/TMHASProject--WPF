using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.WPF.MultiTHMonitorProject.ViewModels
{
    public class GroupConifgViewModel : IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("GroupViewValue", "关闭组配置窗口!!");
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("ShowGroupViewParam");
        }
    }
}

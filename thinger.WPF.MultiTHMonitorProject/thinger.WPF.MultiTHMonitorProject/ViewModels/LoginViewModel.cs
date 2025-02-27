using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using thinger.WPF.MultiTHMonitorBLL;
using thinger.WPF.MultiTHMonitorModels.SQL;
using thinger.WPF.MultiTHMonitorProject.Command;

namespace thinger.WPF.MultiTHMonitorProject.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel()
        {
            LogoutCommand = new DelegateCommand<string>(ExeCloseLogin);
            LoginCommand = new DelegateCommand<object>(ExeLogin);
        }



        public DelegateCommand<string> LogoutCommand { get; private set; }
        public DelegateCommand<object> LoginCommand { get; private set; }


        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; RaisePropertyChanged(); }
        }

        private string loginPwd;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; RaisePropertyChanged(); }
        }

        private string loginTip;

        public event Action<IDialogResult> RequestClose;

        public string LoginTip
        {
            get { return loginTip; }
            set { loginTip = value; RaisePropertyChanged(); }
        }

        public string Title { get; set; }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="obj"></param>
        private void ExeCloseLogin(string obj)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="obj"></param>
        private void ExeLogin(object obj)
        {
            if (string.IsNullOrWhiteSpace(LoginName) || string.IsNullOrWhiteSpace(LoginPwd))
            {
                LoginTip = "**用户密码或密码不能为空!!!!";
                return;
            }
            else
            {
                //封装对象 
                SysAdmin sysAdmin = new SysAdmin()
                {
                    LoginName = LoginName,
                    LoginPwd = LoginPwd
                };
                //用户查询
                sysAdmin = new SysAdminManage().AdminLogin(sysAdmin);
                if (sysAdmin == null)
                {
                    LoginTip = "**用户名或密码错误，请重新输入!!!";
                    LoginName = "";
                    LoginPwd = "";
                    return;
                }
                else
                {
                    LoginTip = "";
                    //MessageBox.Show("登录成功!!!");
                    CommonMethods.CurrentAdmin = sysAdmin;
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}

using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace thinger.WPF.MultiTHMonitorProject.Command
{
    public  class PasswordExtention
    {


        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordExtention), new PropertyMetadata(string.Empty,OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //依赖对象转换为密码框
            var password = d as PasswordBox;
            //获取参数中的新值并转换为字符串
            string pwd = e.NewValue as string;
            //如果新值不为空，并且密码框中的密码不等于新值，那么就把pwd赋值给密码框依赖的对象中的密码属性的值。
            if (password != null && password.Password != pwd)
            {

            }

        }
    }
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            //关联对象事件绑定，触发密码变化操作。
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            //通过密码扩展类获取密码的值
            string password = PasswordExtention.GetPassword(passwordBox);
            //判断密码框对象和密码是否为空，如果不为空，将其设置给密码扩展对象
            if (passwordBox != null && passwordBox.Password != password)
            {
                PasswordExtention.SetPassword(passwordBox, passwordBox.Password);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }
    }
}

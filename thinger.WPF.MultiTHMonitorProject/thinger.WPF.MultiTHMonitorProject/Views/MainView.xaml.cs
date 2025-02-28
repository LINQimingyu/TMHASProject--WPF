using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using thinger.WPF.MultiTHMonitorModels;
using thinger.WPF.MultiTHMonitorProject.Events;

namespace thinger.WPF.MultiTHMonitorProject.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public MainView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            MoveColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            eventAggregator.GetEvent<DeviceMessageEvent>().Subscribe(DevSubMessage);

            btnClose.Click += (s, e) => this.Close();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += StoreTimer_Elapsed;
            timer.Start();
        }

        private void StoreTimer_Elapsed(object sender, EventArgs e)
        {
            this.SysTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("HH:mm:ss") + " " + week;
        }

        private string[] weeks = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        private string week
        {
            get { return weeks[Convert.ToInt32(DateTime.Now.DayOfWeek)]; }
        }

        private void DevSubMessage(object obj)
        {
            Device device = (Device)obj;
            if (device != null)
            {
                if (device.IsConnected)
                {
                    SolidColorBrush solidColorBrush = new SolidColorBrush();
                    solidColorBrush.Color = Color.FromRgb(1, 192, 200);
                    this.ConnectStatusLed.Background = solidColorBrush;

                    DropShadowEffect dropShadowEffect = new DropShadowEffect();
                    dropShadowEffect.Color = Color.FromRgb(1, 192, 200);
                    dropShadowEffect.ShadowDepth = 0;
                    dropShadowEffect.BlurRadius = 10;
                    this.ConnectStatusLed.Effect = dropShadowEffect;
                }
                else
                {
                    SolidColorBrush solidColorBrush = new SolidColorBrush();
                    solidColorBrush.Color = Colors.Red;
                    this.ConnectStatusLed.Background = solidColorBrush;

                    DropShadowEffect dropShadowEffect = new DropShadowEffect();
                    dropShadowEffect.Color = Colors.Red;
                    dropShadowEffect.ShadowDepth = 0;
                    dropShadowEffect.BlurRadius = 10;
                    this.ConnectStatusLed.Effect = dropShadowEffect;
                }
            }
        }
    }
}

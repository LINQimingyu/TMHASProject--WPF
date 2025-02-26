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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace thinger.WPF.MultiTHMonitorProject.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public MainView()
        {
            InitializeComponent();
            MoveColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

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


    }
}

using MaterialDesignThemes.Wpf;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(9000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
           
        }

        int progress = 1;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (progress != 100)
            {
                ButtonProgressAssist.SetValue(LoginButton, progress);
                progress += 1;
            }
            else
            {
                (sender as DispatcherTimer).Stop();
                Window3 wind = new Window3();
                wind.Show();
                this.Close();
               
            }

        }
    }
}

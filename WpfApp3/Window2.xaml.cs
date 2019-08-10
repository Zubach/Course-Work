using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Context context = new Context();

       
        
        public Window2()
        {
            InitializeComponent();



           
        }

        User foundUser = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool TrueAccount = false;
            
            foreach(var item in context.Users)
            {
                if(item.Login == LoginTextBox.Text && item.Password == Password.Password)
                {
                    TrueAccount = true;
                    foundUser = item;
                }
            }

            if (TrueAccount)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(9000);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            else
            {
                Info.Text = "Wrong password or login";
            }
           
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
                Window3 wind = new Window3(foundUser);
               
                wind.Show();

                context.SaveChanges();
                this.Close();
               
            }

        }
    }
}

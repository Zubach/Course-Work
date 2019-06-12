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

        public List<User> users = new List<User>()
        {
           
        };
        
        public Window2()
        {
            InitializeComponent();

            

           
            using (FileStream fs = new FileStream("Accounts.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                users = formatter.Deserialize(fs) as List<User>;
               // formatter.Serialize(fs, users);
            }
        }

        public Window2(User user)
        {
            InitializeComponent();


            using (FileStream fs = new FileStream("Accounts.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                users = formatter.Deserialize(fs) as List<User>;
                // formatter.Serialize(fs, users);
            }


            if (user != null)
            {
                users.Add(user);
            }
        }

        User foundUser = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool TrueAccount = false;
            
            foreach(var item in users)
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
                Window3 wind = new Window3(foundUser,users);
               
                wind.Show();
                this.Close();
               
            }

        }
    }
}

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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для StatsPassLogin.xaml
    /// </summary>
    public partial class StatsPassLogin : Window
    {
        
        Window3 parent = null;
        public StatsPassLogin()
        {
            InitializeComponent();
        }

        public StatsPassLogin(Window3 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            //foreach(var site in parent.user.sites)
            //{
            //    if(site.Login == login.Text && site.Password == password.Text)
            //    {
            //        counter++;
            //    }
            //}

            CountTextBlock.Text = "Count of matches: " + counter;
        }
    }
}

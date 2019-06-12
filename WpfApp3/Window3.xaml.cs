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
    /// Interaction logic for Window3.xaml
    /// </summary>
    /// 
    public partial class Window3 : Window

    {

        public User user = null;
        
        public Window3()
        {

            
            InitializeComponent();

            
        }

        public Window3(User user)
        {


            InitializeComponent();
            this.user = user;

            ListView.ItemsSource = user.sites;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window5 wind = new Window5(this);
            wind.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           Site site = ListView.SelectedItem as Site;
            if(site != null)
            {
                Window5 wind = new Window5(this,site);
                wind.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window6 wind = new Window6(this);
            wind.Show();
        }
    }
}

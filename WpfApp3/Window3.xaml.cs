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
        List<Site> sites = new List<Site>()
        {
            new Site("Google","google.com","Just google","vanyakage@gmail.com","dabdaya")
        };
        public Window3()
        {

            
            InitializeComponent();

            ListView.ItemsSource = sites;
        }
    }
}

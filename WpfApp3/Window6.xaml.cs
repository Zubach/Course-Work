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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {

        Window3 parent = null;


        List<Site> sites = new List<Site>();

        public Window6()
        {
            InitializeComponent();
        }

        public Window6(Window3 parent)
        {
            InitializeComponent();


            sites.AddRange(parent.user.sites);

            ListView.ItemsSource = sites;
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            sites.Clear();
            sites.AddRange(parent.user.sites);


            if (ByName.IsChecked.Value)
            {
                for(int i = 0; i < sites.Count;i++)
                    if(sites[i].Name != NameTextBox.Text)
                    {
                        sites.RemoveAt(i);
                        i--;
                    }
                
            }
            if (ByLogin.IsChecked.Value)
            {
                for (int i = 0; i < sites.Count; i++)
                    if (sites[i].Login != LoginTextBox.Text)
                    {
                        sites.RemoveAt(i);
                        i--;
                    }
            }
            if (ByUrl.IsChecked.Value)
            {
                for (int i = 0; i < sites.Count; i++)
                    if (sites[i].Url != UrlTextBox.Text)
                    {
                        sites.RemoveAt(i);
                        i--;
                    }
            }
            if (ByColl.IsChecked.Value)
            {
                for (int i = 0; i < sites.Count; i++)
                    if (!sites[i].Description.Contains(CollocationTextBox.Text))
                    {
                        sites.RemoveAt(i);
                        i--;
                    }
            }

            


            ListView.Items.Refresh();



        }
    }
}

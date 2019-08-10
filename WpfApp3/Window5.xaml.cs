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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {

        Site site = null;

        Window3 parent = null;

        public Window5()
        {
            InitializeComponent();
        }

        public Window5(Window3 parent,Site site)
        {
            InitializeComponent();
            this.site = site;


            NameTextBox.Text = site.Name;
            LoginTextBox.Text = site.Login;
            Password.Password = site.Password;
            UrlTextBox.Text = site.Url;
            Description.Text = site.Description;

            this.parent = parent;
           
            
        }

        public Window5(Window3 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(site != null)
            {

               

              var editSite =  parent.context.Sites.Where(s=> s.Name == site.Name && s.Login == site.Login && s.Password == site.Password && s.Description == site.Description).FirstOrDefault();
                
                editSite.Name = NameTextBox.Text;
                editSite.Login = LoginTextBox.Text;
                editSite.Password = Password.Password;
                editSite.Url = UrlTextBox.Text;
                editSite.Description = Description.Text;


                site.Name = NameTextBox.Text;
                site.Login = LoginTextBox.Text;
                site.Password = Password.Password;
                site.Url = UrlTextBox.Text;
                site.Description = Description.Text;

                parent.context.SaveChanges();
                

                parent.ListView.Items.Refresh();
                this.Close();
            }
            else
            {
                Site newsite = new Site(NameTextBox.Text, UrlTextBox.Text, Description.Text, LoginTextBox.Text, Password.Password);
               // newsite.User = parent.user;
                newsite.UserID = parent.user.ID;
                parent.user.Sites.Add(newsite);
                using(Context context = new Context()){
                    context.Sites.Add(newsite);
                    context.SaveChanges();
                }
                
               
                parent.ListView.Items.Refresh();
                this.Close();
            }
        }
    }
}

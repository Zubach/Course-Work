using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<User> users = new List<User>();
       
        public Window1()
        {
            InitializeComponent();


            using (FileStream fs = new FileStream("Accounts.xml",FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
                 users = formatter.Deserialize(fs) as List<User>;
              
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Regex emailValidation = new Regex(@"\w*@\w*.((com)|(ua))");
            if (emailValidation.IsMatch(EmailTextBox.Text))
            {
                bool canCreate = true;
                foreach(var user in users)
                {
                    if(user.email == EmailTextBox.Text)
                    {
                        MessageBox.Show("Account with this email is already created.");
                        canCreate = false;
                        break;
                    }
                    if(user.Login == LoginTextBox.Text)
                    {

                        MessageBox.Show("This login is already occupied.");
                        canCreate = false;
                        break;
                    }
                }
                if (canCreate)
                {
                    if (Password.Password != null && ConfirmPassword.Password != null)
                    {
                        Regex passwordValidation = new Regex(@"(\w+|\W+(\d+))");
                        if (passwordValidation.IsMatch(Password.Password))
                        {
                            if (Password.Password == ConfirmPassword.Password)
                            {

                                User user = new User(EmailTextBox.Text, LoginTextBox.Text, Password.Password);
                                Window2 wind = new Window2(user);
                                wind.Show();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Fields \"Password\" and \"Confirm Password\" do not match");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid email.");
            }
        }
    }
}

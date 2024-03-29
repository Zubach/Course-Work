﻿using System;
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
       
        Context context = new Context();
       
        public Window1()
        {
            InitializeComponent();

            
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Regex emailValidation = new Regex(@"\w*@\w*.((com)|(ua))");
            if (emailValidation.IsMatch(EmailTextBox.Text))
            {
                bool canCreate = true;
                foreach(var user in context.Users)
                {
                    if(user.Email == EmailTextBox.Text)
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
                                context.Users.Add(user);
                                context.SaveChanges();
                               
                                Window2 wind = new Window2();
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

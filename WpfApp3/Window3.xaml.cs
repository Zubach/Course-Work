﻿using System;
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
using System.Xml.Serialization;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    /// 
    public partial class Window3 : Window

    {

        public User user = null;
       public Context context = new Context();
        
        public Window3()
        {

            
            InitializeComponent();

            
        }

        public Window3(User user)
        {


            InitializeComponent();
            this.user = user;


           
            ListView.ItemsSource = user.Sites;
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Stats wind = new Stats(this, 1);
            wind.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Stats wind = new Stats(this, 0);
            wind.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(ListView.SelectedItem != null)
            {
                Site site = ListView.SelectedItem as Site;
                
                using(Context context = new Context()){
                  
                    Site deletedSite = context.Sites.Where(s => s.Login == site.Login && s.Name == site.Name && s.Password == site.Password).FirstOrDefault();
                    
                   
                   context.Sites.Attach(deletedSite);
                    context.Sites.Remove(deletedSite);
                   
                    context.SaveChanges();
                } 
                user.Sites.Remove(ListView.SelectedItem as Site);
                ListView.Items.Refresh();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            StatsPassLogin wind = new StatsPassLogin(this);
            wind.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           

            using(Context context = new Context()){
                
                context.SaveChanges();
            }
        }

        class Pair
        {
            string str;
            int counter;
            public void Bust()
            {
                this.counter++;
            }
            public Pair(string str)
            {
                this.str = str;
                counter = 0;
            }
            public string Str{
                get
                {
                    return str;
                }
            }
            public int Count
            {
                get
                {
                    return counter;
                }
            }

        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            List<Pair> passwords = new List<Pair>();
            foreach(var site in user.Sites)
            {
                bool found = false;
               foreach (var item in passwords)
                {
                    if (item.Str == site.Password)
                    {
                        found = true;
                        break;
                    }
                }
                if(!found)
                    passwords.Add(new Pair(site.Password));
                
            }


            foreach(var site in user.Sites)
            {
                foreach(var item in passwords)
                {
                    if (item.Str == site.Password)
                    {
                        item.Bust();
                        
                        break;
                    }
                }
            }

            if (passwords.Count > 0)
            {
                Pair max = passwords[0];
                foreach (var item in passwords)
                {
                    if(item.Count > max.Count)
                    {
                        max = item;
                    }
                }
                MessageBox.Show("Password: " + max.Str + '\n' + "Count of match: " + max.Count);
            }


            
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            List<Pair> logins = new List<Pair>();
            foreach (var site in user.Sites)
            {
                bool found = false;
                foreach (var item in logins)
                {
                    if (item.Str == site.Login)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    logins.Add(new Pair(site.Login));

            }


            foreach (var site in user.Sites)
            {
                foreach (var item in logins)
                {
                    if (item.Str == site.Login)
                    {
                        item.Bust();
                       
                        break;
                    }
                }
            }

            if (logins.Count > 0)
            {
                Pair max = logins[0];
                foreach (var item in logins)
                {
                    if (item.Count > max.Count)
                    {
                        max = item;
                    }
                }
                MessageBox.Show("Login: " + max.Str + '\n' + "Count of match: " + max.Count);
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            int key;
            if(Key.Text != null &&  int.TryParse(Key.Text,out key))
            {
                foreach(var site in user.Sites)
                {
                    site.Password = Cryptographer.Encrypt(site.Password, key);
                }
                ListView.Items.Refresh();
                (sender as Button).IsEnabled = false;
                DecryptBtn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid Key");
            }
        }

        private void DecryptBtn_Click(object sender, RoutedEventArgs e)
        {
            int key;
            if (Key.Text != null && int.TryParse(Key.Text, out key))
            {
                foreach (var site in user.Sites)
                {
                    site.Password = Cryptographer.Decrypt(site.Password, key);
                }
                ListView.Items.Refresh();
                (sender as Button).IsEnabled = false;
                EncryptBtn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid Key");
            }
        }
    }
}

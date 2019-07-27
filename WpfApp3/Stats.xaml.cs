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
    /// Логика взаимодействия для Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        int state = -1;
        Window3 parent = null;
        public Stats()
        {
            InitializeComponent();
        }

        public Stats(Window3 parent,int state)
        {
            InitializeComponent();
            this.state = state;
            switch (state)
            {
                case 0:
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox, "Login");
                    break;
                case 1:
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox, "Password");
                    break;
            }

            this.parent = parent;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
        //    switch (state) {
        //        case 0:
                    
        //            foreach (var site in parent.user.sites)
        //            {
        //                 if (site.Login == textBox.Text)
        //                     counter++;
        //            }
        //            CountTextBlock.Text = "Count of matches: " + counter;
        //            break;
        //        case 1:
                    
        //            foreach (var site in parent.user.sites)
        //            {
        //                if (site.Password == textBox.Text)
        //                    counter++;
        //            }
        //            CountTextBlock.Text = "Count of matches: " + counter;
        //            break;
        //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class User
    {
        string email;
        string login;
        string password;

        public string Login{
            get
            {
                return login;
            }
         }
        public string Password
        {
            get
            {
                return password;
            }
        }
        public List<Site> sites = new List<Site>();

       

        public User(string email, string login, string password)
        {
            this.email = email;
            this.login = login;
            this.password = password;

        }
    }
}

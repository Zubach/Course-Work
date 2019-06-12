using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class User
    {
        string email;
        string login;
        string password;
        List<Site> sites = new List<Site>();

        public List<Site> SitesList
        {
            get
            {
                return sites;
            }
        }

        public User(string email, string login, string password)
        {
            this.email = email;
            this.login = login;
            this.password = password;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    public class User
    {
        public string email;
        public string login;
        public string password;

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

       public User()
        {

        }

        public User(string email, string login, string password)
        {
            this.email = email;
            this.login = login;
            this.password = password;

        }
    }
}

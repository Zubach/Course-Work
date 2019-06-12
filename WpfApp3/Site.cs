using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Site
    {
        string name;
        string url;
        string description;
        string login;
        string password;

        public string Name
        {
            get
            {
                return name;

            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public string Login
        {
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

        public Site(string name, string url, string description, string login, string password)
        {
            this.name = name;
            this.url = url;
            this.description = description;
            this.login = login;
            this.password = password;
        }
    }
}

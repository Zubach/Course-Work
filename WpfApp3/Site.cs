using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Site
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
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
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

        public override bool Equals(object obj)
        {
            var site = obj as Site;
            return site != null &&
                   Name == site.Name &&
                   Description == site.Description &&
                   Url == site.Url &&
                   Login == site.Login &&
                   Password == site.Password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Context:DbContext
    {
        public Context():base("connectionString")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Site> Sites { get; set; }
    }
}

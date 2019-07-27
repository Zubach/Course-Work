using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    [Serializable]
    [Table("tblSites")]
    public class Site
    {
        public Site()
        {
           
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }


        public string Description { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]

        public string Password { get; set; }



        public int? UserID { get; set; }

        public User User { get; set; }

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

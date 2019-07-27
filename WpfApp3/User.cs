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
    [Table("tblUsers")]
    public class User
    {
        public User()
        {
            this.Sites = new HashSet<Site>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual ICollection<Site> Sites { get; set; }




    }
}

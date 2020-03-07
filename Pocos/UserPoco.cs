using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pocos
{
    [Table("Users Info")]
    public class UserPoco
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        public virtual ICollection<BookPoco> UsersBookCollection { get; set; }
    }
}

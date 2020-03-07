using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pocos
{
    [Table("Books Collection")]
    public class BookPoco
    {
        [Key]
        public Guid ISBN { get; set; }
        [Column("Book Name")]
        public string Name { get; set; }
        [Column("Published Date")]
        public DateTime PublishedDate { get; set; }
        [Column("Checked Out")]
        public Boolean checkout { get; set; }
        public Guid UserId { get; set; }
        public virtual UserPoco BookUserInfo { get; set; }

    }
}

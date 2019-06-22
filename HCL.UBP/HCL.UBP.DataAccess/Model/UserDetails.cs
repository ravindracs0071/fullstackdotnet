using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.UBP.DataAccess.Model
{
    [Table("UserDetails")]
    public class UserDetails : BaseEntity
    {
        public const int NVarcharLength36 = 36;

        [Required]
        [MaxLength(NVarcharLength36)]
        public virtual string Username { get; set; }

        [Required]
        [MaxLength(NVarcharLength36)]
        public virtual string Password { get; set; }
    }
}

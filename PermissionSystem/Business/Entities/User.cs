using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("id_role")]
        [ForeignKey("Role")]
        public int? IdRole { get; set; }

        public Role Role { get; set; }

    }
}

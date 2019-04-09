using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Entities
{
    [Table("module")]
    public class Module
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("slug")]
        public string Slug { get; set; }

        [Column("items")]
        public string Items { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PermissionSystem.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Context
{
    public class AppInoContext : DbContext
    {
        public AppInoContext(DbContextOptions<AppInoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
    }
}

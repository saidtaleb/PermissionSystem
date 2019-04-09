using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Models
{
    public class PermissionRoleModel
    {
        public ModulePermission Modules { get; set; }
    }

    public class ModulePermission
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public ItemModulePermissionModel Items { get; set; }
    }

    public class ItemModulePermissionModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool HasPerimission { get; set; }
    }
}

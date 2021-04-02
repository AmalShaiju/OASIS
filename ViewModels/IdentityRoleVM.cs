using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.ViewModels
{
    public class IdentityRoleVM
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public List<IdentityUserVM> AssignedUsers { get; set; }
        public int AssignedCount { get; set; }

    }
}

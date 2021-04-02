using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.ViewModels
{
    public class IdentityUserVM
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public IList<string> Roles { get; set; }
    }
}

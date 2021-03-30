using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace OASIS.ViewModels
{
    public class PageClaims
    {
        public string PageName { get; set; }
        public string RoleName { get; set; }
        public List<Claim> Claims { get; set; }
    }
}

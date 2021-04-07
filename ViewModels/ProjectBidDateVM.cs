using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.ViewModels
{
    public class ProjectBidDateVM
    {
        public string ProjectName { get; set; }
        public int ProjectID { get; set; }
        public DateTime ApprovedBidDate { get; set; }
    }
}

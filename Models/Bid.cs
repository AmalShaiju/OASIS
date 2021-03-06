﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class Bid : Auditable
    {
       public Bid()
        {
            Approval = new Approval();
            Approval.ClientStatusID = 1;
            Approval.DesignerStatusID = 1;
            Approval.Comments = "No Comment";
            DateCreated = DateTime.Now;

            BidLabours = new HashSet<BidLabour>();
            BidProducts = new HashSet<BidProduct>();

        }
        public int ID { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Estimated Amount")]
        [Required(ErrorMessage = "You must enter the estimated amount.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public double EstAmount { get; set; }

        [Display(Name = "Actual Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectStartDate  { get; set; }

        [Display(Name = "Actual End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProjectEndDate { get; set; }

        [Required(ErrorMessage = "Estimated Start Date is required.")]
        [Display(Name = "Estimated Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstBidStartDate { get; set; }

        [Required(ErrorMessage = "Estimated End Date is required.")]
        [Display(Name = "Estimated End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstBidEndDate { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public double? Budget { get; set; }

        [Required(ErrorMessage = "Please select a designer")]
        [Display(Name = "Designer")]
        public int DesignerID { get; set; }
        public virtual Employee Designer { get; set; }

        [Required(ErrorMessage = "Please select a Sales Associative")]
        [Display(Name = "Sales Associate")]
        public int SalesAsscociateID { get; set; }
        public virtual Employee SalesAsscociate { get; set; }

        public bool IsFinal { get; set; }


        [Required(ErrorMessage = "Please select a project")]
        [Display(Name = "Project")]
        public int ProjectID { get; set; }

        public Project Project { get; set; }

        [Display(Name = "Status")]
        public int? BidStatusID { get; set; }
        public BidStatus BidStatus { get; set; }

        public Approval Approval { get; set; }

        public ICollection<BidProduct> BidProducts { get; set; }
        public ICollection<BidLabour> BidLabours { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer_Contact.Models
{
    public class CustomerSearchModel
    {
        public string Name { get; set; }
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        [Display(Name = "City")]
        public int? CityId { get; set; }
        [Display(Name = "Region")]
        public int? RegionId { get; set; }
        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchaseStart { get; set; }
        public DateTime? LastPuchaseEnd { get; set; }
        [Display(Name = "Classification")]
        public int? ClassificationId { get; set; }
        [Display(Name = "Seller")]
        public int? SellerId { get; set; }
    }
}
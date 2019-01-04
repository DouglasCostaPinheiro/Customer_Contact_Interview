using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer_Contact.Models
{
    public class CustomerListModel
    {
        public string Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastPurchase { get; set; }
        public string Seller { get; set; }

        public static explicit operator CustomerListModel(Customer customer)
        {
            return new CustomerListModel()
            {
                Classification = customer.Classification.Name,
                Name = customer.Name,
                Phone = customer.Phone,
                Gender = customer.Gender.Name,
                City = customer.City.Name,
                Region = customer.Region.Name,
                LastPurchase = customer.LastPurchase,
                Seller = customer.Seller.Login
            };
        }
    }
}
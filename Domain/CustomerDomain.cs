using Entities;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class CustomerDomain
    {
        private static CustomerRepository _repo = new CustomerRepository();

        public static IEnumerable<Customer> ListCustomers()
        {
            return _repo.ListCustomers();
        }

        public static IEnumerable<Customer> ListCustomers(string name, int? genderId, int? cityId, int? regionId, DateTime? lastPurchaceStart, DateTime? lastPurchaseEnd, int? classificationId, int? sellerId)
        {
            return _repo.ListCustomers(name, genderId, cityId, regionId, lastPurchaceStart, lastPurchaseEnd, classificationId, sellerId);
        }
    }
}

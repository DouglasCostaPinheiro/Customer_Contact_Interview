using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class CustomerRepository : Repository
    {
        public CustomerRepository() : base() { }

        public IEnumerable<Customer> ListCustomers()
        {
            var SQL = @"SELECT
	                        *
                        FROM CUSTOMER
                        INNER JOIN GENDER ON GENDER.Id = Customer.GenderId
                        INNER JOIN City on City.Id = CityId
                        INNER JOIN Region on region.Id = CUSTOMER.RegionId
                        INNER JOIN Classification on Classification.Id = ClassificationId
                        INNER JOIN UserSys on UserSys.Id = UserId
                        ";

            _conn.Open();

            var customers = _conn.Query<Customer, Gender, City, Region, Classification, UserSys, Customer>(SQL, (customer, gender, city, region, classification, userSys) => {
                customer.Gender = gender;
                customer.City = city;
                customer.Region = region;
                customer.Classification = classification;
                customer.Seller = userSys;

                return customer;
            });

            _conn.Close();

            return customers;
        }

        public IEnumerable<Customer> ListCustomers(string name, int? genderId, int? cityId, int? regionId, DateTime? lastPurchaseStart, DateTime? lastPurchaseEnd, int? classificationId, int? sellerId)
        {
            var SQL = @"SELECT
	                        *
                        FROM CUSTOMER
                        INNER JOIN GENDER ON GENDER.Id = Customer.GenderId
                        INNER JOIN City on City.Id = CityId
                        INNER JOIN Region on region.Id = CUSTOMER.RegionId
                        INNER JOIN Classification on Classification.Id = ClassificationId
                        INNER JOIN UserSys on UserSys.Id = UserId
                        WHERE (TRIM(ISNULL(@NAME, '')) = '' OR CUSTOMER.NAME LIKE '%'+@NAME+'%') AND
                        (@GENDERID IS NULL OR GENDER.ID = @GENDERID) AND
                        (@CITYID IS NULL OR CITY.ID = @CITYID) AND
                        (@REGIONID IS NULL OR REGION.ID = @REGIONID) AND
                        (@LASTPURCHASESTART IS NULL OR CUSTOMER.LASTPURCHASE >= @LASTPURCHASESTART) AND
                        (@LASTPURCHASEEND IS NULL OR CUSTOMER.LASTPURCHASE <= @LASTPURCHASEEND) AND
                        (@CLASSIFICATIONID IS NULL OR CLASSIFICATION.ID = @CLASSIFICATIONID) AND
                        (@SELLERID IS NULL OR USERSYS.ID = @SELLERID);";

            _conn.Open();

            var customers = _conn.Query<Customer, Gender, City, Region, Classification, UserSys, Customer>(SQL, (customer, gender, city, region, classification, userSys) => {
                customer.Gender = gender;
                customer.City = city;
                customer.Region = region;
                customer.Classification = classification;
                customer.Seller = userSys;

                return customer;
            }, new {
                NAME = name,
                GENDERID = genderId,
                CITYID = cityId,
                REGIONID = regionId,
                LASTPURCHASESTART = lastPurchaseStart,
                LASTPURCHASEEND = lastPurchaseEnd,
                CLASSIFICATIONID = classificationId,
                SELLERID = sellerId
            });

            _conn.Close();

            return customers;
        }
    }
}

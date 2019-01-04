using Entities;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CityDomain
    {
        private static CityRepository _repo = new CityRepository();

        public static IEnumerable<City> ListCities()
        {
            return _repo.ListCities();
        }
    }
}

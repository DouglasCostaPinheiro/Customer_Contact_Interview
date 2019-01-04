using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class CityRepository : Repository
    {
        public CityRepository() : base() { }

        public IEnumerable<City> ListCities()
        {
            _conn.Open();

            var cities = _conn.Query<City>("SELECT * FROM CITY");

            _conn.Close();

            return cities;
        }
    }
}

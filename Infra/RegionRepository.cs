using Dapper;
using Entities;
using System.Collections.Generic;

namespace Infra
{
    public class RegionRepository : Repository
    {
        public RegionRepository() : base() { }

        public IEnumerable<Region> ListRegions()
        {
            _conn.Open();

            var regions = _conn.Query<Region>("SELECT * FROM REGION");

            _conn.Close();

            return regions;
        }
    }
}

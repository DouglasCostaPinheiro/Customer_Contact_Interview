using Entities;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegionDomain
    {
        private static RegionRepository _repo = new RegionRepository();

        public static IEnumerable<Region> ListRegions()
        {
            return _repo.ListRegions();
        }
    }
}

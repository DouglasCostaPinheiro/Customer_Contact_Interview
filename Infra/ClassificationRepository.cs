using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ClassificationRepository : Repository
    {
        public ClassificationRepository() : base() { }

        public IEnumerable<Classification> ListClassifications()
        {
            _conn.Open();

            var regions = _conn.Query<Classification>("SELECT * FROM CLASSIFICATION");

            _conn.Close();

            return regions;
        }
    }
}

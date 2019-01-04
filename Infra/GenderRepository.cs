using Dapper;
using Entities;
using System.Collections.Generic;

namespace Infra
{
    public class GenderRepository : Repository
    {
        public GenderRepository() : base() { }

        public IEnumerable<Gender> ListGenders()
        {
            _conn.Open();

            var genders = _conn.Query<Gender>("SELECT * FROM GENDER");

            _conn.Close();

            return genders;
        }
    }
}

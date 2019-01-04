using Entities;
using Infra;
using System.Collections.Generic;

namespace Domain
{
    public static class GenderDomain
    {
        private static GenderRepository _repo = new GenderRepository();

        public static IEnumerable<Gender> ListGenders()
        {
            return _repo.ListGenders();
        }
    }
}

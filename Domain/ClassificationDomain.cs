using Entities;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClassificationDomain
    {
        private static ClassificationRepository _repo = new ClassificationRepository();

        public static IEnumerable<Classification> ListClassifications()
        {
            return _repo.ListClassifications();
        }
    }
}

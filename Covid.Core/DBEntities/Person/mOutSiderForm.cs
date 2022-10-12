using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Person
{
    public class mOutSiderForm
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public long? MobileNumber { get; set; }

        public string ComingFromOtherState { get; set; }

        public string ComingAddressofOtherState { get; set; }

        public string GoingToOtherState { get; set; }

        public string GoingAddressofOtherState { get; set; }

        public string AddressofJabalpur { get; set; }

        public string Occupation { get; set; }

        public int? NoofPersons { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

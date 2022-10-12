using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.ViewModel.Quarantine
{
    public class vmHomeQuarantine
    {
        public mHomeQuarantine QuarantineDetails {get;set;}
        public List<mHomeQuarantine> QList { get; set; }
        public List<mCovidPerson> PositivePersonDetailList { get; set; }
        public List<mRefGroup> GetRefGroupList { get; set; }
        public vmHomeQuarantine()
        {
            QuarantineDetails = new mHomeQuarantine();
            QList= new List<mHomeQuarantine>();
            PositivePersonDetailList = new List<mCovidPerson>();
            GetRefGroupList = new List<mRefGroup>();
        }
    }
}

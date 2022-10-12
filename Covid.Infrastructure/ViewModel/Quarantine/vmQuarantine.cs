using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.ViewModel.Quarantine
{
    public class vmQuarantine
    {
        public mQuarantine QuarantineDetails {get;set;}
        public List<mQuarantine> QList { get; set; }
        public List<mPersonAllDetals> PList { get; set; }
        public List<mPerson> PositivePersonDetailList { get; set; }

        public vmQuarantine()
        {
            QuarantineDetails = new mQuarantine();
            QList= new List<mQuarantine>();
            PList = new List<mPersonAllDetals>();
            PositivePersonDetailList = new List<mPerson>();
        }
    }
}

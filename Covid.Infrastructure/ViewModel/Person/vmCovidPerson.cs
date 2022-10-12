using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.Master;
using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;

namespace Covid.Infrastructure.ViewModel.Person
{
    public class vmCovidPerson
    {
        public mCovidPerson PersonDetail { get; set; }
        public List<mCovidPerson> CovidPersonDetailList { get; set; }
        public List<mLocalBody> LocalBodyList { get; set; }
        public List<mLocalBody> GetZoneList { get; set; }
        public List<mLocalBody> GetWardList { get; set; }
        public List<mHomeQuarantine> QList { get; set; }

        public List<mRefGroup> GetRefGroupList { get; set; }
        public vmCovidPerson()
        {
            PersonDetail = new mCovidPerson();
            CovidPersonDetailList = new List<mCovidPerson>();
            LocalBodyList = new List<mLocalBody>();
            GetZoneList = new List<mLocalBody>();
            GetWardList = new List<mLocalBody>();
            QList = new List<mHomeQuarantine>();
            GetRefGroupList = new List<mRefGroup>();
        }
    }
}

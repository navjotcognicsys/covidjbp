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
    public class vmPerson
    {
        public mPerson PersonDetail { get; set; }
        public mPersonAllDetals PersonAllDetail { get; set; }
        public List<mPerson> PersonDetailList { get; set; }
        public mOutSiderForm OutSiderForm { get; set; }
        public List<mOutSiderForm> OutSiderFormList { get; set; }
        public List<mPerson> PositivePersonDetailList { get; set; }
        public List<mPerson> CurrentLocationDetailList { get; set; }
        public List<mInfectionSource> InfectionSourceList { get; set; }
        public List<mLocalBody> LocalBodyList { get; set; }
        public List<mLocalBody> GetZoneList { get; set; }
        public List<mLocalBody> GetWardList { get; set; }
        public List<mPersonAllDetals> PersonAllDetalsList { get; set; }
        public List<mCheckPoint> CheckPointList { get; set; }
        public List<PersonTreeView> PList { get; set; }
        public List<string> Address { get; set; }
        public List<mQuarantine> QList { get; set; }
        public int map;
        public vmPerson()
        {
            PersonDetail = new mPerson();
            PersonAllDetail = new mPersonAllDetals();
            OutSiderForm = new mOutSiderForm();
            OutSiderFormList = new List<mOutSiderForm>();
            PersonDetailList = new List<mPerson>();
            InfectionSourceList = new List<mInfectionSource>();
            LocalBodyList = new List<mLocalBody>();
            GetZoneList = new List<mLocalBody>();
            GetWardList = new List<mLocalBody>();
            PersonAllDetalsList = new List<mPersonAllDetals>();
            CheckPointList = new List<mCheckPoint>();
            PList = new List<PersonTreeView>();
            PositivePersonDetailList = new List<mPerson>();
            CurrentLocationDetailList = new List<mPerson>();
            QList = new List<mQuarantine>();
        }
    }
}

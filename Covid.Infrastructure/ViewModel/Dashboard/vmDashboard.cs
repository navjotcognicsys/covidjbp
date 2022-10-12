using Covid.Core.DBEntities.Complaint;
using Covid.Core.DBEntities.Dashboard;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.Master;
using Covid.Core.DBEntities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.ViewModel.Dashboard
{
    public class vmDashboard
    {
        public List<mDashboard> DashboardCountList { get; set; }
        public mDashboard DashboardCount { get; set; }
        //public List<mLocalBody> LocalBodyList { get; set; }
        public List<mLocalBody> GetZoneList { get; set; }
        public List<mLocalBody> GetWardList { get; set; }

        //person
        public List<mInfectionSource> InfectionSourceList { get; set; }
        public List<mLocalBody> LocalBodyList { get; set; }
        public List<mPersonAllDetals> PersonAllDetalsList { get; set; }
        public List<mComplaint> ComplaintDetailsList { get; set; }

        public int IsQ;
        public int IsP;
        public List<mCheckPoint> CheckPointList { get; set; }
        public vmDashboard()
        {
            DashboardCount = new mDashboard();
            DashboardCountList = new List<mDashboard>();

            //person
            InfectionSourceList = new List<mInfectionSource>();
            LocalBodyList = new List<mLocalBody>();
            //GetZoneList = new List<mLocalBody>();
            //GetWardList = new List<mLocalBody>();
            PersonAllDetalsList = new List<mPersonAllDetals>();
            ComplaintDetailsList = new List<mComplaint>();
            CheckPointList = new List<mCheckPoint>();

        }
    }
}
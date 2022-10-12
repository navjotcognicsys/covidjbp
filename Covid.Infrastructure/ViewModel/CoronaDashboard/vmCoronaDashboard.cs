using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.CoronaUpdate;
namespace Covid.Infrastructure.ViewModel.CoronaDashboard
{
    public class vmCoronaDashboard
    {
        public List<mHospitalStatus> DashboardHospitalStatusList { get; set; }
        public mCoronaCases DashboardCoroanCurentStatus { get; set; }

        public  vmCoronaDashboard()
        {
            DashboardHospitalStatusList = new List<mHospitalStatus>();
            DashboardCoroanCurentStatus = new mCoronaCases();
        }

    }
}

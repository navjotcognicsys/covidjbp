using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.CoronaUpdate;

namespace Covid.Core.IRepo
{
    public interface IPublicDashboardRepository
    {
        mCoronaCases GetCurrentCoronaDetails();

        List<mHospitalStatus> GetCurrentHospitalStatus();

        void UpdateHospitalData(mHospitalStatus HospitalStatus);
        void CreateCoranaData(mCoronaCases coronaStatus);
        void UpdateHospitalMasterData(mHospitalStatus hospitalStatus);
    }
}

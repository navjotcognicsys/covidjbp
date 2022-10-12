using Covid.Core.DBEntities.Complaint;
using Covid.Core.DBEntities.Dashboard;
using Covid.Core.DBEntities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface IDashboardRepository
    {
        List<mDashboard> GetDashboardList(int UserTypeId ,int? ID,int UserId);

        ///for person data view
        List<mPersonAllDetals> GetIPersonDeailByFilter(int LOcalBodyID, int ZoneID, int WardID,int Isquarantine,int IsPostive,int? Checkpoint);
        List<mComplaint> GetComplaintsByFilter(int LBID, int ZID, int WID, int UserTypeId);
        List<mComplaint> GetComplaintsByUserID(int UserId, int UserTypeId, string UserType);
    }
}

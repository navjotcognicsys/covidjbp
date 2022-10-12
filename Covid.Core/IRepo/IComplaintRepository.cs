using Covid.Core.DBEntities.Complaint;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface IComplaintRepository
    {
        void InsertComplaint(mComplaint ComplaintDetails);
        List<mComplaintType> GetAllComplaintTypes();
        mComplaint GetComplaintDetailsBasedonId(int ComplaintId);
        List<mComplaint> GetAllComplaintDetails(string LOcalBodyID, string ZoneID, string WardID, string DateOfCreation, int? ComplaintType,string Status);
        List<mUserDetails> GetAllUserNamesBasedonComplaintType(int ComplaintTypeId);
        List<mComplaint> GetComplaintDetailsListBasedonId(int ComplaintId);
        void UpdateAssignmentDetails(mComplaint ComplaintDetails);
        List<mComplaint> GetAllComplaintDetails(string mobileNumber);
        List<mComplaint> GetAllComplaintDetails(DateTime dateTime1, DateTime dateTime2,int UserId);
    }
}

using Covid.Core.DBEntities.Complaint;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.ViewModel.Complaint
{
    public class vmComplaint
    {
         public List<mComplaintType> ComplaintTypeList { get;set;}
        public List<mLocalBody> LocalBodyList { get; set; }
        public List<mLocalBody> ZoneOrWardList { get; set; }
        public mComplaint ComplaintDetails { get; set; }
        public List<mComplaint> ComplaintDetailsList { get; set; }
        public List<mUserType> UserType { get; set; }

        public mLocalBody LocalBody { get; set; }
        public mLocalBody ZoneBody { get; set; }
        public mLocalBody WardBody { get; set; }

        public List<mUserDetails> UserNames { get; set; }
        public vmComplaint()
        {
            UserType = new List<mUserType>();
            ComplaintDetailsList =new List<mComplaint>();
            UserNames = new List<mUserDetails>();
            ComplaintDetails = new mComplaint();
            
            ComplaintTypeList = new List<mComplaintType>();
            LocalBodyList = new List<mLocalBody>();
            ZoneOrWardList = new List<mLocalBody>();
            LocalBody = new mLocalBody();
            ZoneBody = new mLocalBody();
            WardBody = new mLocalBody();
        }
    }
}

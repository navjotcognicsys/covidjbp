using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.ViewModel.vmUserDetails
{
   public class vmUserDetails
    {
        public mUserDetails UserReg { get; set; }
        public mUserAttendance UserATT { get; set; }
        public List<mUserDetails> UserRegList { get; set; }
        public mUserType usertype { get; set; }
        public List<mUserType> usertypeList { get; set; }
        public mLocalBody LocalBody { get; set; }
        public List<mLocalBody> LocalBodyList { get; set; }
        public mLocalBody ZoneBody { get; set; }
        public List<mLocalBody> ZoneBodyList { get; set; }
        public mLocalBody WardBody { get; set; }
        public List<mLocalBody> WardBodyList { get; set; }
        public mRRTZoneMapping RRTZM { get; set; }
        public List<mOffice> OfList { get; set; }
        public vmUserDetails()
        {
            UserReg = new mUserDetails();
            UserRegList = new List<mUserDetails>();
            usertype = new mUserType();
            usertypeList = new List<mUserType>();
            LocalBody = new mLocalBody();
            LocalBodyList = new List<mLocalBody>();
            ZoneBody = new mLocalBody();
            ZoneBodyList = new List<mLocalBody>();
            WardBody = new mLocalBody();
            WardBodyList = new List<mLocalBody>();
            RRTZM = new mRRTZoneMapping();
            UserATT = new mUserAttendance();
            OfList = new List<mOffice>();
        }
    }
}

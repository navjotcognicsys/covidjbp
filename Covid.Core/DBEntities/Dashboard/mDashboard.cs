using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Dashboard
{
    public class mDashboard
    {
        public int? LocalBodyId { get; set; }

        public int? ZoneId { get; set; }

        public int? WardId { get; set; }

        public int RRTInfected { get; set; }
		public int ComplaintAssignTo { get; set; }
        public int QuarantineCheck { get; set; }
        public string UserType { get; set; }
        public string userbodyname { get; set; }
        public int UserTypeId { get; set; }


        public int RegistrationCount { get; set; }
        public int QuarantineCount { get; set; }
        public int ZoneWiseQuarantine { get; set; }
        public int InfectedCount { get; set; }
        public int QuarantineCheckcompleted { get; set; }
        public int QuarantineCheckRemaining { get; set; }
        public int Registeredcomplaint { get; set; }
        public int PeoplewithoutZoneandward { get; set; }
        public int TotalComplaints { get; set; }
        public int TotalOpenComplaints { get; set; }
        public int TotalClosedComplaint { get; set; }
        public int TotalWorkingComplaint { get; set; }
        public int TotalRejectComplaint { get; set; }
        public int TotalWardComplaints { get; set; }
        public int TotalWardOpenComplaints { get; set; }
        public int TotalWardClosedComplaint { get; set; }
        public int TotalWardWorkingComplaint { get; set; }
        public int TotalWardRejectComplaint { get; set; }

    }
}

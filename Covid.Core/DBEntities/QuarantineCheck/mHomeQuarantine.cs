using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.QuarantineCheck
{
   public class mHomeQuarantine
    {
		public string PersonName { get; set; }
		public long IsolationCheckId { get; set; }
		public string DrName { get; set; }
		public long PersonId { get; set; }
		public bool IsTemp { get; set; }
		public decimal Temp { get; set; }
		public bool IsCough { get; set; }
		public bool IsBreath { get; set; }
		public int SPO2 { get; set; }
		public bool AnyProblem { get; set; }
		public bool AnyFamilyMemberIssue { get; set; }
		public bool ContactWithFamilyMember { get; set; }
		public bool IsYogaInstructor { get; set; }
		public bool IsYogaIntrested { get; set; }
		public bool IsYogaDoneToday { get; set; }
		public string DCCCRemark { get; set; }
		public string DoctorRemark { get; set; }
		public string EPD { get; set; }
		public bool IsVideoCall { get; set; }
		public bool IsMedicalKit { get; set; }
		public DateTime CreatedOn { get; set; }
		public int CreatedBy { get; set; }
	}
}

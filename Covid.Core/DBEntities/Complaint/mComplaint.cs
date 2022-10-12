using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Complaint
{
    public partial class mComplaint
    {
        public long ComplaintId { get; set; }

        public int ComplaintTypeId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public long? MobileNo { get; set; }

        public string Email { get; set; }

        public byte Status { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public string Details { get; set; }

        public int? AssignTo { get; set; }
        public int? AssignBy { get; set; }

        public int? LocalbodyId { get; set; }

        public int? ZoneId { get; set; }

        public int? WardId { get; set; }
        public string Remark { get; set; }
        public string AssignToName { get; set; }
        public DateTime AssignOn { get; set; }
        public string AssignByName { get; set; }
        public string ComplaintTypeName { get; set; }
        public string localbodyname { get; set; }
        public string zonename { get; set; }
        public string wardname { get; set; }


    }

}

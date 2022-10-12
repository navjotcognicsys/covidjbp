using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Complaint
{
    public class mComplaintType
    {
        public int ComplaintTypeId { get; set; }
        public string ComplaintTypeName { get; set; }
        public string ComplaintCategory { get; set; }
    }
}

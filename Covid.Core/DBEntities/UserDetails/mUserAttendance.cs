using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.UserDetails
{
    public class mUserAttendance
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Image { get; set; }
    }
}

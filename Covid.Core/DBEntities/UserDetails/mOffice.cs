using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.UserDetails
{
    public class mOffice
    {   
        public int ID { get; set; }
        public double UserLongitude { get; set; }
        public double UserLatitude { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        
        public int? LocalBodyID { get; set; }
        
        public int? ZoneID { get; set; }
        
        public int? WardID { get; set; }
        public string LocalBodyName { get; set; }
        public string ZoneName { get; set; }
        public string WardName { get; set; }
        public string OfficeName { get; set; }
        
        public string UserName { get; set; }
        public  int UserID { get; set; }
        
        public long MobileNumber { get; set; }
        
        public DateTime? AttendanceDate { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
        public string InOffice { get; set; }
        public string Distance { get; set; }

    }
}

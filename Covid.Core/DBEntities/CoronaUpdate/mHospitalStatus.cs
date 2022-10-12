using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.CoronaUpdate
{
    public class mHospitalStatus
    {
        public int HoshId { get; set; }
        public string HoshName { get; set; }
        public string HoshCat { get; set; }
        public string HoshAddress { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
        public int TotalIsolationBed { get; set; }
        public int OccIsolationBed { get; set; }
        public int TotalOxygenBed { get; set; }
        public int OccOxygenBed { get; set; }
        public int TotalICUBed { get; set; }
        public int OccICUBed { get; set; }
        public int Ventilators { get; set; }
        
        public string HoshType { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}


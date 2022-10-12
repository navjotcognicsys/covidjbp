using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.PoleSurve
{
    public class mStreetLightSurve
    {
        public long SLID { get; set; }
        public bool IsCable { get; set; }
        public string PoleNum { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string FittingType { get; set; }
        public int FittingVolt { get; set; }
        public string PoleType { get; set; }
        public int PoleHeight { get; set; }
        public int RoadWidth { get; set; }
        public string MountingHeight { get; set; }
        public int PoleSpan { get; set; }
        public string AreaType { get; set; }
        public string TrafficLevel { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime SurveDate { get; set; }
        public string PoleImagePath { get; set; }
    }
}

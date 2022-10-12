using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.PoleSurve
{
    public class mSwitchingSurve
    {
        public long SPID { get; set; }
        public string PointName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string MeterNumber { get; set; }
        public string IVRS { get; set; }
        public string ConnectionType { get; set; }
        public string OperationPhase { get; set; }
        public string MPPKVVCLDivisionName { get; set; }
        public string MPPKVVCLFeederName { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
        public double VoltageRPhase { get; set; }
        public double VoltageYPhase { get; set; }
        public double VoltageBPhase { get; set; }
        public double CurrentRPhase { get; set; }
        public double CurrentYPhase { get; set; }
        public double CurrentBPhase { get; set; }
        public double PowerFactorRPhase { get; set; }
        public double PowerFactorYPhase { get; set; }
        public double PowerFactorBPhase { get; set; }
        public double PowerRPhase { get; set; }
        public double PowerYPhase { get; set; }
        public double PowerBPhase { get; set; }
        public double EnergyRPhase { get; set; }
        public double EnergyYPhase { get; set; }
        public double EnergyBPhase { get; set; }
        public double CurrentReading { get; set; }
        public double MaxDemand { get; set; }
        public double DailyConsumtion { get; set; }
        public double MonthlyConsumtion { get; set; }
        public double YearlyConsumption { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime SurveDate { get; set; }
        public string SwitchImagePath { get; set; }
    }
}

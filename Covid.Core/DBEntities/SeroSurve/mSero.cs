using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Covid.Core.DBEntities.SeroSurve
{
    public class mSero
    {

        public long SeroSurveId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String ParentsName { get; set; }
        public int? Age { get; set; }
        public bool Gender { get; set; }
        public bool IsSamplePossible { get; set; }
        public int CauseForNoSample { get; set; }
        public long? Mobile { get; set; }
        public String Email { get; set; }
        public int HighestEdu { get; set; }
        public String Occupation { get; set; }
        public int OccupationType { get; set; }
        public bool IsWorkEmergency { get; set; }
        public int WhoWork { get; set; }
        public String GovtId { get; set; }
        public int GovtIdType { get; set; }
        public int? NumberofFamily { get; set; }
        public int? MaleMember { get; set; }
        public int? FemaleMember { get; set; }
        public int? KidsNumber { get; set; }
        public int? AdlutNumber { get; set; }
        public float? FamilyMontlyIncome { get; set; }
        public bool IsBPL { get; set; }
        public int HomeType { get; set; }
        public int? TotalRoom { get; set; }
        public double? TotalArea { get; set; }
        public bool HomeArea { get; set; }
        public int Batroom { get; set; }
        public bool IsDiabities { get; set; }
        public bool BP { get; set; }
        public bool IsCancer { get; set; }
        public bool IsKidney { get; set; }
        public bool IsHeart { get; set; }
        public bool IsLungs { get; set; }
        public bool IsLiver { get; set; }
        public bool IsOrgantransplant { get; set; }
        public bool IsDisable { get; set; }
        public bool IsBlood { get; set; }
        public bool IsPCR { get; set; }
        public bool IsILI { get; set; }
        public bool IsSARI { get; set; }
        public DateTime CollectedOn { get; set; }
        public int CreatedBy { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
    }
}

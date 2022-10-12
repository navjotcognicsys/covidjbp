using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Person
{
    public class mPerson
    {
        public long PersonId { get; set; }

        public string PersonName { get; set; }

        public string Mobileno { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime? Dateofarrival { get; set; }

        public string ComingFrom { get; set; }

        public string GoingTo { get; set; }

        public string PermanentAddress { get; set; }

        public int HealthStatus { get; set; }

        public string TravelMode { get; set; }

        public int? LocalBodyId { get; set; }

        public int? ZoneId { get; set; }

        public int? WardId { get; set; }

        public int? InfectionSource { get; set; }

        public int Isquarantine { get; set; }

        public int IsSticker { get; set; }

        public DateTime? QuarantineDate { get; set; }

        public DateTime? StickerDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? CheckpostId { get; set; }

        public int IsPositive { get; set; }
        public int IsPermissionPass { get; set; }

        public string TwoMonthsDetails { get; set; }

        public string FifteenDaysDetails { get; set; }

        public int IsCough { get; set; }

        public int IsFever { get; set; }

        public int IsShortnessofBreath { get; set; }

        public string CoronaRemark { get; set; }
        public int IsSuspect { get; set; }
        public long PersonRelationID { get; set; }
        public string CurrentLocation { get; set; }
    }

}

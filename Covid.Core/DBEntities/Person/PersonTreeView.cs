using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Person
{
   public class PersonTreeView
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

        public string HealthStatus { get; set; }

        public string TravelMode { get; set; }

        public string LocalBody { get; set; }

        public string ZoneId { get; set; }

        public string WardId { get; set; }

        public string InfectionSource { get; set; }

        public string Isquarantine { get; set; }

        public string IsSticker { get; set; }

        public DateTime? QuarantineDate { get; set; }

        public DateTime? StickerDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? CheckpostId { get; set; }

        public string IsPositive { get; set; }
        public string IsPermissionPass { get; set; }

        public string TwoMonthsDetails { get; set; }

        public string FifteenDaysDetails { get; set; }

        public string IsCough { get; set; }

        public string IsFever { get; set; }

        public string IsShortnessofBreath { get; set; }

        public string CoronaRemark { get; set; }
        public string IsSuspect { get; set; }
        public long PersonRelationID { get; set; }
        public string CurrentLocation { get; set; }
      public  List<PersonTreeView> List { get; set; }
        public PersonTreeView()
        {
            
            List = new List<PersonTreeView>();

        }
    }
   
}

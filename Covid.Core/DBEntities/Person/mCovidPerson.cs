using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.Person
{
    public class mCovidPerson
    {
		public long Id { get; set; }
		public string SampleId { get; set; }
		public string SRFID { get; set; }
		public string ICMRID { get; set; }
		public DateTime SampleCollectionDate { get; set; }
		public string PatientName { get; set; }
		public decimal Age { get; set; }
		public string FileNum { get; set; }
		public string MobileNumber { get; set; }
		public string Address { get; set; }
		public string SampleTakenBy { get; set; }
		public int LocalBodyId { get; set; }
		public int ZoneId { get; set; }
		public int WardId { get; set; }
		public string SDM { get; set; }
		public bool IsSymtoms { get; set; }
		public string Symtoms { get; set; }
		public string TravelDetails { get; set; }
		public string WorkDetails { get; set; }
		public int FamilyMemberCuount { get; set; }
		public int FiftyPlus { get; set; }
		public string AnyIssueFiftyPlus { get; set; }
		public int RoomCount { get; set; }
		public bool IsVaccine { get; set; }
		public int DoesCount { get; set; }
		public bool MedicalKit { get; set; }
		public int CurrentStatus { get; set; }
		public string Comments { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
		public string RefGroup { get; set; }
		public DateTime CreatedOn { get; set; }
	}

}

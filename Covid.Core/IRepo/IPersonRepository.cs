using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface IPersonRepository
    {
        int AddPerson(mPerson IC, int ModeValue);
        int AddCovidPerson(mCovidPerson IC);
        int UpdateCovidPerson(mCovidPerson IC);
        int AddOutSiderPerson(mOutSiderForm IC, int ModeValue);
        mCovidPerson GetCovidPerson(long PersonId);
        mPerson GePerson(long PersonId);
        List<mPersonAllDetals> GetIPersonDeailByFilter(string LOcalBodyID, string ZoneID, string WardID, string DateOfArrival, string Quarantine, string HealthStatus,
            string TravalMode,string PersonName,string ComingFrom, string InfectionSource, string Sticker,int? RelatedPersonID,int? CheckPoint,string Sick, string fever, string ShortnessofBreath,string CurrentLocation);

        List<mCovidPerson> GetCovidPersonDeailByFilter(string LocalBodyID, string ZoneID, string WardID,string CurrentStatus, string refGroup);
        mPerson GetPersonExistByNameandMobile(string Name, string MobileNumber);
        List<PersonTreeView> GeRelatedPerson(long PersonId);
        mPersonAllDetals GetAlldetailsPerson(long PersonId);
        List<mPersonAllDetals> GetAlldetailsPersonBySearch(string Search);
        List<PersonTreeView> GetAlldetailsPersonforTree(long PersonId);
        List<PersonTreeView> GeListRetalionbySQL(long PersonId);
        List<mPerson> GetPositivePersonDetail();
        List<mPersonAllDetals> GetAllpersonwithoutWard(long? PersonId);
        List<mPerson> GetCurrenTLocationDetail();
        void UpdateWardIdLocalBodyIdZoneIdPerson(int? WardId, int? LocalBodyId, int? ZoneId, long PersonId);
        List<mOutSiderForm> GetNewEntryPersondetailByDate(DateTime? StartDate, DateTime? EndDate);
        List<mQuarantine> GetQuarantinePersonByPersonId(long PersonID);
        List<mRefGroup> GetRefGroupDetail();

    }
}

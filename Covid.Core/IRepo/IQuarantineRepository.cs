using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface IQuarantineRepository
    {
        mQuarantine GetQuarantineDetails(int PersonId);
        mHomeQuarantine GetHomeQuarantineDetails(int PersonId);
        void UpdateQuarantineDetails(mQuarantine QuarantineDetails);
        void InsertHomeQuarantineDetails(mHomeQuarantine QuarantineDetails);
        List<mQuarantine> GetQuarantinePersonByPersonId(DateTime? StartDate, DateTime? EndDate);
        List<mHomeQuarantine> GetHomeQuarantinePersonByDate(DateTime? StartDate, DateTime? EndDate,String Group);
        List<mPersonAllDetals> GetNotQuarantinePersonByPersonId(DateTime? StartDate, long PersonId);
        List<mCovidPerson> GetHomeQuarantinePersonByPersonId(String RefGroup);
    }
}

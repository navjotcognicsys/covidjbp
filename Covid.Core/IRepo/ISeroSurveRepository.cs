using Covid.Core.DBEntities.SeroSurve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface ISeroSurveRepository
    {
        long InsertSeroSurve(mSero SeroSurve);
        List<mSero> GetAllSeroSurve();
        List<mSero> GetSeroSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID);
        List<mSero> GetSeroSurveReport(DateTime? StartDate, DateTime? EndDate);
    }
}

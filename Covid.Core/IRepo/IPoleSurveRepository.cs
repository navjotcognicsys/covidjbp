using Covid.Core.DBEntities.PoleSurve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface IPoleSurveRepository
    {
        long InsertStreetLightSurve(mStreetLightSurve StreetLightSurve);
        long InsertSwitchingSurve(mSwitchingSurve SwitchingSurve);
        List<mSwitchingSurve> GetAllSwitchingSurve();
        List<mStreetLightSurve> GetAllStreetLightSurve();
        List<mStreetLightSurve> GetStreetLightSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID);
        List<mSwitchingSurve> GetSwitchingSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID);
        List<mStreetLightSurve> GetStreetLightSurveReport(DateTime? StartDate, DateTime? EndDate);
        List<mSwitchingSurve> GetSwitchingSurveReport(DateTime? StartDate, DateTime? EndDate);
    }
}

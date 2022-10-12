using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.PoleSurve;

namespace Covid.Infrastructure.ViewModel.PoleSurve

{
    public class vmPoleSurve
    {
        public mSwitchingSurve SwitchingSurve { get; set; }
        public mStreetLightSurve StreetLightSurve { get; set; }
        public List<mLocalBody> WardList { get; set; }
        public List<mSwitchingSurve> SwitchingSurveList { get; set; }
        public List<mStreetLightSurve> StreetLightSurveList { get; set; }

        public vmPoleSurve()
        {
            SwitchingSurve = new mSwitchingSurve();
            StreetLightSurve = new mStreetLightSurve();
        }
    }
}

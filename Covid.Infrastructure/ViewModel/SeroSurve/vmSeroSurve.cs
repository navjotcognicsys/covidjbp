using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.SeroSurve;

namespace Covid.Infrastructure.ViewModel.SeroSurve
{
    public class vmSeroSurve
    {
        public mSero SeroSurve { get; set; }
        public List<mLocalBody> WardList { get; set; }
        public List<mSero> SeroSurveList { get; set; }

        public vmSeroSurve()
        {
            SeroSurve = new mSero();
        }
    }
}

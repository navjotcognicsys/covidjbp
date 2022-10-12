using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.CoronaUpdate
{
    public class mCoronaCases
    {
        public int CaseId { get; set; }
        public int ActiveCases { get; set; }
        public int CumActiveCases { get; }
        public int NegativeCases { get; set; }
        public int CumNegativeCases { get;  }

        public int AdmitInHospital { get; set; }
        public int HomeIsolation { get; set; }

        public int ConfirmedCases { get; set; }
       
        public int RecoveredCases { get; set; }
        public int CumRecoveredCases { get; }
        
        public int Deaths { get; set; }
        public int CumDeaths { get;}
       
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.QuarantineCheck
{
   public class mQuarantine
    {
        public long QuarantineCheckId { get; set; }

        public int PersonId { get; set; }

        public string PersonName { get; set; }
        public string Mobileno { get; set; }
        public string Address { get; set; }
        public DateTime? StickerDate { get; set; }

        public bool Fever { get; set; }

        public bool Cough { get; set; }

        public bool BreathingProblem { get; set; }

        public bool NA { get; set; }

        public bool IsSticker { get; set; }

        public bool AnyTrouble { get; set; }

        public bool AnyNeed { get; set; }

        public string Remark { get; set; }
        public string RelatedPersonName { get; set; }

        public int Checkedby { get; set; }

        public DateTime CheckedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.LocalBody
{
   public class mLocalBody
    {
        public int LocalBodyID { get; set; }

        public int LocalBodyParentId { get; set; }

        public string LocalBodyType { get; set; }

        public string LocalBodyName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.UserDetails
{
    public class mImageFields
    {
        public int UserID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ImageByte { get; set; }
    }
}

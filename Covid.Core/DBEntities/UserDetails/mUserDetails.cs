using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.UserDetails
{
    public class mUserDetails
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public long MobileNo { get; set; }
        public string EmailId { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
    }
}

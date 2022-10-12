using Covid.Core.DBEntities;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Covid.Infrastructure.Helpers
{
    public class SessionHelper
    {
        public static mUserDetails UserDetails
        {
            get
            {
                return (mUserDetails)HttpContext.Current.Session["UserDetails"];
            }
            set
            {
                HttpContext.Current.Session["UserDetails"] = value;
            }
        }
    }
}

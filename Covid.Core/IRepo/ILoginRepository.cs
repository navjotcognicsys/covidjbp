using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
    public interface ILoginRepository
    {
        mUserDetails GetUserDetailByMobileNo(long mobilenumber,string Password);
        bool ChangePassword(string NewPassword, long MobileNumber);
    }
}

using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.Master;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
   public interface ICommonRepository
    {
        List<mLocalBody> GetLocalyBody();
        List<mLocalBody> GetZoneOrWardByParentID(int? ID);
        List<mLocalBody> GetWardByParentID(int? ID);
        List<mInfectionSource> GetInfectionSource();
        mLocalBody GetDetailsbyid(int? ID);
        mLocalBody GetWardParentid(int? ID);
        mUserType GetUserType(string UserType);
        List<Core.DBEntities.Master.mCheckPoint> GetCheckPoint();
        mUserType GetUserTypeByUserTypeId(int UserTypeId);
        List<mUserType> GetAllUserType();
        List<mLocalBody> GetWardByUserIDParentID(int UserId, int? ID);
        List<mLocalBody> GetZoneOrWardByUserIdParentID(int UserId, int? ID);
        mUserDetails GetUserDetailByMobileNo(long mobilenumber, string Password);

    }
}

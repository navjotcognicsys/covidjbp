using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.IRepo
{
   public interface IUserRepository
    {
        List<mUserType> GetAllUserType();
        List<mUserDetails> GetAllUserDetail();
        mUserDetails GetUserDetailByMobileNo(long mobilenumber);
        bool AddUser(mUserDetails user);
        bool AddRRTZMUser(mRRTZoneMapping user);
        List<mUserDetails> GetAutoUserNameByMobNo(string firstterm);
        mRRTZoneMapping GetUserRRTZoneMappingByUserId(int UserId);
        List<UserTypeMenuMaster> GetMenuByUserType(int UserTypeId);
        bool AddUserMappingWard(int UserId, int Wards);
        List<mUserDetails> GetAutoUserNameByMobNoExceptRRT(string firstterm);
        mUserWardMapping GetUserwardMappingByUserId(int UserId,int wardid);
        mUserAttendance GetUserAttendanceByUserIDandDate(int UserID, DateTime Todaydate);
        List<mUserAttendance> GetUserAttendanceByUserID(int UserID);
        int InsertUserAttendanceByUserIDandDate(int UserID, double Longitude, double Latitude, string Image, string Notes, string InOffice, double Distance);
        List<mOffice> GetUserOfficeByUserId(int UserId);
        List<mOffice> GetUserOfficeByUserIdandDate(DateTime? SelectedDate, int? UserId);
    }
}

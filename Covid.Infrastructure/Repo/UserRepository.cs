using Covid.Core.Common;
using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.UserDetails;
using Covid.Core.IRepo;
using Covid.Infrastructure.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.Repo
{
    public class UserRepository : IUserRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        public List<mUserType> GetAllUserType()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mUserType>("select [UserTypeId],[UserType] from UserType").ToList();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public mUserDetails GetUserDetailByMobileNo(long mobilenumber)
        {
            try
            {
                mUserDetails query = new mUserDetails();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mUserDetails>(@"select [UserId],[Password]
                                       ,[MobileNo],[EmailId],[UserTypeId] FROM [UserDetails] 
                                 where MobileNo=@mobilenumber", new { mobilenumber }).SingleOrDefault();
                    connection.Close();
                    query.Password = MappingHelper.Decryptdata(query.Password);
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public mRRTZoneMapping GetUserRRTZoneMappingByUserId(int UserId)
        {
            try
            {
                mRRTZoneMapping query = new mRRTZoneMapping();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mRRTZoneMapping>(@"select [UserId],[LocalBodyId]
                                       ,[ZoneId],[WardId] FROM [RRTZoneMapping] 
                                 where UserId=@UserId", new { UserId }).SingleOrDefault();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mUserDetails> GetAllUserDetail()
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mUserDetails>(@"select [UserId],[Password]
                                       ,[MobileNo],[EmailId],[UserTypeId] FROM [UserDetails]").ToList();
                    connection.Close();
                    foreach(var i in query)
                    {
                        i.Password = MappingHelper.Decryptdata(i.Password);
                    }
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public bool AddUser(mUserDetails user)
        {
            try
            {
                user.Password = MappingHelper.Encryptdata(user.Password);
                bool query = false;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                     connection.Execute(@"INSERT INTO [UserDetails]([Name],[Password],[MobileNo],[EmailId],[UserTypeId])
                                                                VALUES(@Name,@Password,@MobileNo,@EmailId,@UserTypeId)",
                                                                new { user.Name, user.Password, user.MobileNo, user.EmailId, user.UserTypeId });
                    connection.Close();
                    query = true;
                }
                return query;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddRRTZMUser(mRRTZoneMapping user)
        {
            try
            {
                bool query = false;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                     connection.Execute(@"INSERT INTO [RRTZoneMapping]([UserId],[LocalBodyId],[ZoneId],[WardId])
                                                                VALUES(@UserId,@LocalBodyId,@ZoneId,@WardId)",
                                                                new { user.UserId, user.LocalBodyId, user.ZoneId, user.WardId });
                    connection.Close();
                    query = true;
                    
                }
                return query;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddUserMappingWard(int UserId,int Wardid)
        {
            try
            {
                bool query = false;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                   
                        connection.Execute(@"INSERT INTO [UserWardMapping]([UserId],[WardId])
                                                                VALUES(@UserId,@WardId)",
                                                              new { UserId,WardId=Wardid });

                   
                    connection.Close();
                    query = true;

                }
                return query;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<mUserDetails> GetAutoUserNameByMobNo(string firstterm)
        {
            List<mUserDetails> list = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    list = new List<mUserDetails>();
                    int UserTypeId = connection.Query<int>(@"select UserTypeId from UserType where UPPER(UserType)=@UserType", new { UserType = UserTypeCommon.RRT.ToUpper() }).SingleOrDefault();
                    list = connection.Query<mUserDetails>(@"select distinct top 100 [Name],[UserId] FROM [UserDetails] where [MobileNo] like '%" + firstterm + "%' and UserTypeId=@UserTypeId",new { UserTypeId }).ToList();

                    connection.Close();
                    return list;
                }

            }
            catch (SqlException sql)
            {

                return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<mUserDetails> GetAutoUserNameByMobNoExceptRRT(string firstterm)
        {
            List<mUserDetails> list = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    list = new List<mUserDetails>();
                    int UserTypeId = connection.Query<int>(@"select UserTypeId from UserType where UPPER(UserType)=@UserType", new { UserType = UserTypeCommon.RRT.ToUpper() }).SingleOrDefault();
                    list = connection.Query<mUserDetails>(@"select distinct top 100 [Name],[UserId] FROM [UserDetails] where [MobileNo] like '%" + firstterm + "%' and UserTypeId not in (@UserTypeId)", new { UserTypeId }).ToList();

                    connection.Close();
                    return list;
                }

            }
            catch (SqlException sql)
            {

                return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<UserTypeMenuMaster> GetMenuByUserType(int UserTypeId)
        {
            try
            {
                List<UserTypeMenuMaster> query = new List<UserTypeMenuMaster>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<UserTypeMenuMaster>(@"select m.MenuID,m.MenuURL,m.MenuName,ut.UserTypeId,um.OrderBy from MenuTable m Join UserTypeMenuMapping UM on m.MenuID=um.MenuId 
                            Join UserType ut on ut.UserTypeId=um.UserTypeId  where ut.UserTypeId=@UserTypeId order by um.orderby", new { UserTypeId }).ToList();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<mUserAttendance> GetUserAttendanceByUserID(int UserID)
        {
            try
            {
                List<mUserAttendance> query = new List<mUserAttendance>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mUserAttendance>(@"select * from UserAttendance where UserID=@UserID", new { UserID }).ToList();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public mUserAttendance GetUserAttendanceByUserIDandDate(int UserID,DateTime Todaydate)
        {
            try
            {
               mUserAttendance query = new mUserAttendance();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mUserAttendance>(@"select * from UserAttendance where UserID=@UserID and cast(AttendanceDate as date)=cast(@Todaydate as date)", new { UserID,Todaydate }).SingleOrDefault();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int InsertUserAttendanceByUserIDandDate(int UserID, double Longitude,double Latitude,string Image,string Notes,string InOffice,double Distance)
        {
            try
            {
                int query;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                     connection.Execute(@"insert into UserAttendance(UserID,Longitude,Latitude,AttendanceDate,Image,Notes,InOffice,Distance) values(@UserID,@Longitude,@Latitude,@AttendanceDate,@Image,@Notes,@InOffice,@Distance)", new { UserID, Longitude,Latitude, AttendanceDate=DateTime.Now,Image,Notes,InOffice,Distance });
                    query = 1;
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public mUserWardMapping GetUserwardMappingByUserId(int UserId,int wardid)
        {
            try
            {
                mUserWardMapping query = new mUserWardMapping();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mUserWardMapping>(@"select [UserId],[WardId] FROM [UserWardMapping] 
                                 where UserId=@UserId and WardId=@wardid", new { UserId,wardid }).SingleOrDefault();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mOffice> GetUserOfficeByUserId(int UserId)
        {
            try
            {
                List<mOffice> query = new List<mOffice>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mOffice>(@"select o.*,u.UserID,u.Name as UserName,u.MobileNo as MobileNumber,
                                    (select LocalBodyName from LocalBody where LocalBodyID=o.LocalBodyID) as LocalBodyName,
                                    (select LocalBodyName from LocalBody where LocalBodyID=o.ZoneID) as ZoneName,
                                    (select LocalBodyName from LocalBody where LocalBodyID=o.WardID) as WardName
                                     from Office o join UserZoneMapping uz on uz.ZoneID=o.ZoneId 
                                    join UserDetails u on u.userid=uz.userid where u.UserId=@UserId", new { UserId }).ToList();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mOffice> GetUserOfficeByUserIdandDate(DateTime? SelectedDate,int? UserId)
        {
            try
            {
                List<mOffice> query = new List<mOffice>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mOffice>(@"select o.*,u.UserID,u.Name as UserName,u.MobileNo as MobileNumber,ua.AttendanceDate,ua.Image,ua.Longitude as UserLongitude,ua.Latitude as UserLatitude,ua.InOffice,
                                            (select LocalBodyName from LocalBody where LocalBodyID=o.LocalBodyID) as LocalBodyName,
                                            (select LocalBodyName from LocalBody where LocalBodyID=o.ZoneID) as ZoneName,
                                            (select LocalBodyName from LocalBody where LocalBodyID=o.WardID) as WardName
                                             from Office o join UserZoneMapping uz on uz.ZoneID=o.ZoneId 
                                            join UserDetails u on u.userid=uz.userid
                                            join UserAttendance ua on u.userid=ua.Userid where (@Userid is null or u.UserId=@UserId) and (@SelectedDate is null or cast(ua.AttendanceDate as date)= cast(@SelectedDate as date))", new { UserId, SelectedDate }).ToList();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}

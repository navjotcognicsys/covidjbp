using Covid.Core.DBEntities.LocalBody;
using Covid.Core.DBEntities.Master;
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
    public class CommonRepository : ICommonRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        public List<mLocalBody> GetLocalyBody()
        {
           try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyName] from [LocalBody] where LocalBodyParentId=0").ToList();
                    connection.Close();
                    return query;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<mLocalBody> GetZoneOrWardByParentID(int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[LocalBodyName] from [LocalBody] where LocalBodyParentId=@ID", new {ID }).ToList();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<mLocalBody> GetZoneOrWardByUserIdParentID(int UserId, int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyName] from [LocalBody] lb join UserWardMapping um 
                                        on lb.LocalBodyID=um.WardId  where um.UserId=@UserId and LocalBodyParentId=@ID", new { ID,UserId }).ToList();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<mLocalBody> GetWardByParentID(int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyName] from [LocalBody] where MainParentId =@ID", new { ID }).ToList();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<mLocalBody> GetWardByUserIDParentID(int UserId,int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyName] from [LocalBody] lb join UserWardMapping um 
                                        on lb.LocalBodyID=um.WardId  where um.UserId=@UserId and MainParentId =@ID", new { ID,UserId }).ToList();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public mLocalBody GetDetailsbyid(int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[LocalBodyName] from [LocalBody] where LocalBodyID=@ID", new { ID }).SingleOrDefault();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public mLocalBody GetWardParentid(int? ID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mLocalBody>(@"select [LocalBodyID]
                                                                  ,[LocalBodyParentId]
                                                                  ,[LocalBodyType]
                                                                  ,[MainParentId]
                                                                  ,[LocalBodyName] from [LocalBody] where LocalBodyID=@ID", new { ID }).SingleOrDefault();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mInfectionSource> GetInfectionSource()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mInfectionSource>(@"select InfectionId,InfectionSource  from InfectionSource").ToList();
                    connection.Close();
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public mUserType GetUserType(string UserType)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mUserType>("select [UserTypeId],[UserType] from UserType where Upper(UserType)=@UserType",new {UserType }).SingleOrDefault();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public mUserType GetUserTypeByUserTypeId(int UserTypeId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = connection.Query<mUserType>("select [UserTypeId],[UserType] from UserType where UserTypeId=@UserTypeId", new { UserTypeId }).SingleOrDefault();
                    connection.Close();
                    return query;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Core.DBEntities.Master.mCheckPoint> GetCheckPoint()
        {
            try
            {
                List<Core.DBEntities.Master.mCheckPoint> CheckPostList = new List<Core.DBEntities.Master.mCheckPoint>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    CheckPostList = connection.Query<Core.DBEntities.Master.mCheckPoint>(@"select [CheckPointId]
                                          ,[CheckPointName]
                                      FROM [CheckPoint]").ToList();

                    connection.Close();
                    return CheckPostList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

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
        public mUserDetails GetUserDetailByMobileNo(long mobilenumber, string Password)
        {
            try
            {
                Password = MappingHelper.Encryptdata(Password);
                mUserDetails query = new mUserDetails();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    query = connection.Query<mUserDetails>(@"select [UserId],[Name],[Password]
                                       ,[MobileNo],[EmailId],[UserTypeId] FROM [UserDetails] 
                                 where MobileNo=@mobilenumber and Password=@Password", new { mobilenumber, Password }).SingleOrDefault();
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
    }
}

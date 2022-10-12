using Covid.Core.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.Complaint;
using System.Configuration;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Covid.Core.DBEntities.UserDetails;
using Covid.Infrastructure.Helpers;

namespace Covid.Infrastructure.Repo
{
    public class ComplaintRepository : IComplaintRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;

        public List<mComplaintType> GetAllComplaintTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mComplaintType>(@"SELECT 
                                                   [ComplaintTypeId]
                                                  ,[ComplaintTypeName]
                                                  ,[ComplaintCategory]
                                              FROM [dbo].[ComplaintType]").ToList();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }

        }

        public List<mUserDetails> GetAllUserNamesBasedonComplaintType(int ComplaintTypeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mUserDetails>(@"  select ud.Name,ud.UserId 
                                                          from [UserDetails] ud join   ComplaintType  ct
                                                          on ud.UserTypeId=ct.UserType
                                                          join Complaint c on ct.ComplaintTypeId=c.ComplaintTypeId
                                                        where c.ComplaintTypeId=@complaintTypeId", new { @complaintTypeId = ComplaintTypeId }).ToList();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public mComplaint GetComplaintDetailsBasedonId(int ComplaintId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mComplaint>(@"select [ComplaintId],
	                                                        [ComplaintTypeId],
	                                                        [Name],
	                                                        [Address],
	                                                        [MobileNo],
	                                                        [Email],
	                                                        [Status],
	                                                        [CreatedOn],
	                                                        [Details],
	                                                        [AssignTo],
	                                                        [LocalbodyId],
	                                                        [ZoneId],
	                                                        [WardId]
                                                            from Complaint
where ComplaintId=@CompId",new { @CompId=ComplaintId}).FirstOrDefault();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<mComplaint> GetComplaintDetailsListBasedonId(int ComplaintId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mComplaint>(@"select distinct c.[ComplaintId],
	                                                        c.[ComplaintTypeId],
	                                                        c.[Name],
															--ut.UserType as AssignToName,
	                                                        [Address],
	                                                        c.[MobileNo],
	                                                        c.[Email],
	                                                        ca.[Status],
	                                                        [CreatedOn],
                                                            ca.AssignOn,
	                                                        [Details],
	                                                        ca.[AssignTo],
                                                            ca.Remark,
	                                                        [LocalbodyId],
	                                                        [ZoneId],
	                                                        [WardId]
															,ut.UserType as AssignToName
															,ut1.UserType as AssignByName
															from [Complaint] c 
															left join [ComplaintAudit] ca 
															on ca.ComplaintId=c.ComplaintId 
															left join [ComplaintType] ct on c.ComplaintTypeId=ct.ComplaintTypeId
															left join UserType ut on c.AssignTo=ut.UserTypeId
															left join UserType ut1 on ca.AssignBy=ut.UserTypeId
															where c.ComplaintId=@Comp order by CreatedOn", new { @Comp = ComplaintId ,@UserType=SessionHelper.UserDetails.UserTypeId}).ToList();

                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void InsertComplaint(mComplaint ComplaintDetails)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", ComplaintDetails.Name);
                    param.Add("@MobileNo", ComplaintDetails.MobileNo);
                    param.Add("@Address", ComplaintDetails.Address);
                    param.Add("@Email", ComplaintDetails.Email);
                    param.Add("@ComplaintTypeId", ComplaintDetails.ComplaintTypeId);
                    param.Add("@Details", ComplaintDetails.Details);
                    param.Add("@CreatedOn", DateTime.Now);
                    param.Add("@Status", ComplaintDetails.Status);
                    param.Add("@LocalbodyId", ComplaintDetails.LocalbodyId);
                    param.Add("@ZoneId", ComplaintDetails.ZoneId);
                    param.Add("@WardId", ComplaintDetails.WardId);
                    param.Add("@CreatedBy", ComplaintDetails.CreatedBy);
                    param.Add("@AssignTo", ComplaintDetails.WardId == 0 ? 1 : (int?)null);
                    //param.Add("@Mode", CompalintId == null ? 2 : 1);
                    var x = conn.Execute("ComplaintAdd", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
        public void UpdateAssignmentDetails(mComplaint ComplaintDetails)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ComplaintId", ComplaintDetails.ComplaintId);
                    param.Add("@Remark", ComplaintDetails.Remark);
                    param.Add("@AssignOn", DateTime.Now);
                    param.Add("@AssignBy", SessionHelper.UserDetails.UserId);
                    //param.Add("@Details", ComplaintDetails.Details);
                    //param.Add("@CreatedOn", DateTime.Now);
                    param.Add("@Status", ComplaintDetails.Status);
                    param.Add("@LocalbodyId", ComplaintDetails.LocalbodyId);
                    param.Add("@ZoneId", ComplaintDetails.ZoneId);
                    param.Add("@WardId", ComplaintDetails.WardId);
                    param.Add("@AssignTo", ComplaintDetails.WardId == 0 ? 1 : (int?)null);
                    //param.Add("@Mode", CompalintId == null ? 2 : 1);
                    param.Add("@UserType", SessionHelper.UserDetails.UserType);
                    param.Add("@Remark",ComplaintDetails.Remark);
                    var x = conn.Execute("ComplaintAssignAndUpdate", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public List<mComplaint> GetAllComplaintDetails(string LOcalBodyID, string ZoneID, string WardID, string DateOfCreation, int? ComplaintType,string Status)
        {
            try
            {
                if (ZoneID == "")
                    ZoneID = null;
                if (WardID == "")
                    WardID = null;
                if (LOcalBodyID == "")
                    LOcalBodyID = null;
                if (Status == null)
                    Status = "1";
                
                using (var connection = new SqlConnection(connectionString))
                {
                    //List<mComplaint> ComPlaintList = new List<mComplaint>();
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@LOcalBodyID",Convert.ToInt32(LOcalBodyID));
                    param.Add("@ZoneID", Convert.ToInt32(ZoneID));
                    param.Add("@WardID", Convert.ToInt32(WardID));
                    param.Add("@DateOfCreation", null);
                    param.Add("@ComplaintType",ComplaintType);
                    param.Add("@UserTypeId", SessionHelper.UserDetails.UserTypeId);
                    param.Add("@Status",Convert.ToByte(Status));
                    var x= connection.Query<mComplaint>("GetComplaintDetailByFilter", param: param, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<mComplaint> GetAllComplaintDetails(DateTime FromDate, DateTime ToDate,int UserId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = connection.Query<mComplaint>(@"select 
                                                                  [ComplaintId]
                                                                  ,[Name]
                                                                  ,[Address]
, (select Localbodyname from localbody where localbodyid=C.wardid) as wardname
, (select Localbodyname from localbody where localbodyid=C.zoneid) as zonename
                                                                  ,[MobileNo]
                                                                  ,[Email]
                                                                  ,[Status]
                                                                  ,[CreatedOn]
                                                                  ,[Details]
                                                                  ,[CreatedBy]
                                                              FROM [Complaint] C
														    where CreatedBy=@UId and[CreatedOn] BETWEEN @FD AND @TD 
                                                            order by CreatedOn", new { @UId= UserId,@FD= FromDate,@TD= ToDate }).ToList();

                     return x;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<mComplaint> GetAllComplaintDetails(string MobileNumber)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = connection.Query<mComplaint>(@"select distinct c.[ComplaintId],
	                                                        c.[ComplaintTypeId],
	                                                        c.[Name],
															c.[Status],
	                                                        [Address],
	                                                        c.[MobileNo],
	                                                        c.[Email],
	                                                        ca.[Status],
	                                                        [CreatedOn],
                                                            ca.AssignOn,
	                                                        [Details],
	                                                        ca.[AssignTo],
                                                            ca.Remark,
	                                                        [LocalbodyId],
	                                                        [ZoneId],
	                                                        [WardId]
															from [Complaint] c 
															left join [ComplaintAudit] ca 
															on ca.ComplaintId=c.ComplaintId 
															left join [ComplaintType] ct on c.ComplaintTypeId=ct.ComplaintTypeId
														    where c.MobileNo=@Mo order by CreatedOn", new { @Mo = MobileNumber}).ToList();

                    return x;
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

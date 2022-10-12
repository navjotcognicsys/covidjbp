using Covid.Core.IRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.QuarantineCheck;
using Covid.Infrastructure.Helpers;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Covid.Core.DBEntities.Person;

namespace Covid.Infrastructure.Repo
{
    public class QuarantineRepository:IQuarantineRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        
        public mQuarantine GetQuarantineDetails(int PersonId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mQuarantine>(@"SELECT [QuarantineCheckId]
                                                              ,qc.[PersonId]
	                                                          ,p.[PersonName]
	                                                           ,p.StickerDate
                                                              ,[Fever]
                                                              ,[Cough]
                                                              ,[BreathingProblem]
                                                              ,[NA]
                                                              ,qc.[IsSticker]
                                                             ,p.StickerDate
                                                              ,[AnyTrouble]
                                                              ,[AnyNeed]
                                                              ,[Remark]
                                                              ,[Checkedby]
                                                              ,[CheckedOn]
                                                          FROM [dbo].[QuarantineCheck] qc right join Person p on qc.PersonId=p.PersonId where p.PersonId=@personId order by CheckedOn desc", new { @personId=PersonId }).SingleOrDefault();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public mHomeQuarantine GetHomeQuarantineDetails(int PersonId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    var x = conn.Query<mHomeQuarantine>(@"SELECT qc.*,p.*
                        FROM [dbo].[HomeIsolationCheck] qc right join CovidPerson p on qc.PersonId=p.Id where p.Id=@personId order by CreatedOn desc", new { @personId = PersonId }).SingleOrDefault();
                    return x;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        
        public List<mQuarantine> GetQuarantinePersonByPersonId(DateTime? StartDate, DateTime? EndDate)
        {
            try
            {
                List<mQuarantine> PersonDetailList = new List<mQuarantine>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<mQuarantine>(@"SELECT [QuarantineCheckId]
                                                                      ,P.[PersonId]
                                                                       ,P.PersonName
	                                                                  ,P.Mobileno
	                                                                  ,P.Address
                                                                      ,[Fever]
                                                                      ,[Cough]
                                                                      ,[BreathingProblem]
                                                                      ,[NA]
                                                                      ,Q.[IsSticker]
                                                                      ,[AnyTrouble]
                                                                      ,[AnyNeed]
                                                                      ,[Remark]
                                                                      ,[Checkedby]
                                                                      ,[CheckedOn]
,(select PersonName from Person where PersonId=P.personrelationid) as RelatedPersonName
  FROM [QuarantineCheck] Q join Person P on Q.PersonId=P.PersonId where P.Isquarantine=1 and 
((Cast(CheckedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CheckedOn", new {StartDate,EndDate }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mPersonAllDetals> GetNotQuarantinePersonByPersonId(DateTime? StartDate,long PersonId)
        {
            try
            {
                List<mPersonAllDetals> PersonDetailList = new List<mPersonAllDetals>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<mPersonAllDetals>(@"select [PersonId]
                      ,[PersonName]
                      ,[Mobileno]
                      ,[Address]
                      ,[Email]
                      ,[Dateofarrival]
                      ,[ComingFrom]
                      ,[GoingTo]
                      ,[PermanentAddress]
                      ,[HealthStatus]
                      ,[TravelMode]
                      ,[LocalBodyId]
                      ,[ZoneId]
                      ,[WardId]
                      ,[InfectionSource]
                      ,[Isquarantine]
                      ,[IsSticker]
                      ,[QuarantineDate]
                      ,[StickerDate]
                      ,[CreatedBy]
                      ,[CreatedOn]
                      ,[UpdatedBy]
                      ,[UpdatedOn]
                      ,[CheckpostId]
                      ,[IsPositive]
                      ,[IsPermissionPass]
                      ,[TwoMonthsDetails]
                      ,[FifteenDaysDetails]
                      ,[IsCough]
                      ,[IsFever]
                      ,[IsShortnessofBreath]
                      ,[CoronaRemark]
                      ,[IsSuspect]
                      ,[PersonRelationID]
                  FROM [Person] P where P.Isquarantine=1 and P.PersonRelationID =@PersonId and 
P.PersonId NOT IN ( Select PersonId from QuarantineCheck where CAST(CheckedOn as date) = cast(@StartDate as date))", new { StartDate, PersonId }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mCovidPerson> GetHomeQuarantinePersonByPersonId(String RefGroup)
        {
            try
            {
                List<mCovidPerson> PersonDetailList = new List<mCovidPerson>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<mCovidPerson>(@" Select * 
                  FROM [CovidPerson]  where CurrentStatus=0 and RefGroup =@RefGroup And CreatedOn between dateadd(day, -6, getdate()) and getdate()  Order By UpdatedOn", new { RefGroup }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mHomeQuarantine> GetHomeQuarantinePersonByDate(DateTime? StartDate, DateTime? EndDate, String Group)
        {
            try
            {
                List<mHomeQuarantine> PersonDetailList = new List<mHomeQuarantine>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<mHomeQuarantine>(@"SELECT P.* , Q.*
                            FROM [HomeIsolationCheck] Q join CovidPerson P on Q.PersonId=P.Id where P.CurrentStatus=0 and P.RefGroup=@Group and 
                            ((Cast(SampleCollectionDate as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by SampleCollectionDate", 
                            new { StartDate, EndDate, Group }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void UpdateQuarantineDetails(mQuarantine QuarantineDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PersonId", QuarantineDetails.PersonId);
                    //param.Add("@PersonName", QuarantineDetails.PersonName);
                    param.Add("@IsSticker", QuarantineDetails.IsSticker);
                    param.Add("@Fever", QuarantineDetails.Fever);
                    param.Add("@Cough", QuarantineDetails.Cough);
                    param.Add("@BreathingProblem", QuarantineDetails.BreathingProblem);
                    param.Add("@StickerDate", QuarantineDetails.StickerDate == Convert.ToDateTime("01/01/0001") ? null : QuarantineDetails.StickerDate);
                    param.Add("@Remark", QuarantineDetails.Remark);
                    //param.Add("@CreatedOn", DateTime.Now);
                    param.Add("@AnyNeed", QuarantineDetails.AnyNeed);
                    //param.Add("@LocalbodyId", QuarantineDetails.CheckedOn);
                    //param.Add("@CheckedBy", SessionHelper.UserDetails.UserId);
                    param.Add("@CheckedOn", DateTime.Now);
                    param.Add("@NA", QuarantineDetails.NA);
                    param.Add("@AnyTrouble", QuarantineDetails.AnyTrouble);
                    param.Add("@AnyNeed", QuarantineDetails.AnyNeed);
                    param.Add("@IsSticker", QuarantineDetails.IsSticker);
                    param.Add("@CheckedBy", QuarantineDetails.Checkedby);
                    //param.Add("@AssignTo", QuarantineDetails.WardId == 0 ? 1 : (int?)null);
                    //param.Add("@Mode", CompalintId == null ? 2 : 1);
                    var x = conn.Execute("QuarantineCheckADD", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void InsertHomeQuarantineDetails(mHomeQuarantine QuarantineDetails)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PersonId", QuarantineDetails.PersonId);
                    param.Add("@AnyFamilyMemberIssue", QuarantineDetails.AnyFamilyMemberIssue);
                    param.Add("@AnyProblem", QuarantineDetails.AnyProblem);
                    param.Add("@ContactWithFamilyMember", QuarantineDetails.ContactWithFamilyMember);
                    param.Add("@DCCCRemark", QuarantineDetails.DCCCRemark);
                    param.Add("@DoctorRemark", QuarantineDetails.DoctorRemark);
                    param.Add("@DrName", QuarantineDetails.DrName);
                    param.Add("@EPD", QuarantineDetails.EPD);
                    param.Add("@IsBreath", QuarantineDetails.IsBreath);
                    param.Add("@IsCough", QuarantineDetails.IsCough);
                    param.Add("@IsTemp", QuarantineDetails.IsTemp);
                    param.Add("@IsVideoCall", QuarantineDetails.IsVideoCall);
                    param.Add("@IsYogaDoneToday", QuarantineDetails.IsYogaDoneToday);
                    param.Add("@IsYogaIntrested", QuarantineDetails.IsYogaIntrested);
                    param.Add("@IsYogaInstructor", QuarantineDetails.IsYogaInstructor);
                    param.Add("@SPO2", QuarantineDetails.SPO2);
                    param.Add("@Temp", QuarantineDetails.Temp);
                    param.Add("@IsMedicalKit", QuarantineDetails.IsMedicalKit);
                    param.Add("@CreatedBy", QuarantineDetails.CreatedBy);
                    param.Add("@IsolationCheckId", SqlDbType.BigInt, direction: ParameterDirection.Output);
                    var x = conn.Execute("sproc_InsertHomeIsolationCheck", param: param, commandType: CommandType.StoredProcedure);
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}

using Covid.Core.DBEntities.SeroSurve;
using Covid.Core.IRepo;
using Covid.Infrastructure.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.Repo
{
    public class SeroSurveRepository : ISeroSurveRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;

        public long InsertSeroSurve(mSero SeroSurve)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", SeroSurve.Name);
                    param.Add("@Mobile", SeroSurve.Mobile);
                    param.Add("@Address", SeroSurve.Address);
                    param.Add("@Email", SeroSurve.Email);
                    param.Add("@ParentsName", SeroSurve.ParentsName);
                    param.Add("@Age", SeroSurve.Age);
                    param.Add("@Gender", SeroSurve.Gender);
                    param.Add("@IsSamplePossible", SeroSurve.IsSamplePossible);
                    param.Add("@CauseForNoSample", SeroSurve.CauseForNoSample);
                    param.Add("@WardId", SeroSurve.WardId);
                    param.Add("@WardName", SeroSurve.WardName);
                    param.Add("@CreatedBy", SeroSurve.CreatedBy);
                    param.Add("@HighestEdu", SeroSurve.HighestEdu);
                    param.Add("@Occupation", SeroSurve.Occupation);
                    param.Add("@OccupationType", SeroSurve.OccupationType);
                    param.Add("@IsWorkEmergency", SeroSurve.IsWorkEmergency);
                    param.Add("@WhoWork", SeroSurve.WhoWork);
                    param.Add("@GovtId", SeroSurve.GovtId);
                    param.Add("@GovtIdType", SeroSurve.GovtIdType);
                    param.Add("@NumberofFamily", SeroSurve.NumberofFamily);
                    param.Add("@MaleMember", SeroSurve.MaleMember);
                    param.Add("@FemaleMember", SeroSurve.FemaleMember);
                    param.Add("@KidsNumber", SeroSurve.KidsNumber);
                    param.Add("@AdlutNumber", SeroSurve.AdlutNumber);
                    param.Add("@FamilyMontlyIncome", SeroSurve.FamilyMontlyIncome);
                    param.Add("@IsBPL", SeroSurve.IsBPL);
                    param.Add("@HomeType", SeroSurve.HomeType);
                    param.Add("@TotalRoom", SeroSurve.TotalRoom);
                    param.Add("@TotalArea", SeroSurve.TotalArea);
                    param.Add("@HomeArea", SeroSurve.HomeArea);
                    param.Add("@Batroom", SeroSurve.Batroom);
                    param.Add("@IsDiabities", SeroSurve.IsDiabities);
                    param.Add("@BP", SeroSurve.BP);
                    param.Add("@IsCancer", SeroSurve.IsCancer);
                    param.Add("@IsKidney", SeroSurve.IsKidney);
                    param.Add("@IsHeart", SeroSurve.IsHeart);
                    param.Add("@IsLungs", SeroSurve.IsLungs);
                    param.Add("@IsLiver", SeroSurve.IsLiver);
                    param.Add("@IsOrgantransplant", SeroSurve.IsOrgantransplant);
                    param.Add("@IsDisable", SeroSurve.IsDisable);
                    param.Add("@IsBlood", SeroSurve.IsBlood);
                    param.Add("@IsPCR", SeroSurve.IsPCR);
                    param.Add("@IsILI", SeroSurve.IsILI);
                    param.Add("@IsSARI", SeroSurve.IsSARI);
                    param.Add("@id", SqlDbType.BigInt, direction: ParameterDirection.Output);
                    conn.Execute("SeroSurveAdd", param: param, commandType: CommandType.StoredProcedure);
                    int id = param.Get<int>("id");
                    return id;

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return 0;
        }

        public List<mSero> GetAllSeroSurve()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return null;


        }

        public List<mSero> GetSeroSurveReport(DateTime? StartDate, DateTime? EndDate)
        {
            try
            {
                List<mSero> SeroDetailList = new List<mSero>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SeroDetailList = connection.Query<mSero>(@"select [SeroSurveId]
                                      ,[Name]
                                      ,[Address]
                                      ,[ParentsName]
                                      ,[Age]
                                      ,[Gender]
                                      ,[IsSamplePossible]
                                      ,[CauseForNoSample]
                                      ,[Mobile]
                                      ,[Email]
                                      ,[HighestEdu]
                                      ,[Occupation]
                                      ,[OccupationType]
                                      ,[IsWorkEmergency]
                                      ,[WhoWork]
                                      ,[GovtId]
                                      ,[GovtIdType]
                                      ,[NumberofFamily]
                                      ,[MaleMember]
                                      ,[FemaleMember]
                                      ,[KidsNumber]
                                      ,[AdlutNumber]
                                      ,[FamilyMontlyIncome]
                                      ,[IsBPL]
                                      ,[HomeType]
                                      ,[TotalRoom]
                                      ,[TotalArea]
                                      ,[HomeArea]
                                      ,[Batroom]
                                      ,[IsDiabities]
                                      ,[BP]
                                      ,[IsCancer]
                                      ,[IsKidney]
                                      ,[IsHeart]
                                      ,[IsLungs]
                                      ,[IsLiver]
                                      ,[IsOrgantransplant]
                                      ,[IsDisable]
                                      ,[IsBlood]
                                      ,[IsPCR]
                                      ,[IsILI]
                                      ,[IsSARI]
                                      ,[CollectedOn]
                                      ,[CreatedBy]
                                      ,[WardId]
                                      ,[WardName]
                  FROM [SeroSurve]  where ((Cast(CollectedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CollectedOn", new { StartDate, EndDate }).ToList();
                    connection.Close();
                    return SeroDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mSero> GetSeroSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID)
        {
            try
            {
                List<mSero> SeroDetailList = new List<mSero>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SeroDetailList = connection.Query<mSero>(@"select [SeroSurveId]
                                      ,[Name]
                                      ,[Address]
                                      ,[ParentsName]
                                      ,[Age]
                                      ,[Gender]
                                      ,[IsSamplePossible]
                                      ,[CauseForNoSample]
                                      ,[Mobile]
                                      ,[Email]
                                      ,[HighestEdu]
                                      ,[Occupation]
                                      ,[OccupationType]
                                      ,[IsWorkEmergency]
                                      ,[WhoWork]
                                      ,[GovtId]
                                      ,[GovtIdType]
                                      ,[NumberofFamily]
                                      ,[MaleMember]
                                      ,[FemaleMember]
                                      ,[KidsNumber]
                                      ,[AdlutNumber]
                                      ,[FamilyMontlyIncome]
                                      ,[IsBPL]
                                      ,[HomeType]
                                      ,[TotalRoom]
                                      ,[TotalArea]
                                      ,[HomeArea]
                                      ,[Batroom]
                                      ,[IsDiabities]
                                      ,[BP]
                                      ,[IsCancer]
                                      ,[IsKidney]
                                      ,[IsHeart]
                                      ,[IsLungs]
                                      ,[IsLiver]
                                      ,[IsOrgantransplant]
                                      ,[IsDisable]
                                      ,[IsBlood]
                                      ,[IsPCR]
                                      ,[IsILI]
                                      ,[IsSARI]
                                      ,[CollectedOn]
                                      ,[CreatedBy]
                                      ,[WardId]
                                      ,[WardName]
                  FROM [SeroSurve]  where CreatedBy =@UserID and ((Cast(CollectedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CollectedOn", new { StartDate, EndDate, UserID }).ToList();
                    connection.Close();
                    return SeroDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

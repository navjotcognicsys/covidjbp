using Covid.Core.DBEntities.PoleSurve;
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
    public class PoleSurveRepository : IPoleSurveRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;

        public long InsertStreetLightSurve(mStreetLightSurve StreetLightSurve)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IsCable", StreetLightSurve.IsCable);
                    param.Add("@PoleNum", StreetLightSurve.PoleNum);
                    param.Add("@Longitude", StreetLightSurve.Longitude);
                    param.Add("@Latitude", StreetLightSurve.Latitude);

                    param.Add("@FittingType", StreetLightSurve.FittingType);
                    param.Add("@FittingVolt", StreetLightSurve.FittingVolt);
                    param.Add("@PoleType", StreetLightSurve.PoleType);
                    param.Add("@PoleHeight", StreetLightSurve.PoleHeight);

                    param.Add("@RoadWidth", StreetLightSurve.RoadWidth);
                    param.Add("@MountingHeight", StreetLightSurve.MountingHeight);
                    param.Add("@PoleSpan", StreetLightSurve.PoleSpan);
                    param.Add("@AreaType", StreetLightSurve.AreaType);

                    param.Add("@TrafficLevel", StreetLightSurve.TrafficLevel);
                    param.Add("@UserId", StreetLightSurve.UserId);
                    param.Add("@PoleImagePath", StreetLightSurve.PoleImagePath);


                    param.Add("@SLID", SqlDbType.BigInt, direction: ParameterDirection.Output);
                    conn.Execute("StreetLightSurveInsert", param: param, commandType: CommandType.StoredProcedure);
                    int id = param.Get<int>("SLID");
                    return id;

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return 0;
        }

        public long InsertSwitchingSurve(mSwitchingSurve SwitchingSurve)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PointName", SwitchingSurve.PointName);
                    param.Add("@Longitude", SwitchingSurve.Longitude);
                    param.Add("@Latitude", SwitchingSurve.Latitude);
                    param.Add("@MeterNumber", SwitchingSurve.MeterNumber);
                    param.Add("@IVRS", SwitchingSurve.IVRS);
                    param.Add("@ConnectionType", SwitchingSurve.ConnectionType);
                    param.Add("@OperationPhase", SwitchingSurve.OperationPhase);

                    param.Add("@MPPKVVCLDivisionName", SwitchingSurve.MPPKVVCLDivisionName);
                    param.Add("@MPPKVVCLFeederName", SwitchingSurve.MPPKVVCLFeederName);
                    param.Add("@WardId", SwitchingSurve.WardId);
                    param.Add("@WardName", SwitchingSurve.WardName);
                    param.Add("@VoltageRPhase", SwitchingSurve.VoltageRPhase);
                    param.Add("@VoltageYPhase", SwitchingSurve.VoltageYPhase);
                    param.Add("@VoltageBPhase", SwitchingSurve.VoltageBPhase);

                    param.Add("@CurrentRPhase", SwitchingSurve.CurrentRPhase);
                    param.Add("@CurrentYPhase", SwitchingSurve.CurrentYPhase);
                    param.Add("@CurrentBPhase", SwitchingSurve.CurrentBPhase);
                    param.Add("@PowerFactorRPhase", SwitchingSurve.PowerFactorRPhase);
                    param.Add("@PowerFactorYPhase", SwitchingSurve.PowerFactorYPhase);
                    param.Add("@PowerFactorBPhase", SwitchingSurve.PowerFactorBPhase);
                    param.Add("@PowerRPhase", SwitchingSurve.PowerRPhase);

                    param.Add("@PowerYPhase", SwitchingSurve.PowerYPhase);
                    param.Add("@PowerBPhase", SwitchingSurve.PowerBPhase);
                    param.Add("@EnergyRPhase", SwitchingSurve.EnergyRPhase);
                    param.Add("@EnergyYPhase", SwitchingSurve.EnergyYPhase);
                    param.Add("@EnergyBPhase", SwitchingSurve.EnergyBPhase);
                    param.Add("@CurrentReading", SwitchingSurve.CurrentReading);
                    param.Add("@MaxDemand", SwitchingSurve.MaxDemand);

                    param.Add("@DailyConsumtion", SwitchingSurve.DailyConsumtion);
                    param.Add("@MonthlyConsumtion", SwitchingSurve.MonthlyConsumtion);
                    param.Add("@YearlyConsumption", SwitchingSurve.YearlyConsumption);
                    param.Add("@UserId", SwitchingSurve.UserId);
                    param.Add("@SwitchImagePath", SwitchingSurve.SwitchImagePath);

                    param.Add("@SPID", SqlDbType.BigInt, direction: ParameterDirection.Output);
                    conn.Execute("SwitchingSurveInsert", param: param, commandType: CommandType.StoredProcedure);
                    int id = param.Get<int>("SPID");
                    return id;

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return 0;
        }

        public List<mSwitchingSurve> GetAllSwitchingSurve()
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

        public List<mStreetLightSurve> GetAllStreetLightSurve()
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

        public List<mSwitchingSurve> GetSwitchingSurveReport(DateTime? StartDate, DateTime? EndDate)
        {
            try
            {
                List<mSwitchingSurve> SwitchingSurveList = new List<mSwitchingSurve>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  //  SeroDetailList = connection.Query<mSero>(@"select [SeroSurveId]
                  //                    ,[Name]
                  //                    ,[Address]
                  //                    ,[ParentsName]
                  //                    ,[Age]
                  //                    ,[Gender]
                  //                    ,[IsSamplePossible]
                  //                    ,[CauseForNoSample]
                  //                    ,[Mobile]
                  //                    ,[Email]
                  //                    ,[HighestEdu]
                  //                    ,[Occupation]
                  //                    ,[OccupationType]
                  //                    ,[IsWorkEmergency]
                  //                    ,[WhoWork]
                  //                    ,[GovtId]
                  //                    ,[GovtIdType]
                  //                    ,[NumberofFamily]
                  //                    ,[MaleMember]
                  //                    ,[FemaleMember]
                  //                    ,[KidsNumber]
                  //                    ,[AdlutNumber]
                  //                    ,[FamilyMontlyIncome]
                  //                    ,[IsBPL]
                  //                    ,[HomeType]
                  //                    ,[TotalRoom]
                  //                    ,[TotalArea]
                  //                    ,[HomeArea]
                  //                    ,[Batroom]
                  //                    ,[IsDiabities]
                  //                    ,[BP]
                  //                    ,[IsCancer]
                  //                    ,[IsKidney]
                  //                    ,[IsHeart]
                  //                    ,[IsLungs]
                  //                    ,[IsLiver]
                  //                    ,[IsOrgantransplant]
                  //                    ,[IsDisable]
                  //                    ,[IsBlood]
                  //                    ,[IsPCR]
                  //                    ,[IsILI]
                  //                    ,[IsSARI]
                  //                    ,[CollectedOn]
                  //                    ,[CreatedBy]
                  //                    ,[WardId]
                  //                    ,[WardName]
                  //FROM [SeroSurve]  where ((Cast(CollectedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CollectedOn", new { StartDate, EndDate }).ToList();
                    connection.Close();
                    return SwitchingSurveList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mStreetLightSurve> GetStreetLightSurveReport(DateTime? StartDate, DateTime? EndDate)
        {
            try
            {
                List<mStreetLightSurve> StreetLightSurveList = new List<mStreetLightSurve>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   StreetLightSurveList = connection.Query<mStreetLightSurve>(@"SELECT[SLID]
                                              ,[IsCable]
                                              ,[PoleNum]
                                              ,[Longitude]
                                              ,[Latitude]
                                              ,[FittingType]
                                              ,[FittingVolt]
                                              ,[PoleType]
                                              ,[PoleHeight]
                                              ,[RoadWidth]
                                              ,[MountingHeight]
                                              ,[PoleSpan]
                                              ,[AreaType]
                                              ,[TrafficLevel]
                                              ,[SurveDate]
                                              ,[PoleImagePath],
	                                          B.Name AS UserName
                                          FROM [StreetLightSurve] , UserDetails B
                                           where[StreetLightSurve].UserId = B.UserId and 
                     ((Cast(SurveDate as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by SurveDate", new { StartDate, EndDate }).ToList();
                    connection.Close();
                    return StreetLightSurveList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mStreetLightSurve> GetStreetLightSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID)
        {
            try
            {
                List<mStreetLightSurve> StreetLightSurveList = new List<mStreetLightSurve>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  //  SeroDetailList = connection.Query<mSero>(@"select [SeroSurveId]
                  //                    ,[Name]
                  //                    ,[Address]
                  //                    ,[ParentsName]
                  //                    ,[Age]
                  //                    ,[Gender]
                  //                    ,[IsSamplePossible]
                  //                    ,[CauseForNoSample]
                  //                    ,[Mobile]
                  //                    ,[Email]
                  //                    ,[HighestEdu]
                  //                    ,[Occupation]
                  //                    ,[OccupationType]
                  //                    ,[IsWorkEmergency]
                  //                    ,[WhoWork]
                  //                    ,[GovtId]
                  //                    ,[GovtIdType]
                  //                    ,[NumberofFamily]
                  //                    ,[MaleMember]
                  //                    ,[FemaleMember]
                  //                    ,[KidsNumber]
                  //                    ,[AdlutNumber]
                  //                    ,[FamilyMontlyIncome]
                  //                    ,[IsBPL]
                  //                    ,[HomeType]
                  //                    ,[TotalRoom]
                  //                    ,[TotalArea]
                  //                    ,[HomeArea]
                  //                    ,[Batroom]
                  //                    ,[IsDiabities]
                  //                    ,[BP]
                  //                    ,[IsCancer]
                  //                    ,[IsKidney]
                  //                    ,[IsHeart]
                  //                    ,[IsLungs]
                  //                    ,[IsLiver]
                  //                    ,[IsOrgantransplant]
                  //                    ,[IsDisable]
                  //                    ,[IsBlood]
                  //                    ,[IsPCR]
                  //                    ,[IsILI]
                  //                    ,[IsSARI]
                  //                    ,[CollectedOn]
                  //                    ,[CreatedBy]
                  //                    ,[WardId]
                  //                    ,[WardName]
                  //FROM [SeroSurve]  where CreatedBy =@UserID and ((Cast(CollectedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CollectedOn", new { StartDate, EndDate, UserID }).ToList();
                    connection.Close();
                    return StreetLightSurveList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mSwitchingSurve> GetSwitchingSurveForUser(DateTime? StartDate, DateTime? EndDate, int UserID)
        {
            try
            {
                List<mSwitchingSurve> SwitchingSurveDetailList = new List<mSwitchingSurve>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  //  SeroDetailList = connection.Query<mSero>(@"select [SeroSurveId]
                  //                    ,[Name]
                  //                    ,[Address]
                  //                    ,[ParentsName]
                  //                    ,[Age]
                  //                    ,[Gender]
                  //                    ,[IsSamplePossible]
                  //                    ,[CauseForNoSample]
                  //                    ,[Mobile]
                  //                    ,[Email]
                  //                    ,[HighestEdu]
                  //                    ,[Occupation]
                  //                    ,[OccupationType]
                  //                    ,[IsWorkEmergency]
                  //                    ,[WhoWork]
                  //                    ,[GovtId]
                  //                    ,[GovtIdType]
                  //                    ,[NumberofFamily]
                  //                    ,[MaleMember]
                  //                    ,[FemaleMember]
                  //                    ,[KidsNumber]
                  //                    ,[AdlutNumber]
                  //                    ,[FamilyMontlyIncome]
                  //                    ,[IsBPL]
                  //                    ,[HomeType]
                  //                    ,[TotalRoom]
                  //                    ,[TotalArea]
                  //                    ,[HomeArea]
                  //                    ,[Batroom]
                  //                    ,[IsDiabities]
                  //                    ,[BP]
                  //                    ,[IsCancer]
                  //                    ,[IsKidney]
                  //                    ,[IsHeart]
                  //                    ,[IsLungs]
                  //                    ,[IsLiver]
                  //                    ,[IsOrgantransplant]
                  //                    ,[IsDisable]
                  //                    ,[IsBlood]
                  //                    ,[IsPCR]
                  //                    ,[IsILI]
                  //                    ,[IsSARI]
                  //                    ,[CollectedOn]
                  //                    ,[CreatedBy]
                  //                    ,[WardId]
                  //                    ,[WardName]
                  //FROM [SeroSurve]  where CreatedBy =@UserID and ((Cast(CollectedOn as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))  order by CollectedOn", new { StartDate, EndDate, UserID }).ToList();
                    connection.Close();
                    return SwitchingSurveDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

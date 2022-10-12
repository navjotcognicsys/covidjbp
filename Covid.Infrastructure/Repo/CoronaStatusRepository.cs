using Covid.Core.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Covid.Core.DBEntities.CoronaUpdate;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Covid.Infrastructure.Repo
{
    public class CoronaStatusRepository : IPublicDashboardRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;

        public mCoronaCases GetCurrentCoronaDetails()
        {
            try
            {
                mCoronaCases CoronaCurrentStatus = new mCoronaCases();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    CoronaCurrentStatus = connection.Query<mCoronaCases>(@"SELECT Top(1) CaseId,ActiveCases,(SELECT SUM(ActiveCases)  from[CoronaDashboard]) as CumActiveCases , 
                         NegativeCases,(SELECT SUM(NegativeCases)  from[CoronaDashboard]) as CumNegativeCases,(SELECT SUM(ConfirmedCases)  from[CoronaDashboard]) as ConfirmedCases ,
                         RecoveredCases,(SELECT SUM(RecoveredCases)  from[CoronaDashboard]) as CumRecoveredCases,
                         Deaths,(SELECT SUM(Deaths)  from[CoronaDashboard]) as CumDeaths,UpdatedOn,UpdatedBy,AdmitInHospital,HomeIsolation
                         FROM CoronaDashboard
                         ORDER BY UpdatedOn DESC").SingleOrDefault();

                      connection.Close();
                    return CoronaCurrentStatus;
                }

                    
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mHospitalStatus> GetCurrentHospitalStatus()
        {

            try {

                List<mHospitalStatus> CurrentHospitalStatus = new List<mHospitalStatus>();

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    CurrentHospitalStatus = connection.Query<mHospitalStatus> (@"select HM.HoshId,HM.HoshName,HM.HoshCat,HM.HoshAddress,HM.HoshType,HM.Latitude,HM.Longitude
                        ,Hm.IsolationBed as TotalIsolationBed, HM.ICUBed as TotalICUBed, HM.OxygenBed as TotalOxygenBed,HM.Ventilators,
                        HO.ICUBed as OccICUBed, HO.OxygenBed as OccOxygenBed, HO.IsolationBed as OccIsolationBed,
                        HO.UpdatedDate, HO.UpdatedBy
                       from HoshMaster HM, HoshOccupancy HO where HM.HoshId = HO.HoshId
                       Order By HO.UpdatedDate DESC").ToList(); 

                    connection.Close();
                    return CurrentHospitalStatus;
                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void UpdateHospitalData(mHospitalStatus HospitalStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@HoshId", HospitalStatus.HoshId);
                    //param.Add("@PersonName", QuarantineDetails.PersonName);
                    param.Add("@IsolationBed", HospitalStatus.OccIsolationBed);
                    param.Add("@OxygenBed", HospitalStatus.OccOxygenBed);
                    param.Add("@ICUBed", HospitalStatus.OccICUBed);
                    param.Add("@UpdatedDate", HospitalStatus.UpdatedDate);
                    var x = conn.Execute("UpdateHospitalData", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


        }

        public void UpdateHospitalMasterData(mHospitalStatus HospitalStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@HoshId", HospitalStatus.HoshId);
                    param.Add("@IsolationBed", HospitalStatus.TotalIsolationBed);
                    param.Add("@OxygenBed", HospitalStatus.TotalOxygenBed);
                    param.Add("@ICUBed", HospitalStatus.TotalICUBed);
                    param.Add("@Ventilators", HospitalStatus.Ventilators);
                    var x = conn.Execute("UpdateHospitalMasterData", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void CreateCoranaData(mCoronaCases CoronaStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ActiveCases", CoronaStatus.ActiveCases);
                    param.Add("@AdmitInHospital", CoronaStatus.AdmitInHospital);
                    param.Add("@HomeIsolation", CoronaStatus.HomeIsolation);
                    param.Add("@RecoveredCases", CoronaStatus.RecoveredCases);
                    param.Add("@Deaths", CoronaStatus.Deaths);
                    var x = conn.Execute("CreateCoranaData", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}

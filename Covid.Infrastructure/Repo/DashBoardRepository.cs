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
using Covid.Core.DBEntities.Dashboard;
using Covid.Core.DBEntities.Person;

namespace Covid.Infrastructure.Repo
{
    public class DashBoardRepository:IDashboardRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        public List<mDashboard> GetDashboardList(int UserTypeId,int? ID,int UserID)
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UserTypeId", UserTypeId);
                    param.Add("@LZWid", ID);
                    param.Add("@UserID", UserID);
                    var list = connection.Query<mDashboard>("DashBoardData", param: param, commandType: CommandType.StoredProcedure).ToList();

                    connection.Close();
                    return list.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
            }

            return null;
        }

        //person details
        public List<mPersonAllDetals> GetIPersonDeailByFilter(int LOcalBodyID, int ZoneID, int WardID,int Isquarantine,int IsPositive,int? Checkpoint)
        {
            try
            {
                
               
                using (var connection = new SqlConnection(connectionString))
                {
                    List<mPersonAllDetals> PersonList = new List<mPersonAllDetals>();
                    List<mPerson> PersonLista = new List<mPerson>();
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@LOcalBodyID", LOcalBodyID);
                    param.Add("@ZoneID", ZoneID);
                    param.Add("@WardID", WardID);
                    //param.Add("@DateOfArrival", Convert.ToString(DateOfArrival));
                    //param.Add("@HealthStatus", Convert.ToInt32(HealthStatus));
                    //param.Add("@TravalMode", Convert.ToInt32(TravalMode));
                    //param.Add("@InfectionSource", Convert.ToInt32(InfectionSource));
                    //param.Add("@Sticker", Convert.ToInt32(Sticker));
                    //param.Add("@RelatedPersonID", Convert.ToInt32(RelatedPersonID));
                    param.Add("@Isquarantine", Isquarantine);
                    param.Add("@Checkpoint", Checkpoint);
                    param.Add("@IsPositive", IsPositive);
                    PersonList = connection.Query<mPersonAllDetals>("GetPersoDetailByFilterForDash", param: param, commandType: CommandType.StoredProcedure).ToList();
                    
        connection.Close();
                    return PersonList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public List<mComplaint> GetComplaintsByFilter(int LBID,int ZID,int WID,int UserTypeId)
        {
            try
            {


                using (var connection = new SqlConnection(connectionString))
                {
                    List<mComplaint> ComplaintList = new List<mComplaint>();
                    
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@LOcalBodyID", LBID);
                    param.Add("@ZoneID", ZID);
                    param.Add("@WardID", WID);
                    param.Add("@UserTypeId", UserTypeId);
                    ComplaintList = connection.Query<mComplaint>("GetComplaintDetailByFilterDash", param: param, commandType: CommandType.StoredProcedure).ToList();

                    connection.Close();
                    return ComplaintList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<mComplaint> GetComplaintsByUserID(int UserId, int UserTypeId,string UserType)
        {
            try
            {


                using (var connection = new SqlConnection(connectionString))
                {
                    List<mComplaint> ComplaintList = new List<mComplaint>();

                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    
                    param.Add("@UserId", UserId);
                    param.Add("@UserTypeId", UserTypeId);
                    param.Add("@UserType", UserType);
                    ComplaintList = connection.Query<mComplaint>("GetCompaintsByUserId", param: param, commandType: CommandType.StoredProcedure).ToList();

                    connection.Close();
                    return ComplaintList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.PTC;
using Covid.Core.IRepo;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Covid.Infrastructure.Repo
{
    public class PTCGameRepository : IPtcGameRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;

        public List<mPTC> GetGames(int Status)
        {
            List<mPTC> GameDetailList = new List<mPTC>();
            try
            {
               
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    GameDetailList = conn.Query<mPTC>(@"select * from GamePTC where Status=@Status", new { Status }).ToList();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return GameDetailList;
        }

        public int GetGameStatus(int GameId)
        {
            try
            {
                List<mPTC> GameDetailList = new List<mPTC>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    GameDetailList = conn.Query<mPTC>(@"select * from GamePTC where GameId=@GameId", new { GameId }).ToList();
                    conn.Close();
                    return GameDetailList[0].Status;
                }
            }
            catch (Exception ex)
            {

            }
            return -2;
        }

        public void InertGameInDB(int GameId, int Status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@GameId", GameId);
                    //param.Add("@PersonName", QuarantineDetails.PersonName);
                    param.Add("@Status", Status);
                    var x = conn.Execute("InertGameInDB", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void UpadteGameStatusInDB(int GameId, int Status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@GameId", GameId);
                    //param.Add("@PersonName", QuarantineDetails.PersonName);
                    param.Add("@Status", Status);
                    var x = conn.Execute("UpdateGameStatusInDB", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


    }
}

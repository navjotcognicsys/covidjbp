using Covid.Core.DBEntities.UserDetails;
using Covid.Core.IRepo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Infrastructure.Helpers;

namespace Covid.Infrastructure.Repo
{
   public class LoginRepository:ILoginRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        public mUserDetails GetUserDetailByMobileNo(long mobilenumber,string Password)
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
        public bool ChangePassword(string NewPassword, long MobileNumber)
        {
            try
            {
                bool query = false;
                NewPassword = MappingHelper.Encryptdata(NewPassword);
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    connection.Execute(@"Update Userdetails set Password=@NewPassword where MobileNo=@MobileNumber", new { NewPassword, MobileNumber });
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

    }
}

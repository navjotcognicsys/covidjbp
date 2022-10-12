using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.Person;
using Covid.Core.DBEntities.QuarantineCheck;
using Covid.Core.IRepo;
using Dapper;

namespace Covid.Infrastructure.Repo
{
    public class PersonRepository : IPersonRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Covid"].ConnectionString;
        public int AddPerson(mPerson IC, int ModeValue)
        {
            Guid ID = Guid.NewGuid();
            string GUID = Convert.ToString(ID);
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@PersonId", IC.PersonId);
                    param.Add("@PersonName", IC.PersonName.Trim());
                    param.Add("@Mobileno", IC.Mobileno);
                    param.Add("@Address", IC.Address);
                    param.Add("@Email", IC.Email);
                    param.Add("@Dateofarrival", IC.Dateofarrival);
                    param.Add("@ComingFrom", IC.ComingFrom);
                    param.Add("@GoingTo", IC.GoingTo);
                    param.Add("@PermanentAddress", IC.PermanentAddress);
                    param.Add("@HealthStatus", IC.HealthStatus);
                    param.Add("@TravelMode", IC.TravelMode);
                    param.Add("@LocalBodyId", IC.LocalBodyId == 0 ? null : IC.LocalBodyId);
                    param.Add("@ZoneId", IC.ZoneId == 0 ? null : IC.ZoneId);
                    param.Add("@WardId", IC.WardId == 0 ? null : IC.WardId);
                    param.Add("@InfectionSource", IC.InfectionSource);
                    param.Add("@Isquarantine", IC.Isquarantine);
                    param.Add("@IsSticker", IC.IsSticker);
                    param.Add("@QuarantineDate", IC.QuarantineDate);
                    param.Add("@StickerDate", IC.StickerDate);
                    param.Add("@CreatedBy", IC.CreatedBy);
                    param.Add("@CreatedOn", DateTime.Now);
                    param.Add("@UpdatedBy", IC.UpdatedBy);
                    param.Add("@UpdatedOn", DateTime.Now);
                    param.Add("@CheckpostId", IC.CheckpostId == 0 ? null : IC.CheckpostId);
                    param.Add("@IsPositive", IC.IsPositive);
                    param.Add("@Mode", ModeValue);
                    param.Add("@IsSuspect", IC.IsSuspect);
                    param.Add("@PersonRelationID", IC.PersonRelationID);
                  
                    param.Add("@IsPermissionPass", IC.IsPermissionPass);
                    param.Add("@TwoMonthsDetails", IC.TwoMonthsDetails);
                    param.Add("@FifteenDaysDetails", IC.FifteenDaysDetails);
                    param.Add("@IsCough", IC.IsCough);
                    param.Add("@IsFever", IC.IsFever);
                    param.Add("@IsShortnessofBreath", IC.IsShortnessofBreath);
                    param.Add("@CoronaRemark", IC.CoronaRemark);
                    param.Add("@CurrentLocation", IC.CurrentLocation);
                    //Calling stored pocedure.
                    var PersonID = connection.Query<int>("PersonADD", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    connection.Close();
                    return Convert.ToInt32(PersonID);
                }
            }
            catch (Exception ex)
            {
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
                return 0;
            }


        }

        public int AddCovidPerson(mCovidPerson IC)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SampleId", IC.SampleId.Trim());
                    param.Add("@SRFID", IC.SRFID);
                    param.Add("@ICMRID", IC.ICMRID);
                    param.Add("@Address", IC.Address);
                    param.Add("@SampleCollectionDate", IC.SampleCollectionDate);
                    param.Add("@PatientName", IC.PatientName);
                    param.Add("@Age", IC.Age);
                    param.Add("@FileNum", IC.FileNum);
                    param.Add("@MobileNumber", IC.MobileNumber);
                    param.Add("@SampleTakenBy", IC.SampleTakenBy);
                    param.Add("@LocalBodyId", IC.LocalBodyId == 0 ? null : IC.LocalBodyId);
                    param.Add("@ZoneId", IC.ZoneId == 0 ? null : IC.ZoneId);
                    param.Add("@WardId", IC.WardId == 0 ? null : IC.WardId);
                    param.Add("@SDM", IC.SDM);
                    param.Add("@IsSymtoms", IC.IsSymtoms);
                    param.Add("@Symtoms", IC.Symtoms);
                    param.Add("@TravelDetails", IC.TravelDetails);
                    param.Add("@WorkDetails", IC.WorkDetails);
                    param.Add("@FamilyMemberCuount", IC.FamilyMemberCuount);
                    param.Add("@FiftyPlus", IC.FiftyPlus);
                    param.Add("@AnyIssueFiftyPlus", IC.AnyIssueFiftyPlus);
                    param.Add("@RoomCount", IC.RoomCount);
                    param.Add("@IsVaccine", IC.IsVaccine);
                    param.Add("@DoesCount", IC.DoesCount);
                    param.Add("@MedicalKit", IC.MedicalKit);
                    param.Add("@CurrentStatus", IC.CurrentStatus);
                    param.Add("@Comments", IC.Comments);
                    //Calling stored pocedure.
                    var CovidPersonID = connection.Query<int>("sproc_InsertCovidPerson", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    connection.Close();
                    return Convert.ToInt32(CovidPersonID);
                }
            }
            catch (Exception ex)
            {
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
                return 0;
            }
        }

        public int UpdateCovidPerson(mCovidPerson IC)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", IC.Id);
                    param.Add("@IsSymtoms", IC.IsSymtoms);
                    param.Add("@Symtoms", IC.Symtoms);
                    param.Add("@TravelDetails", IC.TravelDetails);
                    param.Add("@WorkDetails", IC.WorkDetails);
                    param.Add("@FamilyMemberCuount", IC.FamilyMemberCuount);
                    param.Add("@FiftyPlus", IC.FiftyPlus);
                    param.Add("@AnyIssueFiftyPlus", IC.AnyIssueFiftyPlus);
                    param.Add("@RoomCount", IC.RoomCount);
                    param.Add("@IsVaccine", IC.IsVaccine);
                    param.Add("@DoesCount", IC.DoesCount);
                    param.Add("@MedicalKit", IC.MedicalKit);
                    param.Add("@CurrentStatus", IC.CurrentStatus);
                    param.Add("@UpdatedBy", IC.UpdatedBy);
                    param.Add("@Comments", IC.Comments);
                    //Calling stored pocedure.
                    var CovidPersonID = connection.Query<int>("sproc_UpdateCovidPerson", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    connection.Close();
                    return Convert.ToInt32(CovidPersonID);
                }
            }
            catch (Exception ex)
            {
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
                return 0;
            }
        }
        public int AddOutSiderPerson(mOutSiderForm IC, int ModeValue)
        {
            Guid ID = Guid.NewGuid();
            string GUID = Convert.ToString(ID);
            
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ID", IC.ID);
                    param.Add("@Name", IC.Name.Trim());
                    param.Add("@Gender", IC.Gender.Trim());
                    param.Add("@MobileNumber", IC.MobileNumber);
                    param.Add("@AddressofJabalpur", IC.AddressofJabalpur);
                    param.Add("@ComingAddressofOtherState", IC.ComingAddressofOtherState);
                    param.Add("@GoingAddressofOtherState", IC.GoingAddressofOtherState);
                    param.Add("@ComingFromOtherState", IC.ComingFromOtherState);
                    param.Add("@GoingToOtherState", IC.GoingToOtherState);
                   
                    param.Add("@Mode", ModeValue);
                    param.Add("@Occupation", IC.Occupation);
                    param.Add("@NoofPersons", IC.NoofPersons);

                   
                    //Calling stored pocedure.
                    var PersonID = connection.Query<int>("OutSiderPersonADD", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    connection.Close();
                    return Convert.ToInt32(PersonID);
                }
            }
            catch (Exception ex)
            {
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
                return 0;
            }


        }

        public mPerson GePerson(long PersonId)
        {
            try
            {
                mPerson PersonDetail = new mPerson();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPerson>(@"select [PersonId]
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
                      ,[CurrentLocation]
                  FROM [Person] where PersonId=@PersonId", new { PersonId }).SingleOrDefault();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public mCovidPerson GetCovidPerson(long PersonId)
        {
            try
            {
                mCovidPerson PersonDetail = new mCovidPerson();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  PersonDetail = connection.Query<mCovidPerson>(@"select *
                  FROM [CovidPerson] where Id=@PersonId", new { PersonId }).SingleOrDefault();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public mPersonAllDetals GetAlldetailsPerson(long PersonId)
        {
            try
            {
                mPersonAllDetals PersonDetail = new mPersonAllDetals();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPersonAllDetals>(@"SELECT  [PersonId]
      ,[PersonName]
      ,[Mobileno]
      ,[Address]
      ,[Email]
      ,[Dateofarrival]
      ,[ComingFrom]
      ,[GoingTo]
      ,[PermanentAddress]
	   ,case when [HealthStatus]=1 then 'Sick' else 'Fit' end as [HealthStatus]
      
      ,[TravelMode]
      ,(select LocalbodyName from Localbody where localbodyid=P.LocalBodyId) as LocalBody
	  ,(select LocalbodyName from Localbody where localbodyid=P.WardID) as WardID
	  ,(select LocalbodyName from Localbody where localbodyid=P.ZoneID) as ZoneID
      --,LB.[LocalBodyName] as ZoneName
      --,LB.[LocalBodyName] as WardName
      ,ID.[InfectionSource]
	  ,case when [Isquarantine]=1 then 'Yes' else 'No' end as [Isquarantine]
      ,case when [IsSticker]=1 then 'Yes' else 'No' end as [IsSticker]
      ,[QuarantineDate]
      ,[StickerDate]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
	  --,CheckpostId
      ,CheckPointName  as  CheckpostId
	   ,case when [IsPositive]=1 then 'Yes' else 'No' end as [IsPositive]
      ,case when [IsPermissionPass]=1 then 'Yes' else 'No' end as [IsPermissionPass]
      ,[TwoMonthsDetails]
      ,[FifteenDaysDetails]
	  ,case when [IsCough]=1 then 'Yes' else 'No' end as [IsCough]
      ,case when [IsFever]=1 then 'Yes' else 'No' end as [IsFever]
      ,case when [IsShortnessofBreath]=1 then 'Yes' else 'No' end as [IsShortnessofBreath]
      ,[CoronaRemark]
	  ,case when [IsSuspect]=1 then 'Yes' else 'No' end as [IsSuspect]
      ,[PersonRelationID]
      ,[CurrentLocation]
  FROM [Person] P left join [InfectionSource] ID 
  on ID.InfectionId=p.InfectionSource 
 left join [CheckPoint] CP on CP.checkpointID=[CheckpostId] where PersonId=@PersonId", new { PersonId }).SingleOrDefault();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mQuarantine> GetQuarantinePersonByPersonId(long PersonID)
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
  FROM [QuarantineCheck] Q join Person P on Q.PersonId=P.PersonId where P.Isquarantine=1 and P.PersonID=@PersonID order by CheckedOn", new { PersonID }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<PersonTreeView> GetAlldetailsPersonforTree(long PersonId)
        {
            try
            {
                List<PersonTreeView> PersonDetail = new List<PersonTreeView>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<PersonTreeView>(@"SELECT  [PersonId]
      ,[PersonName]
      ,[Mobileno]
      ,[Address]
      ,[Email]
      ,[Dateofarrival]
      ,[ComingFrom]
      ,[GoingTo]
      ,[PermanentAddress]
	   ,case when [HealthStatus]=1 then 'Sick' else 'Fit' end as [HealthStatus]
      
      ,[TravelMode]
      ,(select LocalbodyName from Localbody where localbodyid=P.LocalBodyId) as LocalBody
	  ,(select LocalbodyName from Localbody where localbodyid=P.WardID) as WardID
	  ,(select LocalbodyName from Localbody where localbodyid=P.ZoneID) as ZoneID
      --,LB.[LocalBodyName] as ZoneName
      --,LB.[LocalBodyName] as WardName
      ,ID.[InfectionSource]
	  ,case when [Isquarantine]=1 then 'Yes' else 'No' end as [Isquarantine]
      ,case when [IsSticker]=1 then 'Yes' else 'No' end as [IsSticker]
      ,[QuarantineDate]
      ,[StickerDate]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
	  --,CheckpostId
      ,CheckPointName  as  CheckpostId
	   ,case when [IsPositive]=1 then 'Yes' else 'No' end as [IsPositive]
      ,case when [IsPermissionPass]=1 then 'Yes' else 'No' end as [IsPermissionPass]
      ,[TwoMonthsDetails]
      ,[FifteenDaysDetails]
	  ,case when [IsCough]=1 then 'Yes' else 'No' end as [IsCough]
      ,case when [IsFever]=1 then 'Yes' else 'No' end as [IsFever]
      ,case when [IsShortnessofBreath]=1 then 'Yes' else 'No' end as [IsShortnessofBreath]
      ,[CoronaRemark]
	  ,case when [IsSuspect]=1 then 'Yes' else 'No' end as [IsSuspect]
      ,[PersonRelationID]
      ,[CurrentLocation]
  FROM [Person] P left join [InfectionSource] ID 
  on ID.InfectionId=p.InfectionSource 
 left join [CheckPoint] CP on CP.checkpointID=[CheckpostId] where PersonId=@PersonId", new { PersonId }).ToList();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mOutSiderForm> GetNewEntryPersondetailByDate(DateTime? StartDate, DateTime? EndDate)
        {
            try
            {
                List<mOutSiderForm> PersonDetailList = new List<mOutSiderForm>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<mOutSiderForm>(@"SELECT  [ID]
                                                                  ,[Name]
                                                                  ,[Gender]
                                                                  ,[MobileNumber]
                                                                  ,[ComingFromOtherState]
                                                                  ,[ComingAddressofOtherState]
                                                                  ,[GoingToOtherState]
                                                                  ,[GoingAddressofOtherState]
                                                                  ,[AddressofJabalpur]
                                                                  ,[Occupation]
                                                                  ,[NoofPersons]
                                                                  ,[CreatedDate]
                                                              FROM [OutSiderForm] where ((Cast(CreatedDate as date) Between cast(@StartDate as date) and  cast(@EndDate as date)))", new { StartDate, EndDate }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mPersonAllDetals> GetAlldetailsPersonBySearch(string Search)
        {
            try
            {
                List<mPersonAllDetals> PersonDetail = new List<mPersonAllDetals>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPersonAllDetals>(@"SELECT  [PersonId]
      ,[PersonName]
      ,[Mobileno]
      ,[Address]
      ,[Email]
      ,[Dateofarrival]
      ,[ComingFrom]
      ,[GoingTo]
      ,[PermanentAddress]
	   ,case when [HealthStatus]=1 then 'Sick' else 'Fit' end as [HealthStatus]
      
      ,[TravelMode]
      ,(select LocalbodyName from Localbody where localbodyid=P.LocalBodyId) as LocalBody
	  ,(select LocalbodyName from Localbody where localbodyid=P.WardID) as WardID
	  ,(select LocalbodyName from Localbody where localbodyid=P.ZoneID) as ZoneID
      --,LB.[LocalBodyName] as ZoneName
      --,LB.[LocalBodyName] as WardName
      ,ID.[InfectionSource]
	  ,case when [Isquarantine]=1 then 'Yes' else 'No' end as [Isquarantine]
      ,case when [IsSticker]=1 then 'Yes' else 'No' end as [IsSticker]
      ,[QuarantineDate]
      ,[StickerDate]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
	  --,CheckpostId
      ,CheckPointName  as  CheckpostId
	   ,case when [IsPositive]=1 then 'Yes' else 'No' end as [IsPositive]
      ,case when [IsPermissionPass]=1 then 'Yes' else 'No' end as [IsPermissionPass]
      ,[TwoMonthsDetails]
      ,[FifteenDaysDetails]
	  ,case when [IsCough]=1 then 'Yes' else 'No' end as [IsCough]
      ,case when [IsFever]=1 then 'Yes' else 'No' end as [IsFever]
      ,case when [IsShortnessofBreath]=1 then 'Yes' else 'No' end as [IsShortnessofBreath]
      ,[CoronaRemark]
	  ,case when [IsSuspect]=1 then 'Yes' else 'No' end as [IsSuspect]
      ,[PersonRelationID]
      ,[CurrentLocation]
  FROM [Person] P left join [InfectionSource] ID 
  on ID.InfectionId=p.InfectionSource 
 left join [CheckPoint] CP on CP.checkpointID=[CheckpostId] where (@Search is null or (cast(PersonId as varchar(50))=@Search or MobileNo like '%"+@Search+"%' or PersonName like '%"+@Search+"%'))", new { Search }).ToList();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mPersonAllDetals> GetAllpersonwithoutWard(long? PersonId)
        {
            try
            {
                List<mPersonAllDetals> PersonDetail = new List<mPersonAllDetals>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPersonAllDetals>(@"SELECT Top (50) [PersonId]
                                                                              ,[PersonName]
                                                                              ,[Mobileno]
                                                                              ,[Address]
                                                                              ,[PersonRelationID]
                                                                          FROM [Person] 
                                                                        where WardID is null and (@PersonId is null or PersonRelationID = @PersonId)",new { PersonId }).ToList();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<PersonTreeView> GeRelatedPerson(long PersonId)
        {
            try
            {
                List<PersonTreeView> PersonDetailList = new List<PersonTreeView>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<PersonTreeView>(@"select [PersonId]
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
                      ,[CurrentLocation]
                  FROM [Person] where PersonRelationID=@PersonId", new { PersonId }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<PersonTreeView> GeListRetalionbySQL(long PersonId)
        {
            try
            {
                List<PersonTreeView> PersonDetailList = new List<PersonTreeView>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetailList = connection.Query<PersonTreeView>(@"       
                                With PersonCTE as
                                (
                                    select PT.* from Person PT where PersonId=@PersonId
	                                union all
                                    select P.* from Person P JOIN PersonCTE ON P.PersonRelationID= PersonCTE.PersonId
                                )
                                SELECT* FROM PersonCTE", new { PersonId }).ToList();
                    connection.Close();
                    return PersonDetailList;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mPersonAllDetals> GetIPersonDeailByFilter(string LOcalBodyID, string ZoneID, string WardID, string DateOfArrival, string Quarantine, string HealthStatus,
            string TravalMode,string PersonName, string ComingFrom, string InfectionSource, string Sticker, int? RelatedPersonID, int? CheckPoint, string Sick, string Fever, string ShortnessofBreath,string CurrentLocation)
        {
            try
            {
                List<mPersonAllDetals> PersonList = new List<mPersonAllDetals>();
                if (ZoneID == "")
                    ZoneID = null;
                if (WardID == "")
                    WardID = null;
                if (TravalMode == "")
                    TravalMode = null;
                if (PersonName == "")
                    PersonName = null;
                if (ComingFrom == "")
                    ComingFrom = null;
                if (Quarantine == "")
                    Quarantine = null;
                if (HealthStatus == "")
                    HealthStatus = null;
                if (Sticker == "")
                    Sticker = null;
                if (InfectionSource == "")
                    InfectionSource = null;
                if (Sick == "")
                    Sick = null;
                if (Fever == "")
                    Fever = null;
                if (ShortnessofBreath == "")
                    ShortnessofBreath = null;
                if (CurrentLocation == "")
                    CurrentLocation = null;
                using (var connection = new SqlConnection(connectionString))
                {
                    List<mPersonAllDetals> PersonLista = new List<mPersonAllDetals>();
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();

                    if (LOcalBodyID == null)
                    {
                        param.Add("@LOcalBodyID", LOcalBodyID);
                    }
                    else
                    {
                        param.Add("@LOcalBodyID", Convert.ToInt32(LOcalBodyID));
                    }
                    if (ZoneID == null)
                    {
                        param.Add("@ZoneID", ZoneID);
                    }
                    else
                    {
                        param.Add("@ZoneID", Convert.ToInt32(ZoneID));
                    }
                    if (WardID == null)
                    {
                        param.Add("@WardID", WardID);
                    }
                    else
                    {
                        param.Add("@WardID", Convert.ToInt32(WardID));
                    }
                    if (Quarantine == null)
                    {
                        param.Add("@Quarantine", Quarantine);
                    }
                    else
                    {
                        param.Add("@Quarantine", Convert.ToInt32(Quarantine));
                    }
                    if (HealthStatus == null)
                    {
                        param.Add("@HealthStatus", HealthStatus);
                    }
                    else
                    {
                        param.Add("@HealthStatus", Convert.ToInt32(HealthStatus));
                    }
                    param.Add("@TravalMode", TravalMode);
                    param.Add("@PersonName", PersonName);
                    param.Add("@ComingFrom", ComingFrom);
                    if (InfectionSource == null)
                    {
                        param.Add("@InfectionSource", InfectionSource);
                    }
                    else
                    {
                        param.Add("@InfectionSource", Convert.ToInt32(InfectionSource));
                    }
                    if (Sticker == null)
                    {
                        param.Add("@Sticker", Sticker);
                    }
                    else
                    {
                        param.Add("@Sticker", Convert.ToInt32(Sticker));
                    }

                    param.Add("@RelatedPersonID", RelatedPersonID);
                    param.Add("@CheckPoint", CheckPoint);
                    param.Add("@CurrentLocation", CurrentLocation);
                    if (ShortnessofBreath == null)
                    {
                        param.Add("@ShortnessofBreath", ShortnessofBreath);
                    }
                    else
                    {
                        param.Add("@ShortnessofBreath", Convert.ToInt32(ShortnessofBreath));
                    }

                    if (Sick == null)
                    {
                        param.Add("@Sick", Sick);
                    }
                    else
                    {
                        param.Add("@Sick", Convert.ToInt32(Sick));
                    }
                    if (Fever == null)
                    {
                        param.Add("@Fever", Fever);
                    }
                    else
                    {
                        param.Add("@Fever", Convert.ToInt32(Fever));
                    }
                    PersonList = connection.Query<mPersonAllDetals>("GetPersoDetailByFilter", param: param, commandType: CommandType.StoredProcedure).ToList();

                    connection.Close();
                    return PersonList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public List<mCovidPerson> GetCovidPersonDeailByFilter(string LocalBodyID, string ZoneID, string WardID, string CurrentStatus, string refGroup)
        {
            try
            {
                List<mCovidPerson> PersonList = new List<mCovidPerson>();
                if (ZoneID == "")
                    ZoneID = null;
                if (WardID == "")
                    WardID = null;
                if (LocalBodyID == "")
                    LocalBodyID = null;
                if (CurrentStatus == "")
                    CurrentStatus = null;
                
                using (var connection = new SqlConnection(connectionString))
                {
                    List<mCovidPerson> PersonLista = new List<mCovidPerson>();
                    connection.Open();
                    string SqlQuery = string.Empty;

                    SqlQuery = "Select * From CovidPerson Where ";
                    Dictionary<string, string> wherecondition = new Dictionary<string, string>();

                    if (LocalBodyID != null)
                    {
                        wherecondition.Add("LocalBodyID", LocalBodyID);
                    }
                    if (ZoneID != null)
                    {
                        wherecondition.Add("ZoneID", ZoneID);
                    }
                    if (WardID != null)
                    {
                        wherecondition.Add("WardID", WardID);
                    }
                    if (CurrentStatus != null)
                    {
                        wherecondition.Add("CurrentStatus", CurrentStatus);
                    }
                    if (refGroup != null )
                    {
                        wherecondition.Add("RefGroup", refGroup);
                    }

                    foreach (KeyValuePair<string, string> key in wherecondition)
                    {
                        if (key.Key == "RefGroup")
                        {
                            SqlQuery += key.Key + " = '" + key.Value + "'" + " and ";
                        }
                        else
                        {
                            SqlQuery += key.Key + " = " + key.Value +  " and ";
                        }
                    }

                    SqlQuery = SqlQuery.Remove(SqlQuery.LastIndexOf("and"));
                    PersonList = connection.Query<mCovidPerson>(SqlQuery).ToList();

                    connection.Close();
                    return PersonList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public mPerson GetPersonExistByNameandMobile(string Name, string MobileNumber)
        {
            try
            {
                mPerson PersonDetail = new mPerson();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPerson>(@"select [PersonId]
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
                      ,[CurrentLocation]
                  FROM [Person] where UPPER(PersonName) = @Name and Mobileno=@MobileNumber", new { Name = Name.Trim().ToUpper(), MobileNumber }).SingleOrDefault();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mPerson> GetPositivePersonDetail()
        {
            try
            {
                List<mPerson> PersonDetail = new List<mPerson>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPerson>(@"select [PersonId]
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
                      ,[CurrentLocation]
                  FROM [Person] where IsPositive=1").ToList();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<mPerson> GetCurrenTLocationDetail()
        {
            try
            {
                List<mPerson> PersonDetail = new List<mPerson>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    PersonDetail = connection.Query<mPerson>(@"select distinct [CurrentLocation] FROM [Person] where CurrentLocation is not null").ToList();
                    connection.Close();
                    return PersonDetail;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<mRefGroup> GetRefGroupDetail()
        {
            try
            {
                List<mRefGroup> refGroupDetails = new List<mRefGroup>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    refGroupDetails = connection.Query<mRefGroup>(@"select RefGroup FROM [RefGroup] ").ToList();
                    connection.Close();
                    return refGroupDetails;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void UpdateWardIdLocalBodyIdZoneIdPerson(int? WardId,int? LocalBodyId,int?ZoneId,long PersonId)
        {
            Guid ID = Guid.NewGuid();
            string GUID = Convert.ToString(ID);
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var q = connection.Execute(@"Update Person set WardId=@WardId,ZoneId=@ZoneId,LocalBodyId=@LocalBodyId
                                                 where PersonId=@PersonId",new {WardId,ZoneId,LocalBodyId,PersonId });

                    connection.Close();
                   
                }
            }
            catch (Exception ex)
            {
                //Log.WriteTraceLog("Message :" + ex.Message + "StackTrace:" + ex.StackTrace);
               
            }


        }
    }
}

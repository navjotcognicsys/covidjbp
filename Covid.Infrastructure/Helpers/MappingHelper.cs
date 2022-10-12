using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Infrastructure.Helpers
{
    public static class MappingHelper
    {
        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            // Use reflection to get property names, to create table, Only first time, others 
            //will follow 
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        public static string CauseForNoSample (int id)
        {
            string CauseForNoSample = string.Empty;
            switch (id)
            {
                case 1:
                    CauseForNoSample = "सहमति प्राप्त नहीं";
                    break;
                case 2:
                    CauseForNoSample = "सभी रहवासिओं का RT-PCR पॉजिटिव होना";
                    break;
                case 3:
                    CauseForNoSample = "किसी भी रहवासी का योग्य न होना";
                    break;
                case 4:
                    CauseForNoSample = "मकान बंद होना";
                    break;
                case 5:
                    CauseForNoSample = "किसी का भी जबलपुर रहवासी न होना";
                    break;
                case 6:
                    CauseForNoSample = "कोई भी अन्य अपेक्षित कारण";
                    break;
            }
            return CauseForNoSample;
        }

        public static string WhoWork(int id)
        {
            string WhoWork = string.Empty;
            switch (id)
            {
                case 1:
                    WhoWork = "डॉक्टर";
                    break;
                case 2:
                    WhoWork = "एएनएम";
                    break;
                case 3:
                    WhoWork = "आशा";
                    break;
                case 4:
                    WhoWork = "पुलिस";
                    break;
                case 5:
                    WhoWork = "रिटेलर";
                    break;
                case 6:
                    WhoWork = "डिलीवरी बॉय";
                    break;
                case 7:
                    WhoWork = "बैंक";
                    break;
                case 8:
                    WhoWork = "सब्जी विक्रेता";
                    break;
                case 9:
                    WhoWork = "दूध विक्रेता";
                    break;
                case 10:
                    WhoWork = "किसान";
                    break;
                case 11:
                    WhoWork = "किराना विक्रेता";
                    break;
                case 12:
                    WhoWork = "मेडिकल स्टोर";
                    break;
                case 13:
                    WhoWork = "ड्राईवर";
                    break;
                case 14:
                    WhoWork = "Other";
                    break;
            }
            return WhoWork;
        }

        public static string HigherEducation(int id)
        {
            string HigherEducation = string.Empty;
            switch (id)
            {
                case 1:
                    HigherEducation = "निरक्षर";
                    break;
                case 2:
                    HigherEducation = "प्राथमिक शिक्षा";
                    break;
                case 3:
                    HigherEducation = "माध्यमिक";
                    break;
                case 4:
                    HigherEducation = "स्नातक";
                    break;
                case 5:
                    HigherEducation = "स्नातकोत्तर";
                    break;
                case 6:
                    HigherEducation = "व्यावसायिक";
                    break;
            }
            return HigherEducation;
        }
        public static string OccupationType(int id)
        {
            string OccupationType = string.Empty;
            switch (id)
            {
                case 1:
                    OccupationType = "स्वरोजगार";
                    break;
                case 2:
                    OccupationType = "वेतनभोगी नौकरी";
                    break;
                case 3:
                    OccupationType = "दैनिक मज़दूरी";
                    break;
                case 4:
                    OccupationType = "व्यवसाय";
                    break;
                case 5:
                    OccupationType = "अन्य";
                    break;
                
            }
            return OccupationType;
        }

        public static string GovtIdType(int id)
        {
            string GovtIdType = string.Empty;
            switch (id)
            {
                case 1:
                    GovtIdType = "Adhar";
                    break;
                case 2:
                    GovtIdType = "PAN";
                    break;
                case 3:
                    GovtIdType = "Driving Licenece";
                    break;
                case 4:
                    GovtIdType = "Voter ID";
                    break;
                case 5:
                    GovtIdType = "Other";
                    break;

            }
            return GovtIdType;
        }
        public static string BathFacility(int id)
        {
            string BathFacility = string.Empty;
            switch (id)
            {
                case 1:
                    BathFacility = "घर में सबके लिए एक";
                    break;
                case 2:
                    BathFacility = "सामुदायिक";
                    break;
                case 3:
                    BathFacility = "सबके लिए अलग अलग";
                    break;
            }
            return BathFacility;
        }

        public static string HomeType(int id)
        {
            string HomeType = string.Empty;
            switch (id)
            {
                case 1:
                    HomeType = "स्वतंत्र घर";
                    break;
                case 2:
                    HomeType = "अपार्टमेंट";
                    break;
                case 3:
                    HomeType = "सोसायटी";
                    break;
            }
            return HomeType;
        }
    }
}

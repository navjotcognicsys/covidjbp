using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Enum
{
    public enum Status
    {
        SUSPECT = 0,
        CLEARED = 1
    }
    public enum ComplaintTypes
    {
        FOOD = 0,
        CLEARED = 1,
        AMBULANCE = 2,
        DOCTOR = 3
    }

    public enum ComplaintStatus
    {
        OPEN = 1,
        WORKING = 2,
        CLOSED = 3,
        REJECTED = 4
    }

    public enum CauseForNoSample
    {
        NotApproved = 1,
        RTPCR = 2,
        NoAble = 3,
        HomeClosed = 4,
        NotFromJBP = 5,
        Other = 6
    }

    public enum HighestEdu
    {
        Illiterate=1,
        Primary=2,
        Middle =3,
        Graduate=4,
        PostGraduate=5,
        Professional=6
    }
    public enum OccupationType
    {
        SelfEmployee =1,
        Job =2,
        DailyWorker=3,
        Business=4,
        Other=5
    }

    public enum WhoWork
    {
        Doctor=1,
        ANM =2,
        ASHA=3,
        Police=4,
        Riteler =5,
        DilveryBoy=6,
        Bank=7,
        Vegetable =8,
        Milk=9,
        Grocerry =10,
        MedicalStore =11,
        Driver = 12,
        Other = 13

    }

    public enum GovtIdType
    {
        Adhar =1,
        PAN =2, 
        Voter =3, 
        DrivingLicense =4, 
        Other =5

    }
    public enum HomeType
    {
        Independent =1,
        Apartment =2,
        Society =3

    }
    public enum Batroom
    {
        Independent =1, 
        Public =2,
        Seperate =3

    }


}


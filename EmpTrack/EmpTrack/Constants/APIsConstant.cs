using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpTrack.Constants
{
    public class APIsConstant
    {
        //public static String BaseURL = "http://apidocapp.azurewebsites.net/";
        public static String BaseURL = "http://webapplication520171102065324.azurewebsites.net/";
        //public static String BaseURL = "http://c11acd85.ngrok.io/api/";

        #region  web apis 
        public static String SaveEmpDetailAPI = "api/employee/request/profile";
        public static String FetchLotDetails = "api/vehicle/request/get/detail/lot?lot_id=";
        public static String FetchClientDetails = "api/client/request/get/detail/?id=";
        public static String FetchLotList = "api/vehicle/request/get/detail/buyerId?buyerId=";

        #endregion

        #region Fields Constatns
        public const string Email = "email";
        public const string ModeSupported = "modeSupported";
        public const string EmployeeType = "employeeType";
        public const string WorkerName = "workerName";
        public const string WorkBeginWeek = "workBeginWeek";
        public const string TimeHoursSpent = "timeHoursSpent";
        public const string PartTimeSpentHour = "partTimeSpentHour";
        public const string TotalWorkingHour = "totalWorkingHour";
        public const string TotalRemaingHour = "totalRemaingHour";
        public const string LunchTime = "lunchTime";
        public const string NormalWorkingHour = "normalWorkingHour";
        public const string EmergencyBreakHour = "emergencyBreakHour";
        public const string IfWorkingWeekend = "ifWorkingWeekend";
        public const string IfComplianceVoilation = "ifComplianceVoilation";
        public const string WorkerAuthorization = "workerAuthorization";
        #endregion

        #region Domains
        //public static string ClientIDForDomain1 = "5df5d1a2-6581-41d2-87ec-52dc48f14461";
        //public static string ClientIDForDomain2 = "ee6b1ba3-99b1-4d62-9ef9-833c8c5b31fb";
        public static string ClientIDForDomain1 = "5560b06a-cdce-45e3-a7b4-92b17b281045";
        public static string ClientIDForDomain2 = "5ef95ad6-6928-4e05-9d10-0957fbe544b8";
        public static string RedirectURLDomain = "ilhob://auth";

        #endregion

        #region
        public const string AlertForAuction2Message = "You should enter either one value,Lot# or BuyerId";
        public const string AlertForAuctionMessage = "You should enter either one value,Lot# or ClientId";
        public const string AlertTitleForAuction = "Invalid Inputs";
        public const string NetworkAlertTitle = "Oops";
        public const string OK = "Ok";
        public const string NetworkError = "Please check your internet connection, then try again.";
        #endregion
    }
}

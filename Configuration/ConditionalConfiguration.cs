
using System;

namespace Phonelogic.Alert.Configuration
{
    public static class ApiRefreshFrequency
    {
        public static int Rpts = 20;
        public static int UserDB = 20;
        public static int LyncApi = 1;

    }

    public static class UserInterfaceTimings
    {
        public static int OutboundCallButtonInactivateTime = 8;
        public static int UserDB = 60;
        public static int LyncApi = 1;
        public static int ResizeBoundryWidth = 800;
        public static int ResizeBoundryHeight = 800;

    }



    //public static class EndPointConfig
    //{
    //    public  static void UpdateAddress(ServiceEndpoint endpoint)
    //    {
    //        endpoint.Address = new EndpointAddress(ConditionalConfiguration.LyncServiceRefUrl);
    //    }
    //}

    public static class ConditionalConfiguration
    {

    
#if DEBUGLOCAL
     public static string BuildType = "DEBUG-LOCAL";
     public const string apiUrl = "http://localhost:19938/api/";
     public const string rootUrl = "http://localhost:19938/";
     public static string LyncServiceRefUrl = "http://cc-prod.reckner.com:1255/PhoneLogic/basic";
        // getting calls from prod. 
     public const string RecknerCallAppGuid = "{E7D2695C-96F8-4C49-858A-28F6106B2B39}";   
//#elif DEBUGTEST
//        public static string BuildType = "DEBUG-TEST";
//        public static string apiUrl = "http://cc-app.reckner.com/inbound/api/";
//        public static string rootUrl = "http://cc-app.reckner.com/inbound/";
//        public static string LyncServiceRefUrl = "http://cc-app.reckner.com:1255/PhoneLogic/basic";
//        public const string RecknerCallAppGuid = "{EF327138-E9C6-4E5D-8BB3-F505DAB0F567}";
#elif DEBUGTEST
     public static string BuildType = "DEBUG-TEST";
     public static string apiUrl = "http://cc-prod.reckner.com/phoneroom.hold/api/";
     public static string rootUrl = "http://cc-prod.reckner.com/phoneroom.hold/";
     public static string LyncServiceRefUrl = "http://cc-prod.reckner.com:1255/PhoneLogic";
     public const string RecknerCallAppGuid = "{E7D2695C-96F8-4C49-858A-28F6106B2B39}";
        
#elif DEBUGPROD
        public static string BuildType = "DEBUG-PROD";
        public static string apiUrl = "http://cc-prod.reckner.com/PhoneRoom/api/";
        public static string rootUrl = "http://cc-prod.reckner.com/PhoneRoom/";
        public static string LyncServiceRefUrl = "http://cc-prod.reckner.com:1255/PhoneLogic";
     public const string RecknerCallAppGuid = "{E7D2695C-96F8-4C49-858A-28F6106B2B39}";   
#elif RELEASEPROD
        public static string BuildType = "PROD-RELEASE";
        public static string apiUrl = "http://cc-prod.reckner.com/PhoneRoom/api/";
        public static string rootUrl = "http://cc-prod.reckner.com/PhoneRoom/";
        public static string LyncServiceRefUrl = "http://cc-prod.reckner.com:1255/PhoneLogic";
     public const string RecknerCallAppGuid = "{EF327138-E9C6-4E5D-8BB3-F505DAB0F567}";
#elif RELEASETEST
      public static string BuildType = "TEST-RELEASE";
     public static string apiUrl = "http://cc-app.reckner.com/inbound/api/";
     public static string LyncServiceRefUrl = "http://cc-app.reckner.com:1255/PhoneLogic";
     public const string RecknerCallAppGuid = "{EF327138-E9C6-4E5D-8BB3-F505DAB0F567}";
#endif

       // public static readonly DateTime BuildDate = Timestamp.BuildAt;
    }


    }

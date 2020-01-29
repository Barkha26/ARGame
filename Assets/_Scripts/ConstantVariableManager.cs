//using Mapbox.Unity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts
{
    class ConstantVariableManager
    {
        #region Comparable Strings
        public const string COIN_TYPE = "COIN";
        public const string VENDOR_TYPE = "VENDOR";
        public const string DEAL_TYPE = "DEAL";
        public const string COIN_LEVEL_GOLD = "GOLD";
        public const string COIN_LEVEL_SILVER = "SILVER";
        public const string COIN_LEVEL_BRONZE = "BRONZE";
        public const string COIN_LEVEL_ROSE = "ROSEGOLD";
        public const string COIN_LEVEL_PLATINUM = "PLATINUM";
        public const string COIN_LEVEL_DIAMOND = "DIAMOND";
        public const string COIN_LEVEL_CENTURION = "CENTURION";

        public const string VENDOR_TYPEA = "1";
        public const string VENDOR_TYPEB = "2";
        public const string VENDOR_TYPEC = "3";


        public const string TAG_BUILDING = "BUILDINGTRIGGERCOLLIDER";
        public const string TAG_ARROW = "ARROW";
        public const string TAG_PLAYER = "PLAYER";
        public const string MAKINGLIST_STATUS_CREATING = "CREATING";
        public const string MAKINGLIST_STATUS_ADDING = "ADDING";
        public const string MAKINGLIST_STATUS_DELETING = "DELETING";


        #endregion

        #region URL's
        public const string Direction_API = "https://api.mapbox.com/directions/v5/mapbox/";
        public const string ACCESS_TOKEN = "access_token=pk.eyJ1Ijoic3VtaXQ0NTE3IiwiYSI6ImNqcmx4ems1djBkaWIzeXBsMGszZzA1eWMifQ.7J3PjPREhnQ56QFlDB179A";
        #endregion

        #region Messages
        public const string DataNotFound_VendorBuildingTYPE = "Unity: No Vendor building type found.";
        public const string DataNotFound_COINLEVEL = "Unity: Incorrect level of Coin.";
        public const string DataNotFound_FROM_IOS_SIDE = "Unity: No Data Found from iOS";
        public const string DataNotFound_AFTER_JSON_MAPPING = "Unity: No Data Found after JSON Mapping.";
        public const string CALLING_BRIDGE = "Unity: Calling Bridge from Unity.";
        public const string DATA_RECIEVED_FROM_IOS = "Unity: Data Received from iOS:";
        public const string USER_ATTEMPTED_INTERACTION = "Unity: User Interacted.";
        public const string ERROR_INTERNET_CONNECTION = "Unity: Error! Check internet connection.";
        public const string WARNING_WRONG_METHOD_NAME = "Unity: Incorrect Method Name Passed! Please check the method name properly.";
        public const string WARNING_IN_RANGE = "You are in the Range.";
        public const string WARNING_OUT_OF_RANGE = "You are out of Range.";
        public const string WARNING_NO_KEY_FOUND = "Unity: No Player prefs key found.";
        public const string WARNING_KEY_ALREADY_EXIST = "Unity: Player prefs key is already exists, avoiding duplicacy.";
        public const string WARNING_ERROR = "Unity: Something went wrong TRY-CATCH.";
        public const string code_InvalidInput = "InvalidInput";
        public const string code_ProfileNotFound = "ProfileNotFound";
        public const string code_NoSegment = "NoSegment";
        public const string code_NoRoute = "NoRoute";
        public const string code_Ok = "Ok";
        public const string switchDefaultCase = "Unity: No case found in Switch case";
        #endregion

        #region Others
        public const string HEXADECIMAL_COMMA = "%2C";
        public const string HEXADECIMAL_SEMICOLON = "%3B";
        public const string OBJECT_NAME1 = "WayPoint2Position";
        public const string OBJECT_NAME2 = "Route";
        public const string ANIMATOR_STATE_1 = "isReverse";
        public const string ANIMATOR_STATE_2 = "EnlargeCompass";
        public const string EXTENSION_JSON = ".json?";
        public const string METHOD_CALLROUTEMETHOD = "CallDrawRouteMethod";
        public const string METHOD_MOVEMENTPROGRESS_BAR = "MovementProgressBar";
        public const string SCENE_NAME_INDEX_0 = "LoadingScene";
        public const string SCENE_NAME_INDEX_1 = "Map";
        public const string SCENE_NAME_INDEX_2 = "PlayerSelection";
        public const string SCENE_NAME_INDEX_3 = "CoinAR";
        public const string SCENE_NAME_INDEX_4 = "MainGame";
        public const string PLAYER_ID = "PLAYERID";
        public const string TUTORIAL = "TUTORIAL";
        public const string ANIMATION_CLIP_NAME_CAMERA = "CamPath";
        public const string ANIMATION_CLIP_NAME_CAMERA_PATH = "CamPathSmoothCurved";
        public const string USER_PROFILE_WALKING = "walking/";
        public const string USER_PROFILE_DRIVING = "driving/";
        public const string ICON_STATUS_ON = "On";
        public const string ICON_STATUS_OFF = "Off";
        public const string NA = "N/A";


        public const string STATIC_DATA_JSON = "{\"data\":[{\"id\": 78,\"latitude\": 28.621367,\"level\": \"BRONZE\",\"lock_status\": false,\"lock_status_msg\": null,\"longitude\": 77.379060,\"no_of_uses\": 250,\"sub_type\": \"MULTIPLE_COIN\",\"title\": \"BRONZE\",\"type\": \"COIN\",\"vendor_info\": {\"vendor_lat\": 28.6209133023205,\"vendor_location\": \"Unnamed Road, A Block, Sector 63, Noida, Uttar Pradesh 201307, India\",\"vendor_long\": 77.3780494186309,\"vendor_name\": \"Rajni\",\"vendor_type\": \"Gas station\"}},{\"id\": 78,\"latitude\": 23.618014,\"level\": \"CENTURION\",\"lock_status\": false,\"lock_status_msg\": null,\"longitude\": 58.270260,\"no_of_uses\": 250,\"sub_type\": \"MULTIPLE_COIN\",\"title\": \"CENTURION\",\"type\": \"COIN\",\"vendor_info\": {\"vendor_lat\": 28.6208162823205,\"vendor_location\": \"Unnamed Road, A Block, Sector 63, Noida, Uttar Pradesh 201307, India\",\"vendor_long\": 77.3779931886309,\"vendor_name\": \"Pooja\",\"vendor_type\": \"Gas station\"}},{\"id\": 78,\"latitude\": 28.621389,\"level\": \"ROSE GOLD\",\"lock_status\": false,\"lock_status_msg\": null,\"longitude\": 77.378896,\"no_of_uses\": 250,\"sub_type\": \"MULTIPLE_COIN\",\"title\": \"DIAMOND\",\"type\": \"COIN\",\"vendor_info\": {\"vendor_lat\": 28.6208162823205,\"vendor_location\": \"Unnamed Road, A Block, Sector 63, Noida, Uttar Pradesh 201307, India\",\"vendor_long\": 77.3779931886309,\"vendor_name\": \"Sumit\",\"vendor_type\": \"Gas station\"}},{\"branch_id\": 1, \"branch_name\": \"sdgasgdu\", \"company_name\": \"gsdgsgh\", \"cr_number\": null, \"latitude\":28.621715, \"lock_status\": false, \"lock_status_msg\": null, \"longitude\":77.379251, \"sub_type\": null, \"type\": \"VENDOR\", \"vend_type\": \"Restaurant\", \"vendor_id\": 5, \"vendor_name\": \"Lokesh\", \"vendor_subscription_type\": 4}],\"message\":null,\"status\":\"SUCCESS\"}";
        //public const string STATIC_DATA_JSON = "{\"data\":[{\"branch_id\": 2,\"branch_name\": \"Prakriti\",\"company_name\": \"Prakriti\",\"cr_number\": \"123456\",\"latitude\": 28.621390,\"lock_status\": false,\"lock_status_msg\": null,\"longitude\": 77.378926,\"sub_type\": null,\"type\": \"VENDOR\",\"vend_type\": \"Coffee Shop\",\"vendor_id\": 6,\"vendor_name\": \"Prakriti\",\"vendor_subscription_type\": 1}, {\"branch_id\": 1, \"branch_name\": \"sdgasgdu\", \"company_name\": \"gsdgsgh\", \"cr_number\": null, \"latitude\": 28.618547, \"lock_status\": false, \"lock_status_msg\": null, \"longitude\": 77.372633, \"sub_type\": null, \"type\": \"VENDOR\", \"vend_type\": \"Coffee Shop\", \"vendor_id\": 5, \"vendor_name\": \"sdas\", \"vendor_subscription_type\": 3}], \"message\": null, \"status\": \"SUCCESS\"}";

 //28.621389, 77.378896
        //-3.324523, 55.405021:- UK [long,lat]
        //58.334513, 23.503304 :- Oman [long,lat]

        //23.504073, 58.334066

        //28.628151, 77.374905

        //9.062945, 77.715942 

        //23.929287, 56.765575 
        //23.617836, 58.271093 oman loc nearby vendor loc



        /* "{\"data\":[{\"id\":62,\"latitude\":28.621390,\"level\":\"SILVER\",\"lock_status\":false,\"lock_status_msg\":null,\"longitude\":77.378926,\"no_of_uses\":1,\"sub_type\":\"NORMAL\",\"title\":\"ChetuTest\",\"type\":\"COIN\",\"vend_type\":\"Null\"}," +
           "{\"longitude\":77.379018,\"title\":\"test vendor for type\",\"lock_status\":false,\"id\":20,\"sub_type\":null,\"latitude\":28.620811,\"lock_status_msg\":null,\"type\":\"Vendor\",\"vend_type\":\"Type A\"}," +
             "{\"longitude\":77.377546,\"title\":\"test vendor for type\",\"lock_status\":false,\"id\":20,\"sub_type\":null,\"latitude\":28.620555,\"lock_status_msg\":null,\"type\":\"Vendor\",\"vend_type\":\"Type B\"}," +
             "{\"longitude\":77.378313,\"title\":\"test vendor for type\",\"lock_status\":false,\"id\":20,\"sub_type\":null,\"latitude\":28.621532,\"lock_status_msg\":null,\"type\":\"Vendor\",\"vend_type\":\"Type C\"}" +
           "],\"message\":null,\"status\":\"SUCCESS\"}"; */

        //(AppScioto Tech Pvt Ltd, A-101,Sec-63): 28.620811,77.379018,
        //(AMF Exports, A Block,Sec-63): 28.620555,77.377546,
        //(CarMasters, A-184,Sec-63): 28.621532,77.378313,
        //Oman: 23.616777,58.266819.


        public static double[] CountyLat = { 22.233140, 22.614915, 23.929081, 24.156971, 20.258558, 22.127871, 18.330263, 25.914400, 23.374786 };
        public static double[] CountyLong = { 57.282654, 56.029425, 56.765254, 56.010825, 56.583076, 58.528749, 54.056848, 56.271754, 58.677475 };

        #endregion
    }
}

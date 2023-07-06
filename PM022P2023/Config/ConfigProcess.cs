using System;
using System.Collections.Generic;
using System.Text;

namespace PM022P2023.Config
{
    public static class ConfigProcess
    {
        // Web Api http
        public static string ipaddress = "192.168.0.4";
        public static string webapi = "PM023PCRUD";

        //Routing  METHOD POST
        public static string postRoute = "AlumnCreate.php";
        // Routing METHOD GET
        public static string getRoute = "AlumnGetList.php";

        //Format URL
        public static string formaturl = "http://{0}/{1}/{2}";

        // URl Endpoint
        public static string ApiGET = string.Format(formaturl, ipaddress, webapi, getRoute);
        public static string ApiPOST = string.Format(formaturl, ipaddress, webapi, postRoute);
    }
}

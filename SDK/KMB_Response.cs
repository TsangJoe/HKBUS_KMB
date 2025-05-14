using System.Diagnostics;

namespace HK_BUS.SDK
{
    //Client
    internal class KMB_Response
    {
        public class RetUrl
        {
            public string Url="";
            public KMB_Enum  Status=new KMB_Enum();
        }
        private static HttpClient httpClient=new();
        public static readonly string BaseUrl = "https://data.etabus.gov.hk";

        public enum KMB_Enum
        {
            no,
            RouteList,
            StopList,
            RouteStopList
        }

        // Route List API
        public static RetUrl RouteList(){
            return RunDataToUrl("/v1/transport/kmb/route/", KMB_Enum.RouteList);
        }

        // 3. Route API (updated at 05:00 daily) 
        /// <summary>
        /// Route 3 type
        /// </summary>
        /// <param name="route"></param>
        /// <param name="direction"></param>
        /// <param name="service_type"></param>
        /// <returns></returns>
        public static string Route(string route,string direction, string service_type){
         return BaseUrl+$"/v1/transport/kmb/route/{route}/{direction}/{service_type}";
        }

        //4. Stop List API (updated at 05:00 daily) 
        public static RetUrl StopList(){
            return RunDataToUrl("/v1/transport/kmb/stop", KMB_Enum.StopList);
        }

        //5. Stop API (updated at 05:00 daily) 
        /// <summary>
        /// Stop 1 type
        /// </summary>
        /// <param name="stop_id"></param>
        /// <returns></returns>
        public static string Stop(string stop_id){
         return BaseUrl+$"/v1/transport/kmb/stop/{stop_id}";
        }

        //6. Route-Stop List API (updated at 05:00 daily) 
        public static RetUrl RouteStopList()
        {
            return RunDataToUrl("/v1/transport/kmb/route-stop", KMB_Enum.RouteStopList);
        }
        //7. Route-Stop API (updated at 05:00 daily) 
        /// <summary>
        /// Stop3 type
        /// </summary>
        /// <param name="route"></param>
        /// <param name="direction"></param>
        /// <param name="service_type"></param>
        /// <returns></returns>
        public static string Stop1(string route,string direction, string service_type){
         return BaseUrl+$"/v1/transport/kmb/routestop/{route}/{direction}/{service_type}";
        }

        //8.ETA API 
        /// <summary>
        /// ETA 3 type
        /// </summary>
        /// <param name="stop_id"></param>
        /// <param name="route"></param>
        /// <param name="service_type"></param>
        /// <returns></returns>
        public static string ETA_API(string stop_id,string route, string service_type){
         return BaseUrl+$"/v1/transport/kmb/eta/{stop_id}/{route}/{service_type}";
        }

        //9. Stop ETA API 
        /// <summary>
        ///  Stop ETA API  3 type
        /// </summary>
        /// <param name="stop_id"></param>
        /// <returns></returns>
        public static string Stop_eta(string stop_id){
         return BaseUrl+$"/v1/transport/kmb/stop-eta/{stop_id}";
        }
        //10. Route ETA API 
        /// <summary>
        /// Route ETA  API  2 type
        /// </summary>
        /// <param name="route"></param>
        /// <param name="service_type"></param>
        /// <returns></returns>
        public static string Route_eta(string route, string service_type){
         return BaseUrl+$"/v1/transport/kmb/route-eta/{route}/{service_type}";
        }

        /// <summary>
        /// return data to url ,
        /// </summary>
        /// <param name="endpoint">  url cbus/ KMB</param>
        /// <param name="KEnum">type file name</param>
        /// <returns></returns>
        private static RetUrl RunDataToUrl(string endpoint, KMB_Enum KEnum)
        {
            return new RetUrl
            {
                Url = $"{BaseUrl}{endpoint}",
                Status = KEnum
            };
        }
        private static RetUrl RunDataToUrl(string endpoint)
        {
            return new RetUrl
            {
                Url = $"{BaseUrl}{endpoint}",
                Status = KMB_Enum.no
            };
        }

        /// <summary>
        /// Get HK bus API Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<string> GetDataUrl(string url)
        {
            Debug.WriteLine(url);
            if (url==null){
                return "err";
            }
            httpClient =new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsonResponse= await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
    }
}

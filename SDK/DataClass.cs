namespace HK_BUS.SDK
{
    //2.1  Get KMB
    //2.1.1 Bus stop list data
    public class KMBStopList
    {
        public string stop { get; set; }
        public string name_en { get; set; }
        public string name_tc { get; set; }
        public string name_sc { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
    }
    //2.1.2 Route list data
    public class KMBRouteStopList
    {
        public string route { get; set; }
        public string bound { get; set; }
        public string service_type { get; set; }
        public string seq { get; set; }
        public string stop { get; set; }
    }
    //2.1.3 Route-Stop List
    public class KMBRouteList
    {
        public string route { get; set; }
        public string bound { get; set; }
        public string service_type { get; set; }
        public string orig_en { get; set; }
        public string orig_tc { get; set; }
        public string orig_sc { get; set; }
        public string dest_en { get; set; }
        public string dest_tc { get; set; }
        public string dest_sc { get; set; }
    }

    /// <summary>
    /// --- Citybus ---
    /// </summary>
    //2.2.1Route API
    public class CitybusRouteList
    {
        public string co { get; set; }
        public string route { get; set; }
        public string orig_tc { get; set; }
        public string orig_en { get; set; }
        public string dest_tc { get; set; }
        public string dest_en { get; set; }
        public string orig_sc { get; set; }
        public string dest_sc { get; set; }
        public DateTime data_timestamp { get; set; }
    }

    //2.2.2 Stop API
    public class CitybusStop
    {
        public string stop { get; set; }
        public string name_tc { get; set; }
        public string name_en { get; set; }
        public string name_sc { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }
        public DateTime data_timestamp { get; set; }
    }

    public class CitybusStopRoot
    {
        public string type { get; set; }
        public string version { get; set; }
        public DateTime generated_timestamp { get; set; }
        public CitybusStop data { get; set; }
    }

    //2.2.3 Route-Stop API
    public class CitybusRoute
    {
        public string co { get; set; }
        public string route { get; set; }
        public string dir { get; set; }
        public int seq { get; set; }
        public string stop { get; set; }
        public DateTime data_timestamp { get; set; }
    }

    //-------
    //class -->>KMBStopList/-KMBRouteStopList/-KMBRouteList -CitybusRouteList/-CitybusRouteList/-CitybusRoute
    public class Busdata<T>
    {
        public string type { get; set; }
        public string version { get; set; }
        public DateTime generated_timestamp { get; set; }
        public List<T> data { get; set; }
    }
}
using HK_BUS.SDK;
using static HK_BUS.SDK.KMB_Response;
namespace HK_BUS
{
    class Program
    {
        static Busdata<KMBRouteList> RouteList1;
        static Busdata<KMBStopList> StopList1;
        static Busdata<KMBRouteStopList> RouteStopList1;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RouteList1 = await TaskData2.SetUrl<KMBRouteList>(RouteList());
            Console.WriteLine(RouteList1.type);
            StopList1 = await TaskData2.SetUrl<KMBStopList>(StopList());

            Console.WriteLine(StopList1.type);
            RouteStopList1 = await TaskData2.SetUrl<KMBRouteStopList>(RouteStopList());

            Console.WriteLine(RouteStopList1.type);
        }
    }
}
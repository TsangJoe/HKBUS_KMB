using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static HK_BUS.SDK.KMB_Response;
using System.Diagnostics;

namespace HK_BUS.SDK
{
    internal static class TaskData2
    {
        public static string filePath = "";

        public static async Task<Busdata<T>> SetUrl<T>(RetUrl retUrl)
        {
            try
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{retUrl.Status}_Data.json");
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);

                    Busdata<T> data = JsonConvert.DeserializeObject<Busdata<T>>(jsonData);
                    JObject routeList = JObject.Parse(jsonData);
                    if (routeList[BusDataString.generated_timestamp] != null)
                    {
                        if (DateTime.TryParse(routeList?[BusDataString.generated_timestamp].ToString(), out DateTime generated_timestamp))
                        {
                            string? type = routeList[BusDataString.type]?.ToString();
                            string? version = routeList[BusDataString.version]?.ToString();
                            if (generated_timestamp.AddHours(23) < DateTime.Today)
                            {//if  fileTime > DateTime -> Get data
                                return await OutJC<T>(retUrl);
                            }
                            else
                            {
                                //ok !if  fileTime <DateTime+23 -> Get data
                                return data;
                            }
                        }
                        else
                        {//if error Time Parse
                            return await OutJC<T>(retUrl);
                        }
                    }
                    else
                    {//if time is null.
                        return await OutJC<T>(retUrl);
                    }
                }
                else
                {//if filePath no!
                    return await OutJC<T>(retUrl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static async Task<Busdata<T>> OutJC<T>(RetUrl retUrl)
        {

            string Adata = await GetDataUrl(retUrl.Url);
            SaveData(Adata);
            return JsonConvert.DeserializeObject<Busdata<T>>(Adata);
        }
        public static async Task<string> SetUrl(RetUrl retUrl)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{retUrl.Status}_Data.json");
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    JObject routeList = JObject.Parse(jsonData);
                    if (routeList["generated_timestamp"] != null)
                    {
                        if (DateTime.TryParse(routeList?["generated_timestamp"].ToString(), out DateTime generated_timestamp))
                        {
                            string? type = routeList["type"]?.ToString();
                            string? version = routeList["version"]?.ToString();
                            if (generated_timestamp < DateTime.Today.AddHours(6))
                            {
                                return routeList.ToString();
                            }
                            else
                            {
                                return routeList.ToString();
                            }
                        }
                        else
                        {
                            string Adata = await GetDataUrl(retUrl.Url);
                            SaveData(Adata);
                            return Adata;
                        }
                    }
                    else
                    {
                        string Adata = await GetDataUrl(retUrl.Url);
                        SaveData(Adata);
                        return Adata;
                    }
                }
                else
                {
                    string Adata = await GetDataUrl(retUrl.Url);
                    SaveData(Adata);
                    return Adata;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private static void SaveData(string jsData)
        {
            File.WriteAllText(filePath, jsData);
        }
    }
}
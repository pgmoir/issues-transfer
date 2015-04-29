using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExtractIssuesFromAsana
{
    class Program
    {
        static void Main(string[] args)
        {
            //var asanaKey = "61rP9kdl.kK5NxMzVClNyLdPYmSbRrgx:";
            //var asanaKeyEncoded = "NjFyUDlrZGwua0s1TnhNelZDbE55TGRQWW1TYlJyZ3g6";

            //var httpClient = new HttpClient();
            ////var url = "https://app.asana.com/api/1.0/tasks/27143324952195?opt_fields=name,notes";
            //var url = "https://app.asana.com/api/1.0/projects";
            //var request = new HttpRequestMessage(HttpMethod.Get, url);
            //AddAsanaHeaders(request);
            //var response = httpClient.SendAsync(request).Result;
            //response.EnsureSuccessStatusCode();
            //var result = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);
            //Console.ReadKey();

            var httpClient = new HttpClient();
            var url = "http://youtrack.brightsolid.com/rest/project/all?true";
            //var url = "http://youtrack.brightsolid.com/rest/issue/byproject/TST?filter=%23Show-stopper";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            AddYouTrackHeaders(request);
            var response = httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            var oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
            foreach (dynamic o in oMycustomclassname)
            {
                //Console.WriteLine(o.name);
            }
            Console.WriteLine(result);
            Console.ReadKey();
        
        }

        static void AddAsanaHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", "Basic NjFyUDlrZGwua0s1TnhNelZDbE55TGRQWW1TYlJyZ3g6");
        }

        static void AddYouTrackHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Accept", "application/json");
        }
    }
}

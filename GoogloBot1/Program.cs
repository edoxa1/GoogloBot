using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using GoogloBot1.Client;

namespace GoogloBot1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ApiScript.InitiateApi();
            var response = ApiScript.MainRequest("covid 2019");
            Console.WriteLine(response);
            var json = JsonResponse.Jsonify(response);
            Console.WriteLine(json.Data.Result.Organic[0].Title);
        }
        
    }
}
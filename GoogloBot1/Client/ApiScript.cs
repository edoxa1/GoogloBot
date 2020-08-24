using System;
using System.Linq;
using RestSharp;

namespace GoogloBot1.Client
{
    public static class ApiScript
    {
        public static bool IsApiWorking { get; set; }
        
        private static string Uri { get; set; }
        private static string Host { get; set; }
        private static string Key { get; set; }
        
        public static void InitiateApi()
        {
            var apiSettings = ReadSettings();
            Uri = apiSettings.ApiSettings.ApiUri;
            Host = apiSettings.ApiSettings.ApiHost;
            Key = apiSettings.ApiSettings.ApiKey;
        }

        private static UserSettings.Settings ReadSettings()
        {
            var settings = UserSettings.Settings.Init();
            return settings;
        }

        public static bool TestRequest()
        {
            var url = Uri + QueryGenerator("testRequest");
            var response = ApiRequest(url);
            IsApiWorking = response.IsSuccessful;
            return IsApiWorking;
        }

        public static string MainRequest(string text)
        {
            var url = Uri + QueryGenerator(text);
            var response = ApiRequest(url);
            return response.Content;
        }

        private static IRestResponse ApiRequest(string url)
        {
            var client =  new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", Host);
            request.AddHeader("x-rapidapi-key", Key);
            var response = client.Execute(request);
            return response;
        }

        private static string QueryGenerator(string text)
        {
            var result = "";
            var textLenght = text.Split(' ').Length;
            
            if (textLenght!= 1)
            {
                text.ToList().ForEach(delegate(char c)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        result = text.Replace(c, '%');
                    }
                });
            }
            else if (textLenght == 1)
            {
                result = text;
            }
            else
            {
                const string error = "%ERROR n.4 | You have to enter text!";
                result = error;
            }
            return result;
        }
    }
}
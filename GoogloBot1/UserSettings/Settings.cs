using Newtonsoft.Json;

namespace GoogloBot1.UserSettings
{
    internal class Settings
    {
        [JsonProperty("api_settings")]
        public ApiSettings ApiSettings { get; set; }
        public static Settings Init()
        {
            var stream = new System.IO.StreamReader("UserSettings/settings.json");
            var json = JsonConvert.DeserializeObject<Settings>(stream.ReadToEnd());
            return json;
        }
    }
    
    internal class ApiSettings
    {
        [JsonProperty("api_uri")]
        public string ApiUri { get; set; }
        [JsonProperty("api_host")]
        public string ApiHost { get; set; }
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
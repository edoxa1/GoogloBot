using System.Collections.Generic;
using  Newtonsoft.Json;

namespace GoogloBot1.Client
{
    [JsonObject]
    internal class JsonResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
        
        public static JsonResponse Jsonify(string text)
        {
            var json = JsonConvert.DeserializeObject<JsonResponse>(text);
            return json;
        }
    }
    internal class Data
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("results")]
        public Result Result { get; set; }
    }
    
    internal class Meta
    {
        [JsonProperty("credits_left")]
        public long CreditsLeft { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("gl")]
        public string Gl { get; set; }
        [JsonProperty("hl")]
        public string Hl { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("time_taken")]
        public double TimeTaken { get; set; }
    }

    internal class Result
    {
        [JsonProperty("organic")]
        public Organic[] Organic { get; set; }
    }

    internal class Organic
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("snippet")]
        public string Snippet { get; set; }
        [JsonProperty("snippet_html")]
        public string SnippetHtml { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
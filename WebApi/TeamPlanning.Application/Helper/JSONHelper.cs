using Newtonsoft.Json.Linq;

namespace TeamPlanning.Application.Helper
{
    public static class JSONHelper
    {
        public static JArray ExtractPropertyFromResponse(string jsonResponse, string prop)
        {
            if (jsonResponse == null) return null;

            JObject json = JObject.Parse(jsonResponse);
            JArray valuesArray = (JArray)json[prop];

            return valuesArray;
        }
    }
}

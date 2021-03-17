using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace los_api.Utils
{
    public static class Common
    {
        public static T MapValue<T, C>(C model)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            string json = JsonConvert.SerializeObject(model, settings);
            return JsonConvert.DeserializeObject<T>(json);
        }

      
    }
}
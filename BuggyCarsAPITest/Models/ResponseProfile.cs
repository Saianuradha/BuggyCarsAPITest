using Newtonsoft.Json;

namespace BuggyCarsAPITest
{
   
    public class ResponseProfile
    {

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
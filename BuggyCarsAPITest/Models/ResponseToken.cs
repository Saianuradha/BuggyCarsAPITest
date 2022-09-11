using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsAPITest.Models
{
    public class ResponseToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}

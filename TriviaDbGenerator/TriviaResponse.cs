using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TriviaDbGenerator
{
    class TriviaResponse
    {
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("results")]
        public required List<Question> Results { get; set; }

        public override string ToString()
        {
            return ResponseCode + "\n" + Results;
        }
    }

}

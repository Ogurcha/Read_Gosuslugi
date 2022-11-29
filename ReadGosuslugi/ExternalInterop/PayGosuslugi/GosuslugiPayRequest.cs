using Newtonsoft.Json;

namespace ReadGosuslugi.ExternalInterop.PayGosuslugi
{
    public class GosuslugiPayRequest
    {
        [JsonProperty("documents")]
        public Document[] Documents { get; set; }

        public class Document
        {
            [JsonProperty("docType")]
            public string DocType { get; set; }

            [JsonProperty("docNumber")]
            public string DocNumber { get; set; }
        }
    }
}

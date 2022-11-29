using Newtonsoft.Json;

namespace ReadGosuslugi.ExternalInterop.PayGosuslugi
{
    public class GosuslugiResponseBase
    {
        [JsonProperty("error")]
        public ErrorContainer Error { get; set; }

        [JsonProperty("errors")]
        public ErrorContainer[] Errors { get; set; }
            

        public class ErrorContainer
        {
            [JsonProperty("errorCode")]
            public int ErrorCode { get; set; }

            [JsonProperty("errorMessage")]
            public string ErrorMessage { get; set; }
        }
    }
}

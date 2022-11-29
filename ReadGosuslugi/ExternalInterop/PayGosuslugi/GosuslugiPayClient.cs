using ReadGosuslugi.Core.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net.Mime;
using Microsoft.Extensions.Configuration;

namespace ReadGosuslugi.ExternalInterop.PayGosuslugi
{
    /// <summary>
    /// Класс по взаимодействию с внешней системой Госуслуг
    /// </summary>
    public class GosuslugiPayClient : IGosuslugiPayClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        private Uri targetUri => new Uri(_config.GetValue<string>("GOSUSLUGI_URI"));

        private readonly string passportStr = "RF_PASSPORT";
        private readonly string stsStr = "CAR_REG_CERTIFICATE";
        private readonly string innStr = "INN_FL";
        private readonly string snilsStr = "SNILS";

        public GosuslugiPayClient(IConfiguration config, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<GosuslugiPayResponse> GetFinesByInn(string inn)
        {
            GosuslugiPayRequest content = makeRequest(innStr, inn);

            return await SendRequest(content);
        }

        public async Task<GosuslugiPayResponse> GetFinesByPassport(string inn)
        {
            GosuslugiPayRequest content = makeRequest(passportStr, inn);

            return await SendRequest(content);
        }

        public async Task<GosuslugiPayResponse> GetFinesBySts(string inn)
        {
            GosuslugiPayRequest content = makeRequest(stsStr, inn);

            return await SendRequest(content);
        }

        public async Task<GosuslugiPayResponse> GetFinesBySnils(string snils)
        {
            GosuslugiPayRequest content = makeRequest(snilsStr, snils);

            return await SendRequest(content);
        }

        private async Task<GosuslugiPayResponse> SendRequest(GosuslugiPayRequest content)
        {
            var stringPayload = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, MediaTypeNames.Application.Json);


            var response = await _httpClient.PostAsync(targetUri, httpContent);

            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GosuslugiPayResponse>(responseContent);
                return result;
            }

            return null;
        }

        private static GosuslugiPayRequest makeRequest(string docType, string docNumber)
        {
            return new GosuslugiPayRequest()
            {
                Documents = new GosuslugiPayRequest.Document[]
                {
                    new GosuslugiPayRequest.Document
                    {
                        DocType = docType,
                        DocNumber = docNumber
                    }
                }
            };
        }
    }
}

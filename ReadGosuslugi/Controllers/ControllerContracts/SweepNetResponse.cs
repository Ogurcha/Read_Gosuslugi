using Newtonsoft.Json;
using ReadGosuslugi.Core.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ReadGosuslugi.Controllers.ControllerContracts
{
    public class SweepNetResponse
    {
        [JsonProperty("resultCode")]
        public int ResultCode { get; set; }

        [JsonProperty("resultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("operationToken")]
        public string OperationToken { get; set; }
    }

    public class SweepNetResponseList<T> : SweepNetResponse
    {
        [JsonProperty("list")]
        public List<T> List { get; set; }
    }

    public class SweepNetResponseData<T> : SweepNetResponse
    {
        [JsonProperty("found")]
        public bool Found { get; set; }

        [JsonProperty("list")]
        public List<T> Data { get; set; }

        private SweepNetResponseData() { }

        public SweepNetResponseData (List<T> data)
        {
            Found = data.Count > 0;
            Data = data;
        }

        public static SweepNetResponseData<T> Empty => new SweepNetResponseData<T>();
    }

    public class SweepNetResponseDataWithTotal<T> : SweepNetResponseData<T> where T : IHasPrice
    {
        /// <summary>
        /// Общаее количество штрафов
        /// </summary>
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// общая сумма штрафов
        /// </summary>
        [JsonProperty("total")]
        public decimal Total { get; set; }

        public SweepNetResponseDataWithTotal(List<T> data) : base(data)
        {
            TotalItems = data.Count;
            Total = data.Sum(x => x.Price);
        }
    }
}

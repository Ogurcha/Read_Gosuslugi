using Newtonsoft.Json;

namespace ReadGosuslugi.ExternalInterop.PayGosuslugi
{
    public class GosuslugiPayResponse : GosuslugiResponseBase
    {
        [JsonProperty("bills")]
        public Bill[] Bills { get; set; }

        [JsonProperty("payOptions")]
        public object[] PayOptions { get; set; }

        [JsonProperty("unidentifiedBillIds")]
        public int[] UnidentifiedBillIds { get; set; }

        [JsonProperty("payedBillIds")]
        public int[] PayedBillIds { get; set; }

        [JsonProperty("hasUnidentifiedBills")]
        public bool HasUnidentifiedBills { get; set; }

        [JsonProperty("userHasInn")]
        public bool UserHassInn { get; set; }

        [JsonProperty("counts")]
        public Count Counts { get; set; }

        [JsonProperty("fkPayments")]
        public FkPayment[] FkPayments { get; set; }

        public class Bill
        {
            [JsonProperty("billId")]
            public ulong BillId { get; set; }

            [JsonProperty("billNumber")]
            public string BillNumber { get; set; }

            [JsonProperty("billName")]
            public string BillName { get; set; }

            [JsonProperty("billDate")]
            public long BillDate { get; set; }

            [JsonProperty("isPaid")]
            public bool IsPaid { get; set; }

            [JsonProperty("amount")]
            public double Amount { get; set; }

            [JsonProperty("serviceCategory")]
            public ServiceCategory ServiceCategory { get; set; }

            [JsonProperty("billSumm")]
            public BillSum BillSum { get; set; }

            [JsonProperty("addAttrs")]
            public AddAttr AddAttrs { get; set; }
        }

        public class ServiceCategory
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class BillSum
        {
            [JsonProperty("ammounts")]
            public Ammount[] Ammounts { get; set; }
        }

        public class Ammount
        {
            [JsonProperty("summId")]
            public ulong SummId { get; set; }

            [JsonProperty("isDetalisation")]
            public bool IsDeralisation { get; set; }

            [JsonProperty("isEditable")]
            public bool IsEditable { get; set; }
        }

        public class Attr
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }
        }

        public class AddAttr
        {
            [JsonProperty("attrs")]
            public Attr[] Attrs { get; set; }
        }

        public class Count
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("ammount")]
            public decimal Ammount { get; set; }

            [JsonProperty("fssp")]
            public Fssp Fssp { get; set; }
        }

        public class Fssp
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("ammount")]
            public decimal Ammount { get; set; }
        }

        public class FkPayment
        {
            [JsonProperty("billNumber")]
            public string BillNumber { get; set; }

            [JsonProperty("purpose")]
            public string Purpose { get; set; }

            [JsonProperty("ammount")]
            public decimal Ammount { get; set; }

            [JsonProperty("payDate")]
            public long PayDate { get; set; }
        }
    }
}
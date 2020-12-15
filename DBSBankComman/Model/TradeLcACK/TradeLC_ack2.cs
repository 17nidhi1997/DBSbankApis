using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class TradeLC_ack2
    {
        [JsonProperty("responseType")]
        public string responseType { get; set; }
        [JsonProperty("txnRefId")]
        public string txnRefId { get; set; }
        [JsonProperty("txnStatus")]
        public string txnStatus { get; set; }
        [JsonProperty("txnRejectCode")]
        public string txnRejectCode { get; set; }
        [JsonProperty("txnStatusDescription")]
        public string txnStatusDescription { get; set; }
        [JsonProperty("attachmentRef")]
        public string attachmentRef { get; set; }
        [JsonProperty("imexReference")]
        public int imexReference { get; set; }
        [JsonProperty("customerReference")]
        public string customerReference { get; set; }
    }
}

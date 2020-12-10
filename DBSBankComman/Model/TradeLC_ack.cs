using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class TradeLC_ack
    {
        [JsonProperty("header")]
        public TradeLC_ack1 header { get; set; }
        [JsonProperty("txnResponses")]
        public TradeLC_ack2 txnResponses { get; set; }
        [JsonProperty("error")]
        public TradeLC_ack3 error { get; set; }
        /*[JsonProperty("_status_code")]
        public string msgId { get; set; }
        [JsonProperty("_status_code")]
        public string orgId { get; set; }
        [JsonProperty("_status_code")]
        public string timeStamp { get; set; }
        [JsonProperty("_status_code")]
        public string channelId { get; set; }
        [JsonProperty("_status_code")]
        public int noOfDocAttached { get; set; }
        [JsonProperty("_status_code")]
        public string ctry { get; set; }
        [JsonProperty("_status_code")]
        public string responseType { get; set; }
        [JsonProperty("_status_code")]
        public string txnRefId { get; set; }
        [JsonProperty("_status_code")]
        public string txnStatus { get; set; }
        [JsonProperty("_status_code")]
        public string txnRejectCode { get; set; }
        [JsonProperty("_status_code")]
        public string txnStatusDescription { get; set; }
        [JsonProperty("_status_code")]
        public string attachmentRef { get; set; }
        [JsonProperty("_status_code")]
        public int imexReference { get; set; }
        [JsonProperty("_status_code")]
        public string status { get; set; }
        [JsonProperty("_status_code")]
        public int code { get; set; }
        [JsonProperty("_status_code")]
        public string description { get; set; }*/
    }
}

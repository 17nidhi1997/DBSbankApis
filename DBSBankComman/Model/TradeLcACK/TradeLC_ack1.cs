using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class TradeLC_ack1
    {
        [JsonProperty("msgId")]
        public string msgId { get; set; }
        [JsonProperty("orgId")]
        public string orgId { get; set; }
        [JsonProperty("timeStamp")]
        public DateTime timeStamp { get; set; }
        [JsonProperty("channelId")]
        public string channelId { get; set; }
        [JsonProperty("noOfDocAttached")]
        public int noOfDocAttached { get; set; }
        [JsonProperty("ctry")]
        public string ctry { get; set; }
    }
}

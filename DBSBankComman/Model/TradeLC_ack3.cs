using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class TradeLC_ack3
    {
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("code")]
        public int code { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}

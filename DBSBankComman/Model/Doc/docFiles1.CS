using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model.Doc
{
    public class docFiles1
    {
        [JsonProperty("msgId")]
        public string msgId { get; set; }
        [JsonProperty("orgId")]
        public string orgId { get; set; }
        [JsonProperty("timeStamp")]
        public string timeStamp { get; set; }
        [JsonProperty("channelId")]
        public string channelId { get; set; }
        [JsonProperty("ctry")]
        public string ctry { get; set; }
    }
}

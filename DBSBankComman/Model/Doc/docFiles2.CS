using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model.Doc
{
    public class docFiles2
    {
        [JsonProperty("attachmentRef")]
        public string attachmentRef { get; set; }
        public List<docFiles3> documents { get; set; }
    }
}

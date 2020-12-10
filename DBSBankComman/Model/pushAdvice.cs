using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankComman.Model
{
    public class pushAdvice
    {
        public string msgId { get; set; }
        public string orgId { get; set; }
        public DateTime timeStamp { get; set; }
        public string channelId { get; set; }
        public string ctry { get; set; }
        public string documentDescription { get; set; }
        public string documentName { get; set; }
        public string customerReference { get; set; }
        public int bankReference { get; set; }
        public string encodedFile { get; set; }
        

    }
}

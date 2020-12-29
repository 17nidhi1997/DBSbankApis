using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC1
    {
        public string msgId { get; set; }
        public string orgId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string channelId { get; set; }
        public string ctry { get; set; }
        public int noOfDocAttached { get; set; }
    }
}

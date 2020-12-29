using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC7
    {
        public int amtToFinance { get; set; }
        public string financingCcy { get; set; }
        public int financePeriod { get; set; }
        public int financeBoardRateAmt { get; set; }
        public List<TradeIBLC8> financingContract { get; set; }
    }
}

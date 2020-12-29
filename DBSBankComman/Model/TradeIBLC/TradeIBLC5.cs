using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC5
    {
        public string settlementAccountNo { get; set; }
        public string settlementAccountNoCcy { get; set; }
        public int settlementAmt { get; set; }
        public int settlementBoardRateAmt { get; set; }
        public List<TradeIBLC6> settlementContract { get; set; }
    }
}

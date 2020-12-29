using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC2
    {
        public string txnType { get; set; }
        public string accountNumber { get; set; }
        public string ccy { get; set; }
        public string billCategory { get; set; }
        public string bankReference { get; set; }
        public string customerReference { get; set; }
        public string discrepancy { get; set; }
        public string billCcy { get; set; }
        public int billAmount { get; set; }
        public int billOutstandingAmount { get; set; }
        public TradeIBLC3 customerResponse { get; set; }

    }
}

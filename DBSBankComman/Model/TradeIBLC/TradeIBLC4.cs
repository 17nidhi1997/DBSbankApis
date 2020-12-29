using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC4
    {
        public string importBillRef { get; set; }
        public int settlementOptions { get; set; }
        public List<TradeIBLC5> settlementAccounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TradeIBLC_CommanLayer.Model
{
    public class TradeIBLC
    {
        public TradeIBLC1 header{ get; set; }
        public TradeIBLC2 txnInfo { get; set; }
        public TradeIBLC4 settlementInstruction { get; set; }
        public TradeIBLC7 tradeFinancingDetails { get; set; }
        public TradeIBLC9 instructions { get; set; }
        public List<TradeIBLC10> documentsPresented { get; set; }


    }
}
using DBSBankComman.Model;
using System;
using System.Collections.Generic;

namespace DBSBankManager
{
    public interface IManagerLC_ACK
    {
        //Object ACKTradeLc(locModel LC_ack);
        object ACKTradeLc(TradeLC_ack obj);

        //object ACKTradeLc(List<TradeLC_ack> dataList);
        //object ACKTradeLc(object jsons);
    }
}

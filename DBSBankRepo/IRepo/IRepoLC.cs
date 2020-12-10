using DBSBankComman.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankRepo.IRepo
{
    public interface IRepoLC
    {
       // Object ACKTradeLc(locModel LC_ack);
        object ACKTradeLc(TradeLC_ack lC_ack);
    }
}

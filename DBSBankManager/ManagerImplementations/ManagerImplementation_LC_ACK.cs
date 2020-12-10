using DBSBankComman.Model;
using DBSBankRepo.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankManager
{
    public class ManagerImplementation_LC_ACK : IManagerLC_ACK
    {
        private IRepoLC _IManager;
        public ManagerImplementation_LC_ACK(IRepoLC dBS)
        {
            _IManager = dBS;
        }

        //public object ACKTradeLc(locModel LC_ack)
        //{
        //    return this._IManager.ACKTradeLc( LC_ack);
        //}

        public object ACKTradeLc(TradeLC_ack obj)
        {
            return this._IManager.ACKTradeLc(LC_ack);
        }
    }
}

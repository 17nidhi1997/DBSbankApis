using DBSBankComman.Model;
using DBSBankManager.Manage;
using DBSBankRepo.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankManager.ManagerImplementations
{
    public class ManagerImplementation_IBLC_ACK: IManagerIBLC_ACK
    {
        private IRepoIBLC _IManager;
        public ManagerImplementation_IBLC_ACK(IRepoIBLC dBS)
        {
            _IManager = dBS;
        }

        public object ACKTradeIBLC(TradeIBLCcs IBLC)
        {
            return this._IManager.ACKTradeIBLC(IBLC);
        }
    }
}

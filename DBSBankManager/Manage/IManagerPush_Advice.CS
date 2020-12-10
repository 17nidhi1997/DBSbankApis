using DBSBankComman.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankManager.Manage
{
    public interface IManagerPush_Advice
    {
        object pushAdvice_responce(pushAdvice push_Advice);
    }
}

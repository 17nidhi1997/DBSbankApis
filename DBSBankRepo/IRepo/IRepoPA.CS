using DBSBankComman.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSBankRepo.IRepo
{
    public interface IRepoPA
    {
        object pushAdvice_responce(pushAdvice push_Advice);
    }
}

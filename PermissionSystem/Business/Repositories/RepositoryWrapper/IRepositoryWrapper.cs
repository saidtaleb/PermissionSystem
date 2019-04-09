using PermissionSystem.Business.Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionSystem.Business.Repositories.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
    }
}

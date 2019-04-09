using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermissionSystem.Business.Context;
using PermissionSystem.Business.Repositories.Account;

namespace PermissionSystem.Business.Repositories.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppInoContext _repoContext;
        private IAccountRepository _account;

        public RepositoryWrapper(AppInoContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

    }
}

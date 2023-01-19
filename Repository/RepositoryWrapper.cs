﻿using FaktureAPI.Data;

namespace FaktureAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _appContext;
        private IBillBodyRepository _billBody;
        private IBillHeaderRepository _billHeader;

        public IBillBodyRepository BillBody
        {
            get
            {
                if (_billBody == null)
                {
                    _billBody = new BillBodyRepository(_appContext);
                }
                return _billBody;
            }
        }

        public IBillHeaderRepository BillHeader
        {
            get
            {
                if (_billHeader == null)
                {
                    _billHeader = new BillHeaderRepository(_appContext);
                }
                return _billHeader;
            }
        }

        public RepositoryWrapper(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task SaveAsync()
        {
          await  _appContext.SaveChangesAsync();
        }
    }
}

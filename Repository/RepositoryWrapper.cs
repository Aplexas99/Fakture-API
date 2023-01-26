using FaktureAPI.Data;

namespace FaktureAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _appContext;
        private IBillBodyRepository _billBody;
        private IBillHeaderRepository _billHeader;
        private IPartnerRepository _partner;
        private IJobRepository _job;
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

        public IPartnerRepository Partner
        {
            get
            {
                if (_partner == null)
                {
                    _partner = new PartnerRepository(_appContext);
                }
                return _partner;
            }
        }

        public IJobRepository Job
        {
            get
            {
                if (_job == null)
                {
                    _job = new JobRepository(_appContext);
                }
                return _job;
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

using DataProvider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xylem.BLL
{
    public class InstallationService
    {
        //private readonly InstallationRepository _installationRepository;

        private readonly IXdmModel _context;

        public InstallationService(IXdmModel context)
        {
            _context = context;
        }

        public async Task<TView> GetByIdAsync<TView>(string id)
        {
            //_context.Installations.
            throw new NotImplementedException();
        }

        public async Task<TView> GetByIdAsync<TView>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>(int pageSize, int pageIndex, string sort)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalAsync()
        {
            throw new NotImplementedException();
        }
    }
}

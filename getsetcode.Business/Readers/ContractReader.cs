using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class ContractReader : IContractReader
    {
        IContextAccessor _accessor;

        public ContractReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Contract LatestContract()
        {
            using (var d = _accessor.Context())
            {
                return d.Context.Contracts
                    .Include(c => c.Client)
                    .OrderByDescending(c => c.EndDate)
                    .FirstOrDefault();
            }
        }
    }
}

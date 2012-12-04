using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;
using getsetcode.Business.Readers;

namespace getsetcode.Presentation.Loaders
{
    public class ContractLoader : IContractLoader
    {
        IContractReader _reader;

        public ContractLoader(IContractReader reader)
        {
            _reader = reader;
        }

        public IContractPresentable LatestPresentable()
        {
            var c = _reader.LatestContract();

            if (c == null) return null;
            else return new ContractPresentable(c);
        }
    }
}

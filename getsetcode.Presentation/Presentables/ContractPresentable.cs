using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;
using getsetcode.Model.Enum;

namespace getsetcode.Presentation.Presentables
{
    public class ContractPresentable : IContractPresentable
    {
        private Contract _base;

        public ContractPresentable(Contract contract)
        {
            _base = contract;
        }

        public string DisplayAsLatestContract
        {
            get
            {
                if (_base == null || _base.EndDate < DateTime.Today)
                    return "Tom is currently seeking a new contract and is available now";
                else if (_base.EndDate < DateTime.Today.AddDays(28))
                    return string.Format("Tom is currently seeking a new contract and will become available on {0}", _base.EndDate.ToString("dd/MM/yyyy"));
                else
                    return string.Format("Tom's current contract is due to end on {0}", _base.EndDate.ToString("dd/MM/yyyy"));
            }
        }

        public ContractStatus Status
        {
            get
            {
                if (_base == null || _base.EndDate < DateTime.Today)
                    return ContractStatus.Available;
                else if (_base.EndDate > DateTime.Today.AddDays(-14))
                    return ContractStatus.EndingSoon;
                else
                    return ContractStatus.Unavailable;
            }
        }
    }
}

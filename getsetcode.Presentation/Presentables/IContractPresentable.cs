using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Enum;

namespace getsetcode.Presentation.Presentables
{
    public interface IContractPresentable
    {
        string DisplayAsLatestContract { get; }

        ContractStatus Status { get; }
    }
}

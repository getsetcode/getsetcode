using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public interface IHistoryLoader
    {
        IEnumerable<IHistoryItemPresentable> ListPresentables(DateTime? olderThan, int take);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface IHistoryReader
    {
        IEnumerable<HistoryItem> ListPresentables(DateTime? olderThan, int take);
    }
}

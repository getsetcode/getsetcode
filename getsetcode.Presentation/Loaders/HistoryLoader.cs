using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Business.Readers;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public class HistoryLoader : IHistoryLoader
    {
        IHistoryReader _reader;

        public HistoryLoader(IHistoryReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<IHistoryItemPresentable> ListPresentables(DateTime? olderThan, int take)
        {
            foreach (var s in _reader.ListPresentables(olderThan, take))
            {
                yield return new HistoryItemPresentable(s);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public interface IContactFormSubmissionLoader
    {
        IContactFormSubmissionPresentable GetPresentable(int id);
        IEnumerable<IContactFormSubmissionPresentable> ListPresentables(DateTime? olderThan, int take);
    }
}

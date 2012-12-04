using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public interface IProjectLoader
    {
        IProjectPresentable GetPresentable(int id);

        IProjectPresentable GetPresentable(string name);

        IEnumerable<IProjectPresentable> ListFeaturedPresentables();
    }
}

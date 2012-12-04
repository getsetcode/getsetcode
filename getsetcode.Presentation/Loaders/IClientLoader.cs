using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;

namespace getsetcode.Presentation.Loaders
{
    public interface IClientLoader
    {
        IClientPresentable GetPresentable(int id);

        IClientPresentable GetPresentable(string name);
    }
}

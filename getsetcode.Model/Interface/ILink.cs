using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Enum;

namespace getsetcode.Model.Interface
{
    public interface ILink
    {
        int LinkID { get; }

        string LinkStringID { get; }

        string LinkName { get; }

        string LinkInfo { get; }

        string DetailAction { get; }

        NavSection Section { get; }
    }
}

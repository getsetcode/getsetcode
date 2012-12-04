using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Data;

namespace getsetcode.Business
{
    public class ContextAccessor : IContextAccessor
    {
        public DataContext Context()
        {
            return new DataContext();
        }
    }
}

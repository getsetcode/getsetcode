using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface IClientReader
    {
        Client Get(int id);

        Client Get(string name);
    }
}

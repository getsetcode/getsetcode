using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Presentation.Presentables;
using getsetcode.Business.Readers;
using getsetcode.Model;

namespace getsetcode.Presentation.Loaders
{
    public class ClientLoader : IClientLoader
    {
        IClientReader _reader;

        public ClientLoader(IClientReader reader)
        {
            _reader = reader;
        }

        public IClientPresentable GetPresentable(int id)
        {
            return getPresentable(id: id);
        }

        public IClientPresentable GetPresentable(string name)
        {
            return getPresentable(name: name);
        }

        public IClientPresentable getPresentable(string name = null, int? id = null)
        {
            Client c = null;
            if (!string.IsNullOrEmpty(name))
                c = _reader.Get(name);
            else if (id.HasValue)
                c = _reader.Get(id.Value);
            else
                throw new Exception("Invalid arguments provided in ClientLoader");

            if (c == null) return null;
            else return new ClientPresentable(c);
        }
    }
}

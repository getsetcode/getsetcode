using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Business.Readers;
using getsetcode.Presentation.Presentables;
using getsetcode.Model;

namespace getsetcode.Presentation.Loaders
{
    public class ProjectLoader : IProjectLoader
    {
        IProjectReader _reader;

        public ProjectLoader(IProjectReader reader)
        {
            _reader = reader;
        }

        public IProjectPresentable GetPresentable(int id)
        {
            return getPresentable(id: id);
        }

        public IProjectPresentable GetPresentable(string name)
        {
            return getPresentable(name: name);
        }

        public IEnumerable<IProjectPresentable> ListFeaturedPresentables()
        {
            foreach (var s in _reader.List(true))
            {
                yield return new ProjectPresentable(s);
            }
        }

        private IProjectPresentable getPresentable(string name = null, int? id = null)
        {
            Project p = null;
            if (!string.IsNullOrEmpty(name))
                p = _reader.Get(name);
            else if (id.HasValue)
                p = _reader.Get(id.Value);
            else
                throw new Exception("Invalid arguments provided in ProjectLoader");

            if (p == null) return null;
            else return new ProjectPresentable(p);
        }
    }
}

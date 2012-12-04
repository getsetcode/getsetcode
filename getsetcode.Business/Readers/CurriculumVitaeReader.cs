using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public class CurriculumVitaeReader : ICurriculumVitaeReader
    {
        IContextAccessor _accessor;

        public CurriculumVitaeReader(IContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public CurriculumVitae GetLatest()
        {
            using (var d = _accessor.Context())
            {
                return d.Context.CurriculaVitae
                    .OrderByDescending(cv => cv.DateAdded)
                    .FirstOrDefault();
            }
        }
    }
}

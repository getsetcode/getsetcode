using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface ICurriculumVitaeReader
    {
        CurriculumVitae GetLatest();
    }
}

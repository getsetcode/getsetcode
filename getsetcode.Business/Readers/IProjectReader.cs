using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Business.Readers
{
    public interface IProjectReader
    {
        Project Get(int id);
        
        Project Get(string name);
        
        IEnumerable<Project> List(bool? featured);
    }
}

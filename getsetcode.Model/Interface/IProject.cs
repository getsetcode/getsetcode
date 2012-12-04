using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface IProject
    {
        int ProjectId { get; }
        
        string Name { get; }
        
        string ShortName { get; }
        
        string BriefSummary { get; }
        
        string SummaryHtml { get; }

        bool Featured { get; }
    }
}

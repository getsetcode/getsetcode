using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface IClient
    {
        int ClientId { get; }
        
        string Name { get; }
        
        string ShortName { get; }
        
        string Address { get; }
        
        string BriefDescription { get; }

        string SummaryHtml { get; }
        
        string Website { get; }

        bool Featured { get; }
    }
}

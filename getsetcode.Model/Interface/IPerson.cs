using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface IPerson
    {
        int PersonId { get; }
        
        string Name { get; }
        
        string OfficePhone { get; }
        
        string MobilePhone { get; }
        
        string EmailAddress { get; }
        
        bool Active { get; }

        Nullable<int> ThumbnailId { get; } 
    }
}

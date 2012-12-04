using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface IHistoryItem
    {
        int HistoryId { get; }
        
        System.DateTime DateStamp { get; }
        
        Nullable<int> ProjectId { get; }
        
        Nullable<int> ClientId { get; }
        
        Nullable<int> TestimonialId { get; }
    }
}

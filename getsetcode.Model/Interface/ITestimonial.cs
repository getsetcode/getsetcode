using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getsetcode.Model.Interface
{
    public interface ITestimonial
    {
        int TestimonialId { get; }
        
        int PersonId { get; }
        
        DateTime Date { get; }
        
        Nullable<int> ClientId { get; }
        
        string Quote { get; }
        
        string Role { get; }
    }
}

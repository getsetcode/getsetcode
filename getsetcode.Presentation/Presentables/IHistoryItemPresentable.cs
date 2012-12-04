using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;

namespace getsetcode.Presentation.Presentables
{
    public interface IHistoryItemPresentable : IHistoryItem
    {
        string DisplayDate { get; }

        IClientPresentable Client { get; }
        
        IProjectPresentable Project { get; }

        ITestimonialPresentable Testimonial { get; }
    }
}

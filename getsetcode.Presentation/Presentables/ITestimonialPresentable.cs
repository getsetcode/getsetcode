using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;

namespace getsetcode.Presentation.Presentables
{
    public interface ITestimonialPresentable : ITestimonial, ILink
    {
        string DisplayDate { get; }

        IPersonPresentable Person { get; }

        IClientPresentable Client { get; }
    }
}

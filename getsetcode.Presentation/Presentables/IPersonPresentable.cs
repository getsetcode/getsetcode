using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using getsetcode.Model;

namespace getsetcode.Presentation.Presentables
{
    public interface IPersonPresentable : IPerson
    {
        Image Thumbnail { get; }
    }
}

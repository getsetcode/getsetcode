using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Presentation.Presentables
{
    public class HistoryItemPresentable : IHistoryItemPresentable
    {
        HistoryItem _base;

        public HistoryItemPresentable(HistoryItem hi)
        {
            _base = hi;
        }

        #region Raw Properties

        public int HistoryId { get { return _base.HistoryId; } }

        public System.DateTime DateStamp { get { return _base.DateStamp; } }

        public Nullable<int> ProjectId { get { return _base.ProjectId; } }

        public Nullable<int> ClientId { get { return _base.ClientId; } }

        public Nullable<int> TestimonialId { get { return _base.TestimonialId; } }

        #endregion
        
        public string DisplayDate
        {
            get { return string.Format("{0} {1} {2} {3}", _base.DateStamp.ToString("ddd").ToUpper(), _base.DateStamp.Day, _base.DateStamp.ToString("MMM").ToUpper(), _base.DateStamp.Year); }
        }

        public IClientPresentable Client
        {
            get
            {
                if (_base.Client == null) return null;
                else return new ClientPresentable(_base.Client);
            }
        }

        public IProjectPresentable Project
        {
            get
            {
                if (_base.Project == null) return null;
                else return new ProjectPresentable(_base.Project);
            }
        }

        public ITestimonialPresentable Testimonial
        {
            get
            {
                if (_base.Testimonial == null) return null;
                else return new TestimonialPresentable(_base.Testimonial);
            }
        }
    }
}

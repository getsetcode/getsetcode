using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;
using getsetcode.Model.Enum;

namespace getsetcode.Presentation.Presentables
{
    public class TestimonialPresentable : ITestimonialPresentable
    {
        Testimonial _base;

        public TestimonialPresentable(Testimonial testimonial)
        {
            _base = testimonial;
        }

        #region Raw Properties

        public int TestimonialId { get { return _base.TestimonialId; } }

        public int PersonId { get { return _base.PersonId; } }

        public DateTime Date { get { return _base.Date; } }

        public Nullable<int> ClientId { get { return _base.ClientId; } }

        public string Quote { get { return _base.Quote; } }

        public string Role { get { return _base.Role; } }

        #endregion

        #region ILink Members

        public int LinkID { get { return _base.TestimonialId; } }

        public string LinkStringID { get { return _base.TestimonialId.ToString(); } }

        public string LinkName { get { return string.Format("{0}, {1}", _base.Person.Name, _base.Date.ToString("MMMM yyyy")); } }

        public string LinkInfo { get { return _base.Quote; } }

        public string DetailAction { get { return "Detail"; } }

        public NavSection Section { get { return NavSection.Testimonials; } }

        #endregion

        public string DisplayDate
        {
            //get { return string.Format("{0} {1} {2} {3}", _base.Date.ToString("ddd").ToUpper(), _base.Date.Day, _base.Date.ToString("MMM").ToUpper(), _base.Date.Year); }
            get { return _base.Date.ToString("MMMM yyyy"); }
        }

        public IPersonPresentable Person
        {
            get { return new PersonPresentable(_base.Person); }
        }

        public IClientPresentable Client
        {
            get 
            {
                if (_base.Client == null) return null;
                else return new ClientPresentable(_base.Client); 
            }
        }

    }
}

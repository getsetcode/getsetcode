using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model;

namespace getsetcode.Presentation.Presentables
{
    public class PersonPresentable : IPersonPresentable
    {
        Person _base;

        public PersonPresentable(Person person)
        {
            _base = person;
        }

        #region Raw Properties

        public int PersonId { get { return _base.PersonId; } }

        public string Name { get { return _base.Name; } }

        public string OfficePhone { get { return _base.OfficePhone; } }

        public string MobilePhone { get { return _base.MobilePhone; } }

        public string EmailAddress { get { return _base.EmailAddress; } }

        public bool Active { get { return _base.Active; } }

        public Nullable<int> ThumbnailId { get { return _base.ThumbnailId; } }

        #endregion

        public Image Thumbnail
        {
            get { return _base.Thumbnail; }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace getsetcode.Model
{
    public partial class Client
    {
        #region Primitive Properties
    
        public virtual int ClientId
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string ShortName
        {
            get;
            set;
        }
    
        public virtual string Address
        {
            get;
            set;
        }
    
        public virtual string BriefDescription
        {
            get;
            set;
        }
    
        public virtual string Website
        {
            get;
            set;
        }
    
        public virtual bool Featured
        {
            get;
            set;
        }
    
        public virtual Nullable<int> LogoId
        {
            get { return _logoId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_logoId != value)
                    {
                        if (Logo != null && Logo.ImageId != value)
                        {
                            Logo = null;
                        }
                        _logoId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _logoId;
    
        public virtual string SummaryHtml
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Contract> Contracts
        {
            get
            {
                if (_contracts == null)
                {
                    var newCollection = new FixupCollection<Contract>();
                    newCollection.CollectionChanged += FixupContracts;
                    _contracts = newCollection;
                }
                return _contracts;
            }
            set
            {
                if (!ReferenceEquals(_contracts, value))
                {
                    var previousValue = _contracts as FixupCollection<Contract>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupContracts;
                    }
                    _contracts = value;
                    var newValue = value as FixupCollection<Contract>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupContracts;
                    }
                }
            }
        }
        private ICollection<Contract> _contracts;
    
        public virtual ICollection<HistoryItem> HistoryItems
        {
            get
            {
                if (_historyItems == null)
                {
                    var newCollection = new FixupCollection<HistoryItem>();
                    newCollection.CollectionChanged += FixupHistoryItems;
                    _historyItems = newCollection;
                }
                return _historyItems;
            }
            set
            {
                if (!ReferenceEquals(_historyItems, value))
                {
                    var previousValue = _historyItems as FixupCollection<HistoryItem>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHistoryItems;
                    }
                    _historyItems = value;
                    var newValue = value as FixupCollection<HistoryItem>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHistoryItems;
                    }
                }
            }
        }
        private ICollection<HistoryItem> _historyItems;
    
        public virtual ICollection<Project> Projects
        {
            get
            {
                if (_projects == null)
                {
                    var newCollection = new FixupCollection<Project>();
                    newCollection.CollectionChanged += FixupProjects;
                    _projects = newCollection;
                }
                return _projects;
            }
            set
            {
                if (!ReferenceEquals(_projects, value))
                {
                    var previousValue = _projects as FixupCollection<Project>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProjects;
                    }
                    _projects = value;
                    var newValue = value as FixupCollection<Project>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProjects;
                    }
                }
            }
        }
        private ICollection<Project> _projects;
    
        public virtual ICollection<Person> People
        {
            get
            {
                if (_people == null)
                {
                    var newCollection = new FixupCollection<Person>();
                    newCollection.CollectionChanged += FixupPeople;
                    _people = newCollection;
                }
                return _people;
            }
            set
            {
                if (!ReferenceEquals(_people, value))
                {
                    var previousValue = _people as FixupCollection<Person>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPeople;
                    }
                    _people = value;
                    var newValue = value as FixupCollection<Person>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPeople;
                    }
                }
            }
        }
        private ICollection<Person> _people;
    
        public virtual Image Logo
        {
            get { return _logo; }
            set
            {
                if (!ReferenceEquals(_logo, value))
                {
                    var previousValue = _logo;
                    _logo = value;
                    FixupLogo(previousValue);
                }
            }
        }
        private Image _logo;
    
        public virtual ICollection<Testimonial> Testimonials
        {
            get
            {
                if (_testimonials == null)
                {
                    var newCollection = new FixupCollection<Testimonial>();
                    newCollection.CollectionChanged += FixupTestimonials;
                    _testimonials = newCollection;
                }
                return _testimonials;
            }
            set
            {
                if (!ReferenceEquals(_testimonials, value))
                {
                    var previousValue = _testimonials as FixupCollection<Testimonial>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTestimonials;
                    }
                    _testimonials = value;
                    var newValue = value as FixupCollection<Testimonial>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTestimonials;
                    }
                }
            }
        }
        private ICollection<Testimonial> _testimonials;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupLogo(Image previousValue)
        {
            if (previousValue != null && previousValue.Clients.Contains(this))
            {
                previousValue.Clients.Remove(this);
            }
    
            if (Logo != null)
            {
                if (!Logo.Clients.Contains(this))
                {
                    Logo.Clients.Add(this);
                }
                if (LogoId != Logo.ImageId)
                {
                    LogoId = Logo.ImageId;
                }
            }
            else if (!_settingFK)
            {
                LogoId = null;
            }
        }
    
        private void FixupContracts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Contract item in e.NewItems)
                {
                    item.Client = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Contract item in e.OldItems)
                {
                    if (ReferenceEquals(item.Client, this))
                    {
                        item.Client = null;
                    }
                }
            }
        }
    
        private void FixupHistoryItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (HistoryItem item in e.NewItems)
                {
                    item.Client = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HistoryItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.Client, this))
                    {
                        item.Client = null;
                    }
                }
            }
        }
    
        private void FixupProjects(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Project item in e.NewItems)
                {
                    item.Client = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Project item in e.OldItems)
                {
                    if (ReferenceEquals(item.Client, this))
                    {
                        item.Client = null;
                    }
                }
            }
        }
    
        private void FixupPeople(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Person item in e.NewItems)
                {
                    if (!item.Clients.Contains(this))
                    {
                        item.Clients.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Person item in e.OldItems)
                {
                    if (item.Clients.Contains(this))
                    {
                        item.Clients.Remove(this);
                    }
                }
            }
        }
    
        private void FixupTestimonials(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Testimonial item in e.NewItems)
                {
                    item.Client = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Testimonial item in e.OldItems)
                {
                    if (ReferenceEquals(item.Client, this))
                    {
                        item.Client = null;
                    }
                }
            }
        }

        #endregion
    }
}

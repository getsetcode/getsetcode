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
    public partial class HistoryItem
    {
        #region Primitive Properties
    
        public virtual int HistoryId
        {
            get;
            set;
        }
    
        public virtual System.DateTime DateStamp
        {
            get;
            set;
        }
    
        public virtual Nullable<int> ProjectId
        {
            get { return _projectId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_projectId != value)
                    {
                        if (Project != null && Project.ProjectId != value)
                        {
                            Project = null;
                        }
                        _projectId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _projectId;
    
        public virtual Nullable<int> ClientId
        {
            get { return _clientId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_clientId != value)
                    {
                        if (Client != null && Client.ClientId != value)
                        {
                            Client = null;
                        }
                        _clientId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _clientId;
    
        public virtual Nullable<int> TestimonialId
        {
            get { return _testimonialId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_testimonialId != value)
                    {
                        if (Testimonial != null && Testimonial.TestimonialId != value)
                        {
                            Testimonial = null;
                        }
                        _testimonialId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _testimonialId;

        #endregion
        #region Navigation Properties
    
        public virtual Client Client
        {
            get { return _client; }
            set
            {
                if (!ReferenceEquals(_client, value))
                {
                    var previousValue = _client;
                    _client = value;
                    FixupClient(previousValue);
                }
            }
        }
        private Client _client;
    
        public virtual Project Project
        {
            get { return _project; }
            set
            {
                if (!ReferenceEquals(_project, value))
                {
                    var previousValue = _project;
                    _project = value;
                    FixupProject(previousValue);
                }
            }
        }
        private Project _project;
    
        public virtual Testimonial Testimonial
        {
            get { return _testimonial; }
            set
            {
                if (!ReferenceEquals(_testimonial, value))
                {
                    var previousValue = _testimonial;
                    _testimonial = value;
                    FixupTestimonial(previousValue);
                }
            }
        }
        private Testimonial _testimonial;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupClient(Client previousValue)
        {
            if (previousValue != null && previousValue.HistoryItems.Contains(this))
            {
                previousValue.HistoryItems.Remove(this);
            }
    
            if (Client != null)
            {
                if (!Client.HistoryItems.Contains(this))
                {
                    Client.HistoryItems.Add(this);
                }
                if (ClientId != Client.ClientId)
                {
                    ClientId = Client.ClientId;
                }
            }
            else if (!_settingFK)
            {
                ClientId = null;
            }
        }
    
        private void FixupProject(Project previousValue)
        {
            if (previousValue != null && previousValue.History.Contains(this))
            {
                previousValue.History.Remove(this);
            }
    
            if (Project != null)
            {
                if (!Project.History.Contains(this))
                {
                    Project.History.Add(this);
                }
                if (ProjectId != Project.ProjectId)
                {
                    ProjectId = Project.ProjectId;
                }
            }
            else if (!_settingFK)
            {
                ProjectId = null;
            }
        }
    
        private void FixupTestimonial(Testimonial previousValue)
        {
            if (previousValue != null && previousValue.HistoryItems.Contains(this))
            {
                previousValue.HistoryItems.Remove(this);
            }
    
            if (Testimonial != null)
            {
                if (!Testimonial.HistoryItems.Contains(this))
                {
                    Testimonial.HistoryItems.Add(this);
                }
                if (TestimonialId != Testimonial.TestimonialId)
                {
                    TestimonialId = Testimonial.TestimonialId;
                }
            }
            else if (!_settingFK)
            {
                TestimonialId = null;
            }
        }

        #endregion
    }
}
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
    public partial class Project
    {
        #region Primitive Properties
    
        public virtual int ProjectId
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
    
        public virtual string BriefSummary
        {
            get;
            set;
        }
    
        public virtual bool Featured
        {
            get;
            set;
        }
    
        public virtual int ClientId
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
        private int _clientId;
    
        public virtual Nullable<int> ThumbnailImageId
        {
            get { return _thumbnailImageId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_thumbnailImageId != value)
                    {
                        if (ThumbnailImage != null && ThumbnailImage.ImageId != value)
                        {
                            ThumbnailImage = null;
                        }
                        _thumbnailImageId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _thumbnailImageId;
    
        public virtual string SummaryHtml
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> StartDate
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> EndDate
        {
            get;
            set;
        }

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
    
        public virtual ICollection<HistoryItem> History
        {
            get
            {
                if (_history == null)
                {
                    var newCollection = new FixupCollection<HistoryItem>();
                    newCollection.CollectionChanged += FixupHistory;
                    _history = newCollection;
                }
                return _history;
            }
            set
            {
                if (!ReferenceEquals(_history, value))
                {
                    var previousValue = _history as FixupCollection<HistoryItem>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupHistory;
                    }
                    _history = value;
                    var newValue = value as FixupCollection<HistoryItem>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupHistory;
                    }
                }
            }
        }
        private ICollection<HistoryItem> _history;
    
        public virtual ICollection<ProjectImage> ProjectImages
        {
            get
            {
                if (_projectImages == null)
                {
                    var newCollection = new FixupCollection<ProjectImage>();
                    newCollection.CollectionChanged += FixupProjectImages;
                    _projectImages = newCollection;
                }
                return _projectImages;
            }
            set
            {
                if (!ReferenceEquals(_projectImages, value))
                {
                    var previousValue = _projectImages as FixupCollection<ProjectImage>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProjectImages;
                    }
                    _projectImages = value;
                    var newValue = value as FixupCollection<ProjectImage>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProjectImages;
                    }
                }
            }
        }
        private ICollection<ProjectImage> _projectImages;
    
        public virtual ICollection<ProjectResponsibility> ProjectResponsibilities
        {
            get
            {
                if (_projectResponsibilities == null)
                {
                    var newCollection = new FixupCollection<ProjectResponsibility>();
                    newCollection.CollectionChanged += FixupProjectResponsibilities;
                    _projectResponsibilities = newCollection;
                }
                return _projectResponsibilities;
            }
            set
            {
                if (!ReferenceEquals(_projectResponsibilities, value))
                {
                    var previousValue = _projectResponsibilities as FixupCollection<ProjectResponsibility>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProjectResponsibilities;
                    }
                    _projectResponsibilities = value;
                    var newValue = value as FixupCollection<ProjectResponsibility>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProjectResponsibilities;
                    }
                }
            }
        }
        private ICollection<ProjectResponsibility> _projectResponsibilities;
    
        public virtual ICollection<ProjectSkill> ProjectSkills
        {
            get
            {
                if (_projectSkills == null)
                {
                    var newCollection = new FixupCollection<ProjectSkill>();
                    newCollection.CollectionChanged += FixupProjectSkills;
                    _projectSkills = newCollection;
                }
                return _projectSkills;
            }
            set
            {
                if (!ReferenceEquals(_projectSkills, value))
                {
                    var previousValue = _projectSkills as FixupCollection<ProjectSkill>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProjectSkills;
                    }
                    _projectSkills = value;
                    var newValue = value as FixupCollection<ProjectSkill>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProjectSkills;
                    }
                }
            }
        }
        private ICollection<ProjectSkill> _projectSkills;
    
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
    
        public virtual Image ThumbnailImage
        {
            get { return _thumbnailImage; }
            set
            {
                if (!ReferenceEquals(_thumbnailImage, value))
                {
                    var previousValue = _thumbnailImage;
                    _thumbnailImage = value;
                    FixupThumbnailImage(previousValue);
                }
            }
        }
        private Image _thumbnailImage;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupClient(Client previousValue)
        {
            if (previousValue != null && previousValue.Projects.Contains(this))
            {
                previousValue.Projects.Remove(this);
            }
    
            if (Client != null)
            {
                if (!Client.Projects.Contains(this))
                {
                    Client.Projects.Add(this);
                }
                if (ClientId != Client.ClientId)
                {
                    ClientId = Client.ClientId;
                }
            }
        }
    
        private void FixupThumbnailImage(Image previousValue)
        {
            if (previousValue != null && previousValue.Projects.Contains(this))
            {
                previousValue.Projects.Remove(this);
            }
    
            if (ThumbnailImage != null)
            {
                if (!ThumbnailImage.Projects.Contains(this))
                {
                    ThumbnailImage.Projects.Add(this);
                }
                if (ThumbnailImageId != ThumbnailImage.ImageId)
                {
                    ThumbnailImageId = ThumbnailImage.ImageId;
                }
            }
            else if (!_settingFK)
            {
                ThumbnailImageId = null;
            }
        }
    
        private void FixupHistory(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (HistoryItem item in e.NewItems)
                {
                    item.Project = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (HistoryItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.Project, this))
                    {
                        item.Project = null;
                    }
                }
            }
        }
    
        private void FixupProjectImages(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProjectImage item in e.NewItems)
                {
                    item.Project = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProjectImage item in e.OldItems)
                {
                    if (ReferenceEquals(item.Project, this))
                    {
                        item.Project = null;
                    }
                }
            }
        }
    
        private void FixupProjectResponsibilities(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProjectResponsibility item in e.NewItems)
                {
                    item.Project = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProjectResponsibility item in e.OldItems)
                {
                    if (ReferenceEquals(item.Project, this))
                    {
                        item.Project = null;
                    }
                }
            }
        }
    
        private void FixupProjectSkills(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProjectSkill item in e.NewItems)
                {
                    item.Project = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProjectSkill item in e.OldItems)
                {
                    if (ReferenceEquals(item.Project, this))
                    {
                        item.Project = null;
                    }
                }
            }
        }
    
        private void FixupContracts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Contract item in e.NewItems)
                {
                    if (!item.Projects.Contains(this))
                    {
                        item.Projects.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Contract item in e.OldItems)
                {
                    if (item.Projects.Contains(this))
                    {
                        item.Projects.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
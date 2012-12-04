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
    public partial class ProjectImage
    {
        #region Primitive Properties
    
        public virtual int ProjectId
        {
            get { return _projectId; }
            set
            {
                if (_projectId != value)
                {
                    if (Project != null && Project.ProjectId != value)
                    {
                        Project = null;
                    }
                    _projectId = value;
                }
            }
        }
        private int _projectId;
    
        public virtual int ImageId
        {
            get { return _imageId; }
            set
            {
                if (_imageId != value)
                {
                    if (Image != null && Image.ImageId != value)
                    {
                        Image = null;
                    }
                    _imageId = value;
                }
            }
        }
        private int _imageId;
    
        public virtual byte Rank
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Image Image
        {
            get { return _image; }
            set
            {
                if (!ReferenceEquals(_image, value))
                {
                    var previousValue = _image;
                    _image = value;
                    FixupImage(previousValue);
                }
            }
        }
        private Image _image;
    
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

        #endregion
        #region Association Fixup
    
        private void FixupImage(Image previousValue)
        {
            if (previousValue != null && previousValue.ImageProjects.Contains(this))
            {
                previousValue.ImageProjects.Remove(this);
            }
    
            if (Image != null)
            {
                if (!Image.ImageProjects.Contains(this))
                {
                    Image.ImageProjects.Add(this);
                }
                if (ImageId != Image.ImageId)
                {
                    ImageId = Image.ImageId;
                }
            }
        }
    
        private void FixupProject(Project previousValue)
        {
            if (previousValue != null && previousValue.ProjectImages.Contains(this))
            {
                previousValue.ProjectImages.Remove(this);
            }
    
            if (Project != null)
            {
                if (!Project.ProjectImages.Contains(this))
                {
                    Project.ProjectImages.Add(this);
                }
                if (ProjectId != Project.ProjectId)
                {
                    ProjectId = Project.ProjectId;
                }
            }
        }

        #endregion
    }
}
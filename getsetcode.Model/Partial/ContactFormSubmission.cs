using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getsetcode.Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace getsetcode.Model
{
    [MetadataType(typeof(IContactFormSubmissionMetadata))]
    public partial class ContactFormSubmission : IContactFormSubmissionMetadata
    {
    }
}

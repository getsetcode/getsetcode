using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace getsetcode.Model.Interface
{
    public interface IContactFormSubmissionMetadata
    {
        [MaxLength(100)]
        [Display(Name = "Your name")]
        [Required(ErrorMessage = "Please enter your name")]
        string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Your email")]
        [Required(ErrorMessage = "Please provide an email address")]
        string EmailAddress { get; set; }

        [Display(Name = "Your message")]
        [Required(ErrorMessage = "Please include a message")]
        [DataType(DataType.MultilineText)]
        string Message { get; set; }
    }
}

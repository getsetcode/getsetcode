using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Web.Controllers;
using getsetcode.Web.Models.Shared;
using getsetcode.Model.Enum;
using getsetcode.Model;

namespace getsetcode.Web.Models.Home
{
    public class HomePageData
    {
        public ContactFormSubmission ContactFormSubmission { get; set; }

        public HomeController.Message? Message { get; set; }

        public string MessageText
        {
            get
            {
                if (Message == null) return null;
                else switch (Message.Value)
                {
                    case HomeController.Message.emailsent:
                            return "Thank you for your email. Tom will be in touch!";
                    default:
                            return null;
                }
            }
        }

        public bool ShowContractStatus
        {
            get
            {
                return SideBarData.LatestContract.Status != ContractStatus.Unavailable 
                    && (Message == null || Message.Value != HomeController.Message.emailsent);
            }
        }

        public string ContractMessage
        {
            get
            {
                if (!ShowContractStatus) return null;
                else if (SideBarData.LatestContract.Status == ContractStatus.Available)
                    return "Tom is currently available to work on your project.";
                else if (SideBarData.LatestContract.Status == ContractStatus.EndingSoon)
                    return "Tom's current contract is ending soon. Use the contact form to get in touch.";
                else
                    return null;
            }
        }

        public MainSideBarData SideBarData { get; set; }
    }
}
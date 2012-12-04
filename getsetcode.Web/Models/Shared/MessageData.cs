using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using getsetcode.Model.Enum;

namespace getsetcode.Web.Models.Shared
{
    public class MessageData
    {
        public List<string> Messages { get; set; }

        public MessageType MessageType { get; set; }

        public bool Closeable { get; set; }

        public string IconAttribute
        {
            get
            {
                switch (MessageType)
                {
                    case MessageType.Error:
                        return "icon-exclamation-sign";
                    case MessageType.Info:
                    case MessageType.Default:
                        return "icon-info-sign";
                    case MessageType.Warning:
                        return "icon-warning-sign";
                    case MessageType.Success:
                        return "icon-ok-sign";
                    default:
                        throw messageTypeException(MessageType);
                }
            }
        }

        public string CssClass 
        {
            get
            {
                switch (MessageType)
                {
                    case MessageType.Error:
                        return "alert-error";
                    case MessageType.Info:
                    case MessageType.Default:
                        return "alert-info";
                    case MessageType.Warning:
                        return null;
                    case MessageType.Success:
                        return "alert-success";
                    default:
                        throw messageTypeException(MessageType);
                }
            }
        }

        private Exception messageTypeException(MessageType type)
        {
            return new Exception(string.Format("Unrecognised message type: {0}", type));
        }
    }
}
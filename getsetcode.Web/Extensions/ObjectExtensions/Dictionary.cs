using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace getsetcode.Web.Extensions.ObjectExtensions
{
    public static partial class Dictionary
    {
        ///<summary>
        /// Convert an object into a dictionary
        ///</summary>
        ///<param name="object">The object</param>
        ///<param name="nullHandler">Handler for null value</param>
        ///<returns></returns>
        public static Dictionary<string, object> ToDictionary(this object @object, Func<string, object> nullHandler = null)
        {
            if (@object == null)
            {
                return new Dictionary<string, object>();
            }

            var properties = TypeDescriptor.GetProperties(@object);

            var hash = new Dictionary<string, object>(properties.Count);

            foreach (PropertyDescriptor descriptor in properties)
            {
                var key = descriptor.Name;
                var value = descriptor.GetValue(@object);

                if (value != null)
                {
                    hash.Add(key, value);
                }
                else if (nullHandler != null)
                {
                    hash.Add(key, nullHandler(key));
                }
            }

            return hash;
        }
    }
}
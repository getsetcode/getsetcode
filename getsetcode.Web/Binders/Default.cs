using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Common;
using getsetcode.Web.Services;

namespace getsetcode.Web.Binders
{
    public class Default : NinjectModule
    {
        public override void Load()
        {
            Bind<IContactFormFactory>().To<ContactFormFactory>();

            Bind<ICookieHandler>().To<CookieHandler>().When(x => HttpContext.Current != null).InRequestScope().WithConstructorArgument("httpContext", c => HttpContext.Current);
        }
    }
}
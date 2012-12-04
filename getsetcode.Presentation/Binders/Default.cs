using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using getsetcode.Presentation.Loaders;

namespace getsetcode.Presentation.Binders
{
    public class Default : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientLoader>().To<ClientLoader>();
            Bind<IContactFormSubmissionLoader>().To<ContactFormSubmissionLoader>();
            Bind<IContractLoader>().To<ContractLoader>();
            Bind<IHistoryLoader>().To<HistoryLoader>();
            Bind<IProjectLoader>().To<ProjectLoader>();
            Bind<ISkillLoader>().To<SkillLoader>();
            Bind<ITestimonialLoader>().To<TestimonialLoader>();
        }
    }
}

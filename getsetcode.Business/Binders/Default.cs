using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using getsetcode.Business.Readers;
using getsetcode.Business.Writers;
using getsetcode.Business.Communicators;

namespace getsetcode.Business.Binders
{
    public class Default : NinjectModule
    {
        public override void Load()
        {
            Bind<IContextAccessor>().To<ContextAccessor>();

            // Readers
            Bind<ISkillReader>().To<SkillReader>();
            Bind<IProjectReader>().To<ProjectReader>();
            Bind<IClientReader>().To<ClientReader>();
            Bind<ITestimonialReader>().To<TestimonialReader>();
            Bind<IHistoryReader>().To<HistoryReader>();
            Bind<IContactFormSubmissionReader>().To<ContactFormSubmissionReader>();
            Bind<IContractReader>().To<ContractReader>();
            Bind<ICurriculumVitaeReader>().To<CurriculumVitaeReader>();

            // Writers
            Bind<IContactFormSubmissionWriter>().To<ContactFormSubmissionWriter>();

            // Communicators
            Bind<ISmtpService>().To<SmtpService>();
        }
    }
}

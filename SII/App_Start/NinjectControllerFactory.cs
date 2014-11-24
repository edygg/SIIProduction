using SII.Models;
using Ninject;
using System.Web.Mvc;

namespace SII.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ICampusRepository>().To<EFCampusRepository>();
            ninjectKernel.Bind<IAnnouncementRepository>().To<EFAnnouncementRepository>();
            ninjectKernel.Bind<IVisitRepository>().To<EFVisitRepository>();
            ninjectKernel.Bind<IBarrierRepository>().To<EFBarrierRepository>();
            ninjectKernel.Bind<IEntranceRepository>().To<EFEntranceRepository>();
        }
    }
}
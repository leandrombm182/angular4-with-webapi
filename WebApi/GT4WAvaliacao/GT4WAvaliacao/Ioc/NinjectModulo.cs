using GT4WAvaliacao.DAL.Interfaces;
using GT4WAvaliacao.DAL.Repository;
using Ninject.Modules;

namespace GT4WAvaliacao.Ioc
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
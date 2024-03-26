using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

        builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
        builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();


    }
}
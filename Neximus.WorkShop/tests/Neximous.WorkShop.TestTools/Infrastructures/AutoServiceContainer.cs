using Autofac;
using FluentGenerator;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximous.WorkShop.TestTools.Infrastructures
{
    public class AutoServiceCreator<T> : AutoServiceConfiguration
    {
        public override void ServicesConfiguration(
            ContainerBuilder container,
            Dictionary<Type, object> mockedServiceParameters,
            DbContext context)
        {
            container.RegisterAssemblyTypes(
                typeof(IService).Assembly)
                .AssignableTo<IService>()
                .AsImplementedInterfaces()
                .WithConstructorParameters(mockedServiceParameters)
                .InstancePerLifetimeScope();

            container.RegisterAssemblyTypes(
                typeof(EFDataContext).Assembly)
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .WithDbContext(context as EFDataContext)
                .WithConstructorParameters(mockedServiceParameters)
                .InstancePerLifetimeScope();

            container.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .WithDbContext(context as EFDataContext)
                .InstancePerLifetimeScope();
        }

        public override DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)
        {
            var constructorParameters =
                AutoServiceTools.MockObjectListCreator();

            return new InMemoryDataBase()
                .CreateInMemoryDataContext<EFDataContext>(
                sqliteConnection,
                null);
        }

        public override DbContext SqlServerConfiguration()
        {
            return new EFDataContext(GetConnectionString());
        }
    }
}

using Neximus.WorkShop.Persistance.Infrastructures;

namespace Neximous.WorkShop.TestTools.Infrastructures
{
    public class IntegrationSut<T> : AutoServiceCreator<T> where T : class
    {
        public IntegrationSut()
        {
            Sut = CreateService<T>(dataBase: FluentGenerator.DataBaseType.SqlServerDataBase);
            Context = GetContext<EFDataContext>();
        }

        public IntegrationSut(Dictionary<Type, object> mockedObjects)
        {
            MockedObjects = mockedObjects;
            Sut = CreateService<T>(
                   dataBase: FluentGenerator.DataBaseType
                                            .SqlServerDataBase);
            Context = GetContext<EFDataContext>();
        }

        public T Sut { get; }
        public EFDataContext Context { get; }
    }
}

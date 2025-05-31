using Neximus.WorkShop.Persistance.Infrastructures;

namespace Neximous.WorkShop.TestTools.Infrastructures
{
    public class UnitSut<T> : AutoServiceCreator<T> where T : class
    {
        public UnitSut()
        {
            Sut = CreateService<T>(dataBase: FluentGenerator.DataBaseType.SqlLiteDataBase);
            Context = GetContext<EFDataContext>();
        }

        public UnitSut(Dictionary<Type, object> mockedObjects)
        {
            MockedObjects = mockedObjects;
            Sut = CreateService<T>(
                   dataBase: FluentGenerator.DataBaseType
                                            .SqlLiteDataBase);
            Context = GetContext<EFDataContext>();
        }

        public T Sut { get; }
        public EFDataContext Context { get; }
    }
}

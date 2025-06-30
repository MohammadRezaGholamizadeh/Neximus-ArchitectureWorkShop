namespace Neximous.WorkShop.TestTools.Infrastructures;

public class Generator
{
    public static Generator Engine { get; set; }
}

public static class BuilderTools
{
    public static T UpdateWithValue<T>(this T _object, Action<T> config)
        where T : class
    {
        config.Invoke(_object);
        return _object;
    }
}
namespace Neximous.WorkShop.TestTools.Infrastructures
{
    public class Generator
    {
        public static Generator Engine { get; set; }
    }

    public static class BuilderTools
    {
        public static T UpdateWithValue<T>(
            this T _objecct,
            Action<T> config) where T : class
        {
            config.Invoke(_objecct);
            return _objecct;
        }
    }
}

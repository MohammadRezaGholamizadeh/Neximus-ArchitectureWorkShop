namespace Neximus.WorkShop.Migrations
{
    public class ScriptResourceManager
    {
        public string Read(string name)
        {
            var assembly = typeof(ScriptResourceManager).Assembly;
            var resourcesBasePath = typeof(ScriptResourceManager).Namespace;

            var resourcePath = $"{resourcesBasePath}.Migrations.Scripts.{name}";

            using (var stream =
                       assembly.GetManifestResourceStream(resourcePath))
            {
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            }
        }
    }
}

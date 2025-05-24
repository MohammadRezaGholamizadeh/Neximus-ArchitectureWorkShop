using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neximus.WorkShop.Migrations;
// secuence of migration files is important
public class MigrationRunner
{
    private readonly MigrationSettings _object;
    private static MigrationSettings _connectionString;

    public static void Main(string[] args)
    {
        _connectionString = MigrationSettings.Instance.GetConnectionString();
        RunRootMigrations(args, _connectionString.ConnectionString);
    }

    public static void RunRootMigrations(string[]? args, string connectionString)
    {
        var options = connectionString;

        CreateDatabaseSchema(connectionString);

        var runner = CreateRunner(connectionString, _connectionString);
        runner.MigrateUp();
    }

    public static void CreateDatabaseSchema(string connectionString)
    {
        var databaseName = GetDatabaseName(connectionString);
        string masterConnectionString = ChangeDatabaseName(
            connectionString, "master");
        var commandScript =
            $"if db_id(N'{databaseName}') is null create database" +
            $" [{databaseName}]";

        using var connection = new SqlConnection(masterConnectionString);
        using var command = new SqlCommand(commandScript, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    private static string ChangeDatabaseName(
        string connectionString, string databaseName)
    {
        var csb = new SqlConnectionStringBuilder(connectionString)
        {
            InitialCatalog = databaseName
        };
        return csb.ConnectionString;
    }

    private static string GetDatabaseName(string connectionString)
    {
        return new SqlConnectionStringBuilder(
            connectionString).InitialCatalog;
    }

    private static FluentMigrator.Runner.IMigrationRunner CreateRunner(
        string connectionString, MigrationSettings options)
    {
        var container = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(_ => _
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(MigrationRunner).Assembly).For.All())
            .AddSingleton<MigrationSettings>(options)
            .AddSingleton<ScriptResourceManager>()
            .AddLogging(_ => _.AddFluentMigratorConsole())
            .BuildServiceProvider();
        return container.GetRequiredService<FluentMigrator.Runner.IMigrationRunner>();
    }
}

// setting
public class MigrationSettings
{
    public string ConnectionString { get; set; }
    public static MigrationSettings Instance => new MigrationSettings();
}

public static class MigrationTools
{

    public static MigrationSettings GetConnectionString(this MigrationSettings settings)
    {
        var configuration =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("MigrationSetting.json")
                .AddEnvironmentVariables()
                .Build();

        configuration.Bind(nameof(MigrationSettings), settings);
        return settings;
    }
}


using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations
{
    [Migration(202505132119)]
    public class _202505132119_initUserTables:Migration
    {
        
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsString(450).PrimaryKey()
                .WithColumn("UserName").AsString().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("Gender").AsByte().NotNullable()
                .WithColumn("RegistrationDate").AsDateTime().NotNullable()

                .WithColumn("MobileNumber").AsString().NotNullable()
                .WithColumn("CountryCallingCode").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("ImageExtension").AsString().NotNullable()
                .WithColumn("ImageId").AsString().NotNullable();

            Create.Table("UserAddresses")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("UserId").AsString(450).NotNullable()
                .ForeignKey("FK_UserAddresses_Users", "Users", "Id")
                .OnDelete(System.Data.Rule.Cascade)
                .WithColumn("Address").AsString().NotNullable()
            
                .WithColumn("Country").AsString().NotNullable()
                .WithColumn("City").AsString().NotNullable()
           .WithColumn("PostalCode").AsString().NotNullable();

            //Create.ForeignKey().FromTable("UserAddresses").ForeignColumn("UserId")
            //    .ToTable("Users").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("UserAddresses");
            Delete.Table("Users");
        }
    }
}

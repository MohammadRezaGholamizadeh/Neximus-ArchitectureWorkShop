using FluentMigrator;

namespace Neximus.WorkShop.Domain.HumanResources.Users
{
    [Migration(202505132138)]
    public class _202505132138_AddUsersTables : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                  .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
                  .WithColumn("UserName").AsString().NotNullable()
                  .WithColumn("FirstName").AsString().NotNullable()
                  .WithColumn("LastName").AsString().NotNullable()
                  .WithColumn("IsActive").AsBoolean().NotNullable()
                  .WithColumn("Gender").AsByte().NotNullable()
                  .WithColumn("CreationDate").AsDateTime().NotNullable()
                  .WithColumn("RegistrationDate").AsDateTime().NotNullable()
                  .WithColumn("MobileNumber").AsString().NotNullable()
                  .WithColumn("CountryCallingCode").AsString().NotNullable()
                  .WithColumn("Email").AsString().NotNullable()
                  .WithColumn("ImageId").AsString().NotNullable()
                  .WithColumn("ImageExtension").AsString().NotNullable();

            Create.Table("UserAddresses")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("UserId").AsString(450).NotNullable()
                    .ForeignKey("FK_UserAddresses_Users", "Users", "Id")
                    .OnDelete(System.Data.Rule.Cascade)
                .WithColumn("Address").AsString().NotNullable()
                .WithColumn("Country").AsString().NotNullable()
                .WithColumn("City").AsString().NotNullable()
                .WithColumn("PostalCode").AsString().NotNullable();

            Create.Table("Employees")
                  .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
                      .ForeignKey("FK_Employees_Users", "Users", "Id")
                      .OnDelete(System.Data.Rule.Cascade)
                  .WithColumn("PersonnelNumber").AsString(200).NotNullable()
                  .WithColumn("EmergencyCode").AsString(200).NotNullable();

            Create.Table("Customers")
                  .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
                      .ForeignKey("FK_Customers_Users", "Users", "Id")
                      .OnDelete(System.Data.Rule.Cascade)
                  .WithColumn("OrderNumber").AsInt32().NotNullable()
                  .WithColumn("Identifire").AsString(200).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Customers");
            Delete.Table("Employees");
            Delete.Table("UserAddresses");
            Delete.Table("Users");
        }
    }
}

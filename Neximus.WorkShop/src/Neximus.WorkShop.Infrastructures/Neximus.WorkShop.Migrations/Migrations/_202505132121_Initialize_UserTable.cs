using System.Data;
using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;
[Migration(202505132121)]
public class _202505132121_Initialize_UserTable : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
            .WithColumn("UserName").AsString(300).NotNullable()
            .WithColumn("FirstName").AsString(300).NotNullable()
            .WithColumn("LastName").AsString(300).NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreationDate").AsDateTime().NotNullable()
            .WithColumn("Gender").AsByte().NotNullable().WithDefaultValue(0)
            .WithColumn("RegistrationDate").AsDateTime().NotNullable()
            .WithColumn("MobileNumber").AsString(11).NotNullable()
            .WithColumn("CountryCallingCode").AsString(5).NotNullable()
            .WithColumn("Email").AsString(150).NotNullable()
            .WithColumn("ImageId").AsString(100).NotNullable()
            .WithColumn("ImageExtension").AsString(100).NotNullable();

        
        Create.Table("UserAddresses")
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("UserId").AsString(450).NotNullable()
            .ForeignKey("FK_UserAddresses_Users", "Users", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("Address").AsString(2000).NotNullable()
            .WithColumn("Country").AsString(250).NotNullable()
            .WithColumn("City").AsString(250).NotNullable()
            .WithColumn("PostalCode").AsString(250).NotNullable();


        Create.Table("Customers")
            .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
            .ForeignKey("FK_Customers_Users", "Users", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("OrderNumber").AsInt32().NotNullable()
            .WithColumn("Identifire").AsString(100).NotNullable();

        Create.Table("Employees")
            .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
            .ForeignKey("FK_Employees_Users", "Users", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("PersonnelNumber").AsString(100).NotNullable()
            .WithColumn("EmergencyCode").AsString(100).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Employees");
        Delete.Table("Customers");
        Delete.Table("UserAddresses");
        Delete.Table("Users");
    }
}
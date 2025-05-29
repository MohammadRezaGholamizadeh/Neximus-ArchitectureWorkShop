using System.Data;
using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;
[Migration(202505182253)]
public class _202505182253_InittialCartAndCartItem : Migration
{
    public override void Up()
    {
        Create.Table("Carts")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("UserId").AsString(450).NotNullable()
            .ForeignKey("FK_Carts_Users","Users","Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("ModificationDate").AsDateTime().NotNullable()
            .WithColumn("CreationDate").AsDateTime().NotNullable();

        Create.Table("CartItems")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("CartId").AsInt64().NotNullable()
            .ForeignKey("FK_CartItems_Carts", "Carts", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("ProductId").AsInt64().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("CartItems");  
        Delete.Table("Carts");  
    }
}
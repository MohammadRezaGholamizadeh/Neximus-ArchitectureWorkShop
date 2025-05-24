using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;

[Migration(202505242117)]
public class _202505242117_AddCartAndCartItemTables : Migration
{
    public override void Down()
    {
        Delete.Table("CartItems");
        Delete.Table("Carts");
    }

    public override void Up()
    {
        Create.Table("Carts")
              .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
              .WithColumn("UserId").AsString(450).NotNullable()
                  .ForeignKey("FK_Carts_Users", "Users", "Id")
                  .OnDelete(System.Data.Rule.Cascade)
              .WithColumn("ModificationDate").AsDateTime().NotNullable()
              .WithColumn("CreationDate").AsDateTime().NotNullable();

        Create.Table("CartItems")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("CartId").AsInt64().NotNullable()
                .ForeignKey("FK_CartItems_Carts", "Carts", "Id")
                .OnDelete(System.Data.Rule.Cascade)
            .WithColumn("ProductId").AsInt64().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable();
    }
}
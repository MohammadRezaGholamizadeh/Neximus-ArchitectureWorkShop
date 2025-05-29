using System.Data;
using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;

[Migration(202505182317)]
public class _202505182317_InitialOrderAndOrderItem : Migration
{
    public override void Up()
    {
        Create.Table("Orders")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("UserId").AsString(450).NotNullable()
            .ForeignKey("FK_Orders_Users","Users","Id")
            .WithColumn("CreationDate").AsDateTime().NotNullable()
            .WithColumn("PaymentDate").AsDateTime().NotNullable()
            .WithColumn("TransactionNumber").AsString(350).NotNullable()
            .WithColumn("TotalPrice").AsDecimal().NotNullable()
            .WithColumn("TotalDiscount").AsDecimal().NotNullable();

        Create.Table("OrderItems")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("OrderId").AsInt64().NotNullable()
            .ForeignKey("FK_OrderItems_Orders", "Orders", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("ProductId").AsInt64().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn("PricePerProduct").AsDecimal().NotNullable()
            .WithColumn("TotalPrice").AsDecimal().NotNullable()
            .WithColumn("TotalDiscount").AsDecimal().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("OrderItems");
        Delete.Table("Orders");
    }
}
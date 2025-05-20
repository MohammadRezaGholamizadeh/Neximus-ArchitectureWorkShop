using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations
{
    [Migration(202505172046)]
    public class _202505172046_AddOrderAndOrderItemTables : Migration
    {
        public override void Down()
        {
            Delete.Table("OrderItems");
            Delete.Table("Orders");
        }

        public override void Up()
        {
            Create.Table("Orders")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsString(450).NotNullable()
                     .ForeignKey("FK_Orders_Users", "Users", "Id")
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("TransactionNumber").AsString().NotNullable()
                .WithColumn("TotalPrice").AsDecimal().NotNullable()
                .WithColumn("TotalDiscount").AsDecimal().NotNullable();

            Create.Table("OrderItems")
                  .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                  .WithColumn("OrderId").AsInt64().NotNullable()
                       .ForeignKey("FK_OrderItems_Orders", "Orders", "Id")
                       .OnDelete(System.Data.Rule.Cascade)
                  .WithColumn("ProductId").AsInt64().NotNullable()
                  .WithColumn("Quantity").AsInt32().NotNullable()
                  .WithColumn("PricePerProduct").AsDecimal().NotNullable()
                  .WithColumn("TotalPrice").AsDecimal().NotNullable()
                  .WithColumn("TotalDiscount").AsDecimal().NotNullable();
        }
    }
}

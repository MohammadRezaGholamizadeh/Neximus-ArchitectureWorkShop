using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;

[Migration(202505242143)]
public class _202505242143_AddProductAndProductCategoryTables : Migration
{
    public override void Down()
    {
        Delete.Table("ProductImages");
        Delete.ForeignKey("FK_CartItems_Products");
        Delete.Table("Products");
        Delete.Table("ProductCategories");
    }

    public override void Up()
    {
        Create.Table("ProductCategories")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("Title").AsString(200).NotNullable()
            .WithColumn("Description").AsString(2000).NotNullable()
            .WithColumn("Slug").AsString(500);

        Create.Table("Products")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("Name").AsString(200).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("Stock").AsInt32().NotNullable()
            .WithColumn("CategoryId").AsInt64().NotNullable()
              .ForeignKey("FK_Products_ProductCategories", "ProductCategories", "Id")
            .WithColumn("PaperCount").AsInt32().NotNullable()
            .WithColumn("AuthorName").AsString(200).NotNullable()
            .WithColumn("PublishDate").AsDateTime().NotNullable()
            .WithColumn("ISBN").AsString().NotNullable()
            .WithColumn("Discount").AsDecimal().NotNullable();

        Create.ForeignKey("FK_CartItems_Products")
              .FromTable("CartItems").ForeignColumn("ProductId")
              .ToTable("Products").PrimaryColumn("Id")
              .OnDelete(System.Data.Rule.Cascade);

        Create.Table("ProductImages")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProductId").AsInt64().NotNullable()
                .ForeignKey("FK_ProductImages_Products", "Products", "Id")
                .OnDelete(System.Data.Rule.Cascade)
            .WithColumn("ImageId").AsString(450).NotNullable()
            .WithColumn("ImageExtension").AsString(10).NotNullable();
    }
}
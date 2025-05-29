using System.Data;
using FluentMigrator;

namespace Neximus.WorkShop.Migrations.Migrations;

[Migration(202505182352)]
public class _202505182352_InitialProductAndProductCategory : Migration
{
    public override void Up()
    {
        Create.Table("ProductCategories")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("Title").AsString(200).NotNullable()
            .WithColumn("Description").AsString(2500).NotNullable()
            .WithColumn("Slug").AsString(400).NotNullable();
        
        Create.Table("Products")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(300).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("Stock").AsInt32().NotNullable()
            .WithColumn("CategoryId").AsInt64().NotNullable()
            .ForeignKey("FK_Products_ProductCategories", "ProductCategories", "Id")
            .WithColumn("PaperCount").AsInt32().NotNullable()
            .WithColumn("AuthorName").AsString(150).NotNullable()
            .WithColumn("PublishDate").AsDateTime().NotNullable()
            .WithColumn("ISBN").AsString(150).NotNullable()
            .WithColumn("Discount").AsInt64().NotNullable();

        Create.ForeignKey("FK_CartItems_Products")
            .FromTable("CartItems").ForeignColumn("ProductId")
            .ToTable("Products").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);

        Create.Table("ProductImages")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_ProductImages_Products", "Products", "Id")
            .OnDelete(Rule.Cascade)
            .WithColumn("ImageId").AsString(450).NotNullable()
            .WithColumn("ImageExtension").AsString(10).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("ProductImages");
        Delete.Table("FK_CartItems_Products");
        Delete.Table("Products");
        Delete.Table("ProductCategories");
        
    }
}
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Migrations.Migrations;

public class _202505161918Initiliaze_UserTables : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        Create.Table("Users")
                .WithColumn("Id").AsString(450).PrimaryKey()
                .WithColumn("UserName").AsString().NotNullable()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .
    }
}

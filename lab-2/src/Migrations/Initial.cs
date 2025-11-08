using FluentMigrator;

namespace MyApp.Migrations;

[Migration(1)]
public class Init : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString(128).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Migrator.Migrations;


[Migration(001)]
public class AddImagesTable : Migration
{
    public override void Up()
    {
        Execute.Sql(UpString);
    }

    public override void Down()
    {
        Delete.Table("Images");
    }

    private string UpString = """
        CREATE TABLE Images(
        	ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
        	Content varbinary(MAX) NOT NULL,
        	ImageType NVARCHAR(20) NOT NULL,
        	FileName NVARCHAR(255) NOT NULL,
        	Size INT,
        	Width INT,
        	Height INT
        )
        """;
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Migrator.Migrations;


[Migration(002)]
public class AlterImagesTableAddOwnership : Migration
{
    public override void Up()
    {
        Execute.Sql(UpString);
    }

    public override void Down()
    {
        Execute.Sql(DownString);
    }

    private string UpString = """
        Alter TABLE Images
        ADD Owner nvarchar(100) NOT NULL default 'N/A',
        IsPublic bit NOT NULL default 0
        
        """;
    private string DownString = """
        Alter TABLE Images
        DROP COLUMN Owner,
        DROP COLUMN IsPublic
        )
        """;
}

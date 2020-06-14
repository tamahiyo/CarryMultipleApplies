﻿namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableAgain_T_ApplyUsers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.T_ApplyUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.T_ApplyUsers",
                c => new
                    {
                        ApplyUserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastNameHiragana = c.String(nullable: false, maxLength: 50),
                        FirstNameHiragana = c.String(nullable: false, maxLength: 50),
                        AgeId = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 8),
                        PrefectureId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 200),
                        StreetBunchName = c.String(nullable: false, maxLength: 200),
                        BuildingName = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        JobId = c.Int(nullable: false),
                        MailAddress = c.String(nullable: false, maxLength: 256),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyUserId);
            
        }
    }
}

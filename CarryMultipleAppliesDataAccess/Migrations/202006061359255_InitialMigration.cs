namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_Ages",
                c => new
                    {
                        AgeId = c.Int(nullable: false),
                        AgeName = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AgeId);
            
            CreateTable(
                "dbo.M_Events",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        EventName = c.String(nullable: false, maxLength: 200),
                        EventDate = c.String(maxLength: 20),
                        ApplyFrom = c.String(nullable: false, maxLength: 20),
                        ApplyTo = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.M_Jobs",
                c => new
                    {
                        JobId = c.Long(nullable: false),
                        JobName = c.String(nullable: false, maxLength: 50),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.M_Prefectures",
                c => new
                    {
                        PrefectureId = c.Int(nullable: false),
                        PrefectureName = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PrefectureId);
            
            CreateTable(
                "dbo.M_StoreEventDisplays",
                c => new
                    {
                        StoreEventDisplayId = c.Int(nullable: false),
                        StoreEventId = c.Int(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 20),
                        DisplayNamePrefix = c.String(nullable: false, maxLength: 50),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.StoreEventDisplayId)
                .ForeignKey("dbo.M_StoreEvents", t => t.StoreEventId, cascadeDelete: true)
                .Index(t => t.StoreEventId);
            
            CreateTable(
                "dbo.M_StoreEvents",
                c => new
                    {
                        StoreEventId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        StoreEventName = c.String(nullable: false, maxLength: 50),
                        ApplyUrl = c.String(nullable: false, maxLength: 200),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.StoreEventId);
            
            CreateTable(
                "dbo.T_ApplyHistories",
                c => new
                    {
                        ApplyHistoryId = c.Int(nullable: false, identity: true),
                        StoreEventId = c.Int(nullable: false),
                        SerialNo = c.String(nullable: false, maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastNameHiragana = c.String(nullable: false, maxLength: 50),
                        FirstNameHiragana = c.String(nullable: false, maxLength: 50),
                        AgeId = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Zipcode = c.String(nullable: false, maxLength: 8),
                        PrefectureId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 200),
                        StreetBunchName = c.String(nullable: false, maxLength: 200),
                        BuildingName = c.String(maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        JobId = c.Int(nullable: false),
                        MailAddress = c.String(nullable: false, maxLength: 256),
                        IsApply = c.Int(nullable: false),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyHistoryId);
            
            CreateTable(
                "dbo.T_ApplyUsers",
                c => new
                    {
                        ApplyUserId = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastNameHiragana = c.String(maxLength: 50),
                        FirstNameHiragana = c.String(maxLength: 50),
                        AgeId = c.Int(),
                        Sex = c.Int(),
                        ZipCode = c.String(maxLength: 8),
                        PrefectureId = c.Int(),
                        City = c.String(maxLength: 200),
                        StreetBunchName = c.String(maxLength: 200),
                        BuildingName = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 20),
                        JobId = c.Int(),
                        MailAddress = c.String(maxLength: 256),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.M_StoreEventDisplays", "StoreEventId", "dbo.M_StoreEvents");
            DropIndex("dbo.M_StoreEventDisplays", new[] { "StoreEventId" });
            DropTable("dbo.T_ApplyUsers");
            DropTable("dbo.T_ApplyHistories");
            DropTable("dbo.M_StoreEvents");
            DropTable("dbo.M_StoreEventDisplays");
            DropTable("dbo.M_Prefectures");
            DropTable("dbo.M_Jobs");
            DropTable("dbo.M_Events");
            DropTable("dbo.M_Ages");
        }
    }
}

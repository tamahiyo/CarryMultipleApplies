namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropT_ApplyAndT_Histories : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.T_ApplyHistories");
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
                        LastName = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastNameHiragana = c.String(nullable: false, maxLength: 255),
                        FirstNameHiragana = c.String(nullable: false, maxLength: 255),
                        AgeId = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Zipcode = c.String(nullable: false, maxLength: 8),
                        PrefectureId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 255),
                        StreetBunchName = c.String(nullable: false, maxLength: 255),
                        BuildingName = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 64),
                        JobId = c.Int(nullable: false),
                        MailAddress = c.String(nullable: false, maxLength: 510),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyUserId);
            
            CreateTable(
                "dbo.T_ApplyHistories",
                c => new
                    {
                        ApplyHistoryId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        StoreEventId = c.Int(nullable: false),
                        SerialNo = c.String(nullable: false, maxLength: 19),
                        LastName = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastNameHiragana = c.String(nullable: false, maxLength: 255),
                        FirstNameHiragana = c.String(nullable: false, maxLength: 255),
                        AgeId = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Zipcode = c.String(nullable: false, maxLength: 8),
                        PrefectureId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 255),
                        StreetBunchName = c.String(nullable: false, maxLength: 255),
                        BuildingName = c.String(maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 64),
                        JobId = c.Int(nullable: false),
                        MailAddress = c.String(nullable: false, maxLength: 510),
                        IsApply = c.Int(nullable: false),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyHistoryId);
            
        }
    }
}

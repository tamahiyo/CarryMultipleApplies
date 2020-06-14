namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_ApplyHistories",
                c => new
                    {
                        ApplyHistoryId = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        StoreEventId = c.Int(nullable: false),
                        SerialNo = c.String(nullable: false, maxLength: 50),
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
                        AppliesStatusType = c.Int(nullable: false),
                        AppliesStatusMessage = c.String(maxLength: 2147483647),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ApplyHistoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_ApplyHistories");
        }
    }
}

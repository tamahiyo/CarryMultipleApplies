namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTale_T_ApplyUsers : DbMigration
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
    }
}

namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_M_EventsAndM_StoreEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_Events",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        EventName = c.String(nullable: false, maxLength: 200),
                        ApplyFrom = c.String(nullable: false, maxLength: 20),
                        ApplyTo = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.M_Events");
        }
    }
}

namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTable_M_EventsAndM_StoreEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.M_StoreEvents", "EventDate", c => c.String(maxLength: 20));
            DropTable("dbo.M_Events");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.M_StoreEvents", "EventDate");
        }
    }
}

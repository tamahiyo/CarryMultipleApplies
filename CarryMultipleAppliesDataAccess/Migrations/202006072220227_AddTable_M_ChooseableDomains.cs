namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_M_ChooseableDomains : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_ChooseableDomains",
                c => new
                    {
                        DomainId = c.Int(nullable: false),
                        DomainName = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DomainId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.M_ChooseableDomains");
        }
    }
}

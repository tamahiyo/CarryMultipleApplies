namespace CarryMultipleAppliesDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_M_UserAndAddColumn_UserNameByT_ApplyUsersAndT_ApplyHistories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 20),
                        InsertDate = c.String(nullable: false, maxLength: 20),
                        InsertUser = c.String(nullable: false, maxLength: 100),
                        UpdateDate = c.String(nullable: false, maxLength: 20),
                        UpdateUser = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserName);
            
            AddColumn("dbo.T_ApplyHistories", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.T_ApplyUsers", "UserName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_ApplyUsers", "UserName");
            DropColumn("dbo.T_ApplyHistories", "UserName");
            DropTable("dbo.M_Users");
        }
    }
}

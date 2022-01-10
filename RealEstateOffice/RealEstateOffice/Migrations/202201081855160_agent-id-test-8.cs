namespace RealEstateOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentidtest8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Adverts", name: "Agent_agent_id", newName: "agent_id");
            RenameIndex(table: "dbo.Adverts", name: "IX_Agent_agent_id", newName: "IX_agent_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Adverts", name: "IX_agent_id", newName: "IX_Agent_agent_id");
            RenameColumn(table: "dbo.Adverts", name: "agent_id", newName: "Agent_agent_id");
        }
    }
}

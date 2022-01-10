namespace RealEstateOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentidtest3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgentAdverts", "Agent_agent_id", "dbo.Agents");
            DropForeignKey("dbo.AgentAdverts", "Advert_advert_id", "dbo.Adverts");
            DropIndex("dbo.AgentAdverts", new[] { "Agent_agent_id" });
            DropIndex("dbo.AgentAdverts", new[] { "Advert_advert_id" });
            AddColumn("dbo.Agents", "Advert_advert_id", c => c.Int());
            CreateIndex("dbo.Agents", "Advert_advert_id");
            AddForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts", "advert_id");
            DropTable("dbo.AgentAdverts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AgentAdverts",
                c => new
                    {
                        Agent_agent_id = c.Int(nullable: false),
                        Advert_advert_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Agent_agent_id, t.Advert_advert_id });
            
            DropForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts");
            DropIndex("dbo.Agents", new[] { "Advert_advert_id" });
            DropColumn("dbo.Agents", "Advert_advert_id");
            CreateIndex("dbo.AgentAdverts", "Advert_advert_id");
            CreateIndex("dbo.AgentAdverts", "Agent_agent_id");
            AddForeignKey("dbo.AgentAdverts", "Advert_advert_id", "dbo.Adverts", "advert_id", cascadeDelete: true);
            AddForeignKey("dbo.AgentAdverts", "Agent_agent_id", "dbo.Agents", "agent_id", cascadeDelete: true);
        }
    }
}

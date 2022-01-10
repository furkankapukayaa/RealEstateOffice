namespace RealEstateOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentidtest2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts");
            DropIndex("dbo.Agents", new[] { "Advert_advert_id" });
            CreateTable(
                "dbo.AgentAdverts",
                c => new
                    {
                        Agent_agent_id = c.Int(nullable: false),
                        Advert_advert_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Agent_agent_id, t.Advert_advert_id })
                .ForeignKey("dbo.Agents", t => t.Agent_agent_id, cascadeDelete: true)
                .ForeignKey("dbo.Adverts", t => t.Advert_advert_id, cascadeDelete: true)
                .Index(t => t.Agent_agent_id)
                .Index(t => t.Advert_advert_id);
            
            DropColumn("dbo.Agents", "Advert_advert_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "Advert_advert_id", c => c.Int());
            DropForeignKey("dbo.AgentAdverts", "Advert_advert_id", "dbo.Adverts");
            DropForeignKey("dbo.AgentAdverts", "Agent_agent_id", "dbo.Agents");
            DropIndex("dbo.AgentAdverts", new[] { "Advert_advert_id" });
            DropIndex("dbo.AgentAdverts", new[] { "Agent_agent_id" });
            DropTable("dbo.AgentAdverts");
            CreateIndex("dbo.Agents", "Advert_advert_id");
            AddForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts", "advert_id");
        }
    }
}

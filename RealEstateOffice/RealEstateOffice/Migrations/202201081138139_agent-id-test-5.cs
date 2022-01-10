namespace RealEstateOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentidtest5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adverts", "Agent_agent_id", "dbo.Agents");
            DropIndex("dbo.Adverts", new[] { "Agent_agent_id" });
            AddColumn("dbo.Agents", "Advert_advert_id", c => c.Int());
            CreateIndex("dbo.Agents", "Advert_advert_id");
            AddForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts", "advert_id");
            DropColumn("dbo.Adverts", "Agent_agent_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "Agent_agent_id", c => c.Int());
            DropForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts");
            DropIndex("dbo.Agents", new[] { "Advert_advert_id" });
            DropColumn("dbo.Agents", "Advert_advert_id");
            CreateIndex("dbo.Adverts", "Agent_agent_id");
            AddForeignKey("dbo.Adverts", "Agent_agent_id", "dbo.Agents", "agent_id");
        }
    }
}

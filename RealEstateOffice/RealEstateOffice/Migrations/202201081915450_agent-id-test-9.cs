namespace RealEstateOffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agentidtest9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "role", c => c.String());
            AddColumn("dbo.Adverts", "advert_name", c => c.String());
            AddColumn("dbo.Agents", "agent_name_surname", c => c.String());
            AddColumn("dbo.Agents", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "role");
            DropColumn("dbo.Agents", "agent_name_surname");
            DropColumn("dbo.Adverts", "advert_name");
            DropColumn("dbo.Admins", "role");
        }
    }
}

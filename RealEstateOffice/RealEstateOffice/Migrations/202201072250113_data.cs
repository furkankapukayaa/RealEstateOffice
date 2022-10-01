namespace RealEstateOffice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                {
                    admin_id = c.Int(nullable: false, identity: true),
                    admin_username = c.String(),
                    admin_password = c.String(),
                    admin_name_surname = c.String(),
                    admin_name_mail = c.String(),
                })
                .PrimaryKey(t => t.admin_id);

            CreateTable(
                "dbo.Adverts",
                c => new
                {
                    advert_id = c.Int(nullable: false, identity: true),
                    number_of_rooms = c.String(),
                    residance_age = c.String(),
                    square_meters = c.String(),
                    category = c.String(),
                    price = c.String(),
                })
                .PrimaryKey(t => t.advert_id);

            CreateTable(
                "dbo.Agents",
                c => new
                {
                    agent_id = c.Int(nullable: false, identity: true),
                    agent_username = c.String(),
                    agent_password = c.String(),
                    agent_company_name = c.String(),
                    agent_company_mail = c.String(),
                    agent_company_address = c.String(),
                    agent_company_phone = c.String(),
                    Advert_advert_id = c.Int(),
                })
                .PrimaryKey(t => t.agent_id)
                .ForeignKey("dbo.Adverts", t => t.Advert_advert_id)
                .Index(t => t.Advert_advert_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Agents", "Advert_advert_id", "dbo.Adverts");
            DropIndex("dbo.Agents", new[] { "Advert_advert_id" });
            DropTable("dbo.Agents");
            DropTable("dbo.Adverts");
            DropTable("dbo.Admins");
        }
    }
}
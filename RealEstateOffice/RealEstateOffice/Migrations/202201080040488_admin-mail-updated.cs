namespace RealEstateOffice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class adminmailupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "admin_mail", c => c.String());
            DropColumn("dbo.Admins", "admin_name_mail");
        }

        public override void Down()
        {
            AddColumn("dbo.Admins", "admin_name_mail", c => c.String());
            DropColumn("dbo.Admins", "admin_mail");
        }
    }
}
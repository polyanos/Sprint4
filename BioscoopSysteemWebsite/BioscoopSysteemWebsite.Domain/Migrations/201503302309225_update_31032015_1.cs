namespace BioscoopSysteemWebsite.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_31032015_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BackofficeUsers", "BackofficeUsertypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BackofficeUsers", "BackofficeUsertypeId", c => c.Int(nullable: false));
        }
    }
}

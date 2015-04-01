namespace BioscoopSysteemWebsite.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_31032015_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackofficeUsers", "type_Id", "dbo.BackofficeRoles");
            DropIndex("dbo.BackofficeUsers", new[] { "type_Id" });
            DropColumn("dbo.BackofficeUsers", "type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BackofficeUsers", "type_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BackofficeUsers", "type_Id");
            AddForeignKey("dbo.BackofficeUsers", "type_Id", "dbo.BackofficeRoles", "Id");
        }
    }
}

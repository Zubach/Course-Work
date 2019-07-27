namespace WpfApp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblSites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        Description = c.String(),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSites", "UserID", "dbo.tblUsers");
            DropIndex("dbo.tblSites", new[] { "UserID" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblSites");
        }
    }
}

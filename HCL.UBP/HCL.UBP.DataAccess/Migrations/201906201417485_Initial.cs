namespace HCL.UBP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 36),
                        Password = c.String(nullable: false, maxLength: 36),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserDetails", new[] { "Username" });
            DropTable("dbo.UserDetails");
        }
    }
}

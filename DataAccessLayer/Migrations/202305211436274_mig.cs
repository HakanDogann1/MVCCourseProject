namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Writer_WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contacts", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "Writer_WriterID" });
            DropIndex("dbo.Contacts", new[] { "WriterID" });
            AlterColumn("dbo.Contacts", "WriterID", c => c.Int());
            CreateIndex("dbo.Contacts", "WriterID");
            AddForeignKey("dbo.Contacts", "WriterID", "dbo.Writers", "WriterID");
            DropColumn("dbo.Contents", "Writer_WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "Writer_WriterID", c => c.Int());
            DropForeignKey("dbo.Contacts", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contacts", new[] { "WriterID" });
            AlterColumn("dbo.Contacts", "WriterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "WriterID");
            CreateIndex("dbo.Contents", "Writer_WriterID");
            AddForeignKey("dbo.Contacts", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "Writer_WriterID", "dbo.Writers", "WriterID");
        }
    }
}
